using Mono.Data.Sqlite;
using System.Data;
using System.Configuration;
using DapperExtensions.Mapper;

namespace PasswordUsher.Core
{
	internal static class SqlHelper
	{
		private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings ["PasswordManagerConnection"].ConnectionString;
		private static IDbConnection connection;
		
		public static IDbConnection GetConnection ()
		{			
			// DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
			if (connection == null) {			
				connection = new SqliteConnection (ConnectionString);
				connection.Open ();
			}
			return connection;
		}
		
		public static void CloseConnection ()
		{
			if (connection != null) {		
				connection.Dispose ();
			}
		}	
	}
}