using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using Dapper;
using DapperExtensions;
using System.Diagnostics;

namespace PasswordUsher.Core.Data
{
	public abstract class BaseDataAccess<TEntity> where TEntity : class
	{		
		public virtual IEnumerable<TEntity> GetAll ()
		{
			using (var connection = SqlHelper.GetConnection ()) {			
				return connection.GetList<TEntity> ().ToList ();					
			}
		}
		
		public virtual TEntity Get (Int64 id)
		{
			using (var connection = SqlHelper.GetConnection ()) {
				return connection.Get<TEntity> (id);		
			}
		}
		
		public abstract bool Insert (TEntity entity);		
		
		public abstract bool Update (TEntity entity);		
		
		public virtual void Delete (TEntity entity)
		{
			using (var connection = SqlHelper.GetConnection()) {
				connection.Delete<TEntity> (entity);
			}
		}
	}
}

