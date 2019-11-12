//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.ComponentModel;
using System.Drawing.Design;
using System.Collections.Specialized;
using System.Windows.Forms;
using Microsoft.SqlServerCe.Client;

namespace Microsoft.Data.ConnectionUI
{

	public class SqlCeConnectionProperties : AdoDotNetConnectionProperties
	{
		public SqlCeConnectionProperties()
			: base("System.Data.SqlClient")
		{
		}

		public override void Reset()
		{
			base.Reset();
		}

		public override bool IsComplete
		{
			get
			{

				string dataSource = this["Data Source"] as string;

				if (String.IsNullOrEmpty(dataSource))
				{
					return false;
				}

				// Ensure file extension: 
				if (!(Path.GetExtension(dataSource).Equals(".sdf", StringComparison.OrdinalIgnoreCase)))
				{
					return false;
				}

				return true;
			}
		}

		protected override string ToTestString()
		{
			bool savedPooling = (bool)ConnectionStringBuilder["Pooling"];
			bool wasDefault = !ConnectionStringBuilder.ShouldSerialize("Pooling");
			ConnectionStringBuilder["Pooling"] = false;
			string testString = ConnectionStringBuilder.ConnectionString;
			ConnectionStringBuilder["Pooling"] = savedPooling;
			if (wasDefault)
			{
				ConnectionStringBuilder.Remove("Pooling");
			}
			return testString;
		}

		public override void Test()
		{
			string testString = ToTestString();


			// Create a connection object
			SqlCeConnection connection = new SqlCeConnection();

			// Try to open it
			try
			{
				connection.ConnectionString = ToFullString();
				connection.Open();
			}
			catch (SqlCeException e)
			{
				// Customize the error message for upgrade required
				if (e.Number == m_intDatabaseFileNeedsUpgrading)
				{
					throw new InvalidOperationException(Resources.SqlCeConnectionProperties_FileNeedsUpgrading);
				}
				throw;
			}
			finally
			{
				connection.Dispose();
			}
		}

		private const int m_intDatabaseFileNeedsUpgrading = 25138;

	}
}

