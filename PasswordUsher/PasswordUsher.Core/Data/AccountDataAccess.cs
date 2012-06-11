using System;
using System.Linq;
using Dapper;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;
using System.Collections.Generic;
using DapperExtensions;

namespace PasswordUsher.Core
{
	public class AccountDataAccess : BaseDataAccess<Account>
	{
		public IEnumerable<Account> GetByProvider(Int64 id)
		{
			using (var connection = SqlHelper.GetConnection ()) 
			{	
				var predicate = Predicates.Field<Account>(f => f.ProviderId, Operator.Eq, id);
    			return connection.GetList<Account>(predicate).ToList();
			}
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
		
		public bool Delete(long id)
		{
			try {
				using (var connection = SqlHelper.GetConnection ()) {			
					connection.Execute (@"delete from Accounts where Id = @Id;",
					 new { id = id });							
				}	
				return true;
				
			} catch (Exception ex) {
				throw ex;
			}	
		}
		
		#endregion
	}
}

