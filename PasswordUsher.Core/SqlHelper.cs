using System.Configuration;
using System.Data;
using System.Diagnostics;
using DapperExtensions.Mapper;
using System.Data.SQLite;

namespace PasswordUsher.Core
{	
	public static class SqlHelper
	{
		private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings ["ConnectionString"].ConnectionString;
		private static IDbConnection connection;
		
		public static IDbConnection GetConnection ()
		{			
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
			connection = new SQLiteConnection (ConnectionString);				
						
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