using System;
using Dapper;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;

namespace PasswordUsher.Core
{
	public class AccountDataAccess : BaseDataAccess<Account>
	{
		public AccountDataAccess ()
		{
		}

		#region implemented abstract members of PasswordUsher.Core.Data.BaseDataAccess[Account]
		public override bool Insert (Account entity)
		{
			try {
				using (var connection = SqlHelper.GetConnection ()) {			
					connection.Execute (@"insert into Accounts values(null, @name, @password, @providerId)",
					 new {name = entity.Name, password = entity.Password, providerId = entity.ProviderId });							
				}	
				return true;
				
			} catch (Exception ex) {
				throw ex;
			}		
		}

		public override bool Update (Account entity)
		{
			try {
				using (var connection = SqlHelper.GetConnection ()) {			
					connection.Execute (@"update Accounts set Name = @name, Password  = @password, ProviderId = @providerId where Id = @Id;",
					 new {name = entity.Name, password = entity.Password, providerId = entity.ProviderId, id = entity.Id });							
				}	
				return true;
				
			} catch (Exception ex) {
				throw ex;
			}		
		}
		#endregion
	}
}

