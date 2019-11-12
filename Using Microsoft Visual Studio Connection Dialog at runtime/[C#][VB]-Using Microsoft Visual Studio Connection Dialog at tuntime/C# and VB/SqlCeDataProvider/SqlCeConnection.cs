//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Data.ConnectionUI
{
	public class SqlCe
	{
		public static DataSource SqlCeDataSource
		{
			get
			{
				if (_sqlCeDataSource == null)
				{
					_sqlCeDataSource = new DataSource("SqlCeClient", "Microsoft SQL Server Compact 3.5");
					_sqlCeDataSource.Providers.Add(SqlCeDataProvider);
				}
				return _sqlCeDataSource;
			}
		}

		private static DataSource _sqlCeDataSource;

		public static DataProvider SqlCeDataProvider
		{
			get
			{
				if (_sqlCeDataProvider == null)
				{
					Dictionary<string, string> descriptions = new Dictionary<string, string>();
					descriptions.Add(SqlCeDataSource.Name, Resources.DataProvider_SqlEverywhere_Description);

					Dictionary<string, Type> uiControls = new Dictionary<string, Type>();
					uiControls.Add(String.Empty, typeof(SqlCeConnectionUIControl));

					_sqlCeDataProvider = new DataProvider(
						"System.Data.SqlCeClient",
						Resources.DataProvider_SqlEverywhere,
						"SqlCeClient",
						Resources.DataProvider_SqlEverywhere_Description,
						typeof(System.Data.SqlServerCe.SqlCeConnection),
						descriptions,
						uiControls,
						typeof(SqlCeConnectionProperties));
				}
				return _sqlCeDataProvider;
			}
		}
		private static DataProvider _sqlCeDataProvider;
	}
}
