using System;
using System.Linq;
using PasswordUsher.Core;
using NUnit.Framework;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;

namespace PasswordUsher.Core.Tests
{
	[TestFixture]
	public class DataAccessTests
	{
		ProviderDataAccess providerData;
		
		public DataAccessTests ()
		{
			providerData = new ProviderDataAccess();
		}
		
		[Test]
	    public void can_get_all_service_records()
		{
			var providers = providerData.GetAll();			
			Assert.Greater(0, providers.Count());
		}
		
		[Ignore]
	    public void can_get_a_service_record()
		{
			var provider = providerData.Get(1);
			Assert.AreEqual(1, provider.Id);
			Assert.AreEqual("Google", provider.Name);
		}
		
		[Ignore]
	    public void can_add_a_service_record()
		{
			var provider = new Provider { Name = "Google" };
			providerData.Insert(provider);			
			Assert.AreEqual("Google", providerData.Get(1).Name);
		}
	}
}

