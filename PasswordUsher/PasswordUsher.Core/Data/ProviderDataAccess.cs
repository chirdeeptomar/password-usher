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
		public override bool Insert (Provider entity)
		{
			try {
				using (var connection = SqlHelper.GetConnection ()) {			
					connection.Execute (@"insert into Providers values(null, @name)", new {name = entity.Name});	
					dynamic collection = connection.Query ("select last_insert_rowid()").FirstOrDefault ();				
				}	
				return true;
				
			} catch (Exception ex) {
				return false;
			}				
		}
	}
}

