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

		public bool SaveAccount (Account entity)
		{
			return entity.Id == 0 ? accountData.Insert(entity) : accountData.Update(entity);
		}		

		public bool DeleteAccount (long id)
		{
			return accountData.Delete(id);
		}

		public Account Get (long id)
		{
			var account = accountData.Get(id);
			return account;
		}

		#endregion
	}
}

