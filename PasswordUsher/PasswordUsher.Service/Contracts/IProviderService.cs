using System;
using PasswordUsher.Domain.Entities;
using System.Collections.Generic;

namespace PasswordUsher.Service.Contracts
{
	public interface IProviderService
	{
		void AddProvider(Provider provider);
		
		IEnumerable<Provider> GetProviders();		
	}
}

