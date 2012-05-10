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
		
		public virtual TEntity Get (int id)
		{
			using (var connection = SqlHelper.GetConnection ()) {
				return connection.Get<TEntity> (id);		
			}
		}
		
		public virtual bool Insert (TEntity entity)
		{			
			try {
				var connection = SqlHelper.GetConnection ();			
				connection.Insert<TEntity> (entity);
				connection.Close ();	
				return true;
				} 
			catch (Exception ex) {
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);			
				return false;
			}			
		}
		
		public virtual void Update (TEntity entity)
		{
			using (var connection = SqlHelper.GetConnection()) {
				connection.Update<TEntity> (entity);
			}			
		}
		
		public virtual void Delete (TEntity entity)
		{
			using (var connection = SqlHelper.GetConnection()) {
				connection.Delete<TEntity> (entity);
			}
		}
	}
}

