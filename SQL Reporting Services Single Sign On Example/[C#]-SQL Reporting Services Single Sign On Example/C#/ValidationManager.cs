/*============================================================================
 THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
 ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
 THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 PARTICULAR PURPOSE.
===========================================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Web;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Management;

using System.Diagnostics;

namespace Sample.ReportingServices.Security {
	
	/// <summary>
	/// validation logic for authentication
	/// </summary>
	/// <remarks>
	/// marked as sealed so it can't be derived and change functionality
	/// </remarks>
	public sealed class ValidationManager {

		string _connectionString = "";
		// The path of any item in the report server database 
		// has a maximum character length of 260
		private const int MaxItemPathLength = 260;
		private const string wmiNamespace = @"\root\Microsoft\SqlServer\ReportServer\{0}\v10";
		private const string rsAsmx = @"/ReportService2010.asmx";
		private string _validatedUserToken;

		public ValidationManager() {
			this._connectionString = ConfigurationManager.AppSettings["ReportMainConnectionString"];
		}

		/// <summary>
		/// validates that a given user is a valid account
		/// </summary>
		/// <param name="accountName">user token for the user based on current principal</param>
		/// <returns>true when the account is valid</returns>
		public bool ValidatePrincipalName(string userToken) {
			return IsValidUserToken( userToken );
		}

		/// <summary>
		/// validates that the user is valid based on values in the header
		/// in the form of a hashed value and username
		/// </summary>
		/// <param name="headers">headers from the http request</param>
		/// <returns>true if a valid user account with correct header info</returns>
		public bool ValidateUserInfo(NameValueCollection headers) {

			bool isValid = false;

            _validatedUserToken = "user@microsoft.com";
            return true;

			//are our headers present?
			if ( headers != null && headers.Count > 0 ) {
				if ( headers["UserToken"] != null ) {
					//need to validate the header information related to the request
					//expecting a header with AuthToken
					//need to validate the user is a valid one in the database
					//expecting a header with UserToken
					isValid = ( IsValidHeaderHash( headers["AuthToken"] ) && IsValidUserToken( headers["UserToken"] ) );
				}
			}

			return isValid;
		}

		/// <summary>
		/// validates that the user exists and matches in the database
		/// </summary>
		/// <param name="userName">username to validate</param>
		/// <returns>true if user exists and matches provided username</returns>
		private bool IsValidUserToken(string userToken) {
			//assume not valid
			bool isUserValid = false;

			if ( userToken != null && userToken.Length > 0 ) {

				string sql = "SELECT username, [role] FROM [dbo].[USERS] WHERE username = @username AND [role]='Reports'";

				//create parameter
				SqlParameter pram = new SqlParameter( "@username", SqlDbType.VarChar, 256 );
				pram.Value = userToken;

				SqlParameter[] prams = {
					pram
				};

				//check the database
				if ( DataExists( _connectionString, sql, prams, "userName", userToken ) ) {
					_validatedUserToken = userToken;
					isUserValid = true;
				}
			}

			//return
			return isUserValid;
		}


		/// <summary>
		/// Validate the header auth token to ensure the request is valid
		/// </summary>
		/// <param name="authKey">header authetication token</param>
		/// <returns>true if valid</returns>
		private bool IsValidHeaderHash(string authKey) {
			//assume not valid
			bool validHeader = false;

			if ( authKey != null && authKey.Length > 0 ) {

				if( authKey.Equals(ConfigurationManager.AppSettings["AuthKey"]) ) {
					validHeader = true;
				}
			}

			return validHeader;
		}


		/// <summary>
		/// runs the specified query and tests to see if the data returned matches the value to test 
		/// by checking to see if it contains the value 
		/// </summary>
		/// <param name="connectionString">connection string to database</param>
		/// <param name="sqlString">sql to run</param>
		/// <param name="prams">parameters to pass</param>
		/// <param name="columnToTest">column to validate against</param>
		/// <param name="valueToTest">value to test against column</param>
		/// <returns>true if the value matches</returns>
		private bool DataExists( string connectionString, string sqlString, SqlParameter[] prams, string columnToTest, string valueToTest) {
			bool dataExists = false;
			//connect to store for configuration
			using ( SqlConnection conn = new SqlConnection( connectionString ) ) {

				//run command to validate account name
				SqlCommand cmd = new SqlCommand( sqlString, conn );
				cmd.CommandType = CommandType.Text;

				//create parameter for account name
				if ( prams != null ) {
					foreach ( SqlParameter pram in prams ) {
						cmd.Parameters.Add( pram );
					}
				}

				try {
					conn.Open();
					using ( SqlDataReader reader = cmd.ExecuteReader() ) {
						//If a row exists for the user, then assume user is valid
						//but to be safe we want to explicitly check for a match, rather than assume
						if ( reader.Read() ) {

							if ( reader[columnToTest].ToString().Equals( valueToTest ) ) {
								dataExists = true;
							}
						}
					}
				} catch ( Exception ex ) {
					throw new Exception( ex.Message );
				}
				return dataExists;
			}
		}

		/// <summary>
		/// get the url of the report server
		/// check the configuration file first for that information and if not available
		/// use WMI.  Check config first, because we may need to ensure we are communicating 
		/// locally instead of back out.
		/// </summary>
		/// <param name="machineName">Name of machine</param>
		/// <param name="instanceName">Instance name of SQL Server</param>
		/// <returns>Report Server Url</returns>
		internal static string GetReportServerUrl(string machineName, string instanceName) {
			string reportServerVirtualDirectory = String.Empty;
			
			if ( ConfigurationManager.AppSettings["ReportServerWebServiceUrl"] != null &&
				ConfigurationManager.AppSettings["ReportServerWebServiceUrl"].Length > 0 ) {
				//use the configuration settings
					reportServerVirtualDirectory = ConfigurationManager.AppSettings["ReportServerWebServiceUrl"];
			} else {

				string fullWmiNamespace = @"\\" + machineName + string.Format( wmiNamespace, instanceName );

				ManagementScope scope = null;

				ConnectionOptions connOptions = new ConnectionOptions();
				connOptions.Authentication = AuthenticationLevel.PacketPrivacy;

				//Get management scope
				try {
					scope = new ManagementScope( fullWmiNamespace, connOptions );
					scope.Connect();

					//Get management class
					ManagementPath path = new ManagementPath( "MSReportServer_Instance" );
					ObjectGetOptions options = new ObjectGetOptions();
					ManagementClass serverClass = new ManagementClass( scope, path, options );

					serverClass.Get();

					if ( serverClass == null )
						throw new Exception( string.Format( CultureInfo.InvariantCulture, "No WMI class found." ) );

					//Get instances
					ManagementObjectCollection instances = serverClass.GetInstances();

					foreach ( ManagementObject instance in instances ) {
						instance.Get();

						ManagementBaseObject outParams = (ManagementBaseObject)instance.InvokeMethod( "GetReportServerUrls", null, null );

						string[] appNames = (string[])outParams["ApplicationName"];
						string[] urls = (string[])outParams["URLs"];

						for ( int i = 0; i < appNames.Length; i++ ) {
							if ( appNames[i] == "ReportServerWebService" )
								reportServerVirtualDirectory = urls[i];
						}

						if ( reportServerVirtualDirectory == string.Empty )
							throw new Exception( string.Format( CultureInfo.InvariantCulture, "No Url reservation found for the \"ReportServerWebService\" application." ) );
					}
				} catch ( Exception ex ) {
					throw new Exception( string.Format( CultureInfo.InvariantCulture, "An error occurred while attempting to get the ReportServer Url." + ex.Message ), ex );
				}
			}

			return reportServerVirtualDirectory + rsAsmx;
		}

		public string ValidatedUserToken {
			get { return _validatedUserToken; }
		}

	}
}
