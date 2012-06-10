using System;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;

namespace PasswordUsher.Service
{
	public class ProviderService
	{
		ProviderDataAccess providerData;
	
		public ProviderService ()
		{
			providerData = new ProviderDataAccess();
		}
		
		public void AddProvider(Provider provider)
		{
			providerData.Insert(provider);
		}
	}
}

