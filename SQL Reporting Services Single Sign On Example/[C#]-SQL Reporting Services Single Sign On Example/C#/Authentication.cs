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
using System.Security.Principal;
using System.Web;
using System.Xml;
using Microsoft.ReportingServices.Interfaces;
using System.Globalization;

namespace Sample.ReportingServices.Security {
	
	
	public class Authentication : IAuthenticationExtension {

		#region IAuthenticationExtension Members
		/// <summary>
		/// Required by IAuthenticationExtension. The report server calls the 
		/// GetUserInfo methodfor each request to retrieve the current user 
		/// identity.
		/// </summary>
		/// <param name="userIdentity">represents the identity of the current 
		/// user. The value of IIdentity may appear in a user interface and 
		/// should be human readable</param>
		/// <param name="userId">represents a pointer to a unique user identity
		/// </param>
		public void GetUserInfo(out System.Security.Principal.IIdentity userIdentity, out IntPtr userId) {
			// If the current user identity is not null,
			// set the userIdentity parameter to that of the current user 
			if ( HttpContext.Current != null
				  && HttpContext.Current.User != null ) {
				userIdentity = HttpContext.Current.User.Identity;
			} else {
				// The current user identity is null. This happens when the user attempts an anonymous logon.
				// Although it is ok to return userIdentity as a null reference, it is best to throw an appropriate
				// exception for debugging purposes.
				// To configure for anonymous logon, return a Gener
				System.Diagnostics.Debug.Assert( false, "Warning: userIdentity is null! Modify your code if you wish to support anonymous logon." );
				throw new NullReferenceException( "Anonymous logon is not configured. userIdentity should not be null!" );
				//userIdentity = new GenericIdentity( "anon" );
			}

			// initialize a pointer to the current user id to zero
			userId = IntPtr.Zero;
		}


		/// <summary>
		/// The IsValidPrincipalName method is called by the report server when 
		/// the report server sets security on an item. This method validates 
		/// that the user name is valid for Windows.  The principal name needs to 
		/// be a user, group, or builtin account name.
		/// </summary>
		/// <param name="principalName">A user, group, or built-in account name
		/// </param>
		/// <returns>true when the principle name is valid</returns>
		public bool IsValidPrincipalName(string principalName) {
			ValidationManager mgr = new ValidationManager();
			return mgr.ValidatePrincipalName( principalName);
		}

		/// <summary>
		/// Indicates whether a supplied username and password are valid.
		/// </summary>
		/// <param name="userName">The supplied username</param>
		/// <param name="password">The supplied password</param>
		/// <param name="authority">Optional. The specific authority to use to
		/// authenticate a user. For example, in Windows it would be a Windows 
		/// Domain</param>
		/// <returns>true when the username and password are valid</returns>
		public bool LogonUser(string userName, string password, string authority) {
			ValidationManager mgr = new ValidationManager();
			return mgr.ValidateUserInfo(HttpContext.Current.Request.Headers);
		}

		#endregion

		#region IExtension Members
		/// <summary>
		/// You must implement LocalizedName as required by IExtension
		/// </summary>
		public string LocalizedName {
			get { 
				//throw new NotImplementedException();
				return null;
			}
		}

		/// <summary>
		/// You must implement SetConfiguration as required by IExtension
		/// </summary>
		/// <param name="configuration">Configuration data as an XML
		/// string that is stored along with the Extension element in
		/// the configuration file.</param>
		public void SetConfiguration(string configuration) {
			//XmlDocument doc = new XmlDocument();

			//doc.LoadXml(configuration);
			//if ( doc.DocumentElement.Name == "SecurityConfiguration" ) {
			//    foreach ( XmlNode child in doc.DocumentElement.ChildNodes ) {
			//        if ( child.Name == "ConnectionString" ) {
			//            _userValidationConnectionString = child.InnerText;
			//        } else {
			//            throw new FormatException( "Security configuration element missing from config file" );
			//        }
			//    }
			//} else {
			//    throw new FormatException( "SecurityConfiguration element expected" );
			//}

		}

		#endregion
	}
}
