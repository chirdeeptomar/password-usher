using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using Dapper;
using DapperExtensions;

namespace PasswordUsher.Core.Data
{
	public abstract class BaseDataAccess<T> where T : class
	{		
		public virtual IEnumerable<T> GetAll ()
		{
			var connection = SqlHelper.GetConnection ();
			
			var result = connection.GetList<T> ().ToList();			
			connection.Close ();
			return result;			
		}
		
		public virtual T Get (int id)
		{
			var connection = SqlHelper.GetConnection ();
			T record = connection.Get<T> (id);
			connection.Close();
			return record;			
		}
		
		public virtual void Insert (T entity)
		{
			var connection = SqlHelper.GetConnection();
			connection.Insert<T> (entity);
			connection.Close();
		}
		
		public virtual void Update (T entity)
		{
			var connection = SqlHelper.GetConnection();
			connection.Update<T> (entity);
			connection.Close();
		}
		
		public virtual void Delete (T entity)
		{
			var connection = SqlHelper.GetConnection();
			connection.Delete<T> (entity);
			connection.Close();
		}
	}
}

