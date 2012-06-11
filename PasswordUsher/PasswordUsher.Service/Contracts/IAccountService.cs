using System;
using System.Collections.Generic;
using PasswordUsher.Domain.Entities;

namespace PasswordUsher.Service.Contracts
{
	public interface IAccountService
	{
		IEnumerable<Account> GetByProvider(Int64 id);
		
		bool AddAccount (Account entity);
		
		bool UpdateAccount (Account entity);
		
		bool DeleteAccount(Int64 id);
	}
}

