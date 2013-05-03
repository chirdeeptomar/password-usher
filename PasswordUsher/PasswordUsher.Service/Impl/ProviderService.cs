using System;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;
using PasswordUsher.Service.Contracts;
using System.Collections.Generic;

namespace PasswordUsher.Service.Impl
{
	public class ProviderService : IProviderService
	{
		ProviderDataAccess providerData;
	
		public ProviderService ()
		{
			providerData = new ProviderDataAccess();
		}
		
		#region IProviderService implementation
		
		public void AddProvider(Provider provider)
		{
			providerData.Insert(provider);
		}
				
		public IEnumerable<Provider> GetProviders ()
		{
			return providerData.GetAll();
		}
		
		#endregion
	}
}

