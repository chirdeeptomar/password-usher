using Dapper;
using PasswordUsher.Domain.Entities;

namespace PasswordUsher.Core
{
	public class PasswordUsherDatabase :  Database<PasswordUsherDatabase>
	{		
		public Table<Provider> Providers { get; set; }   
		public Table<Account> Accounts { get; set; }
	}
}

