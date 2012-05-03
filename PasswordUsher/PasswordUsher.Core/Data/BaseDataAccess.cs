using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using Dapper;
using DapperExtensions;

namespace PasswordUsher.Core.Data
{
	public abstract class BaseDataAccess<TEntity> where TEntity : class
	{		
		public virtual IEnumerable<TEntity> GetAll ()
		{
			using(var connection = SqlHelper.GetConnection ())
			{			
				return connection.GetList<TEntity> ().ToList();					
			}
		}
		
		public virtual TEntity Get (int id)
		{
			using(var connection = SqlHelper.GetConnection ())
			{
				return connection.Get<TEntity> (id);		
			}
		}
		
		public virtual void Insert (TEntity entity)
		{
			using(var connection = SqlHelper.GetConnection())
			{
				connection.Insert<TEntity>(entity);
			}
		}
		
		public virtual void Update (TEntity entity)
		{
			using(var connection = SqlHelper.GetConnection())
			{
				connection.Update<TEntity>(entity);
			}			
		}
		
		public virtual void Delete (TEntity entity)
		{
			using(var connection = SqlHelper.GetConnection())
			{
				connection.Delete<TEntity>(entity);
			}
		}
	}
}

