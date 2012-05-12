using Dapper;
using System.Linq;
using Mono.Data.Sqlite;
using PasswordUsher.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PasswordUsher.Core.Data
{
	public class ProviderDataAccess : BaseDataAccess<Provider>
	{	
		#region implemented abstract members of PasswordUsher.Core.Data.BaseDataAccess[Provider]
		public override bool Insert (Provider entity)
		{
			try {
				using (var connection = SqlHelper.GetConnection ()) {			
					connection.Execute (@"insert into Providers values(null, @name)", new {name = entity.Name});							
				}	
				return true;
				
			} catch (Exception ex) {
				throw ex;
			}				
		}
		
		public override bool Update (Provider entity)
		{
			try {
				using (var connection = SqlHelper.GetConnection()) {
					connection.Execute (@"update Providers set Name = @Name where Id = @id;", new { name= entity.Name, id = entity.Id });
				}	
				return true;
			} catch (Exception ex) {
				throw ex;
			}						
		}	
		#endregion	
	}
}

