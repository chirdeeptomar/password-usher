using System.Configuration;
using System.Data;
using DapperExtensions.Mapper;
using Mono.Data.Sqlite;
using System.Diagnostics;

namespace PasswordUsher.Core
{	
	internal static class SqlHelper
	{
		private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings ["ConnectionString"].ConnectionString;
		private static IDbConnection connection;
		
		public static IDbConnection GetConnection ()
		{			
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
			if (connection == null) {			
				connection = new SqliteConnection (ConnectionString);				
			}
			
			if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken) 
			{			
				connection.Open();
			}
			Debug.WriteLine(string.Format("Connecting to: {0}", connection.Database));
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