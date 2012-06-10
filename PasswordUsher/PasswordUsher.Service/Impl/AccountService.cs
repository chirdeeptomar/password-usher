using System;
using System.Collections.Generic;
using PasswordUsher.Domain.Entities;
using PasswordUsher.Service.Contracts;
using PasswordUsher.Core;

namespace PasswordUsher.Service.Impl
{
	public class AccountService : IAccountService
	{
		AccountDataAccess accountData;
		
		public AccountService ()
		{
			accountData = new AccountDataAccess ();
		}

		#region IAccountService implementation
		public IEnumerable<Account> GetByProvider (long id)
		{
			return accountData.GetByProvider(id);			
		}

		public bool AddAccount (Account entity)
		{
			return accountData.Insert(entity);
		}

		public bool UpdateAccount (Account entity)
		{
			return accountData.Update(entity);
		}
		#endregion
	}
}

