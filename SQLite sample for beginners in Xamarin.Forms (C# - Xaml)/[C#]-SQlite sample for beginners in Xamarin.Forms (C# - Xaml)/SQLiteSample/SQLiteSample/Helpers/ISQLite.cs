using System;
using SQLite.Net;

namespace SQLiteSample.Helpers
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
