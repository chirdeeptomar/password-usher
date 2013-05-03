using System;
using System.Linq;
using NUnit.Framework;
using PasswordUsher.Core;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;

namespace PasswordUsher.Core.Tests
{
	[TestFixture]
	public class ProviderDataAccessTests
	{
		ProviderDataAccess providerData;		
		
		public ProviderDataAccessTests ()
		{
			providerData = new ProviderDataAccess();			
		}
		
		[Test]
	    public void can_get_all_service_records()
		{
			var providers = providerData.GetAll();			
			Assert.Greater(providers.Count(), 0);
		}	
		
		[Test]
	    public void can_add_a_service_record()			
		{
			Guid guid = Guid.NewGuid();
			var provider = new Provider { Name = "Test" + guid  };
			bool operation  = providerData.Insert(provider);			
			Assert.IsTrue(operation);
		}
		
		[Test]
	    public void can_update_a_service_record()			
		{
			var providers = providerData.GetAll();
			var provider = providers.FirstOrDefault();
			provider.Name = "Google";
			bool operation  = providerData.Update(provider);			
			Assert.IsTrue(operation);
		}
		
		[Test]
	    public void can_delete_a_service_record()			
		{
			var providers = providerData.GetAll();
			var provider = providers.FirstOrDefault();			
			providerData.Delete(provider);						
			Provider p = providerData.Get (provider.Id);
			Assert.IsNull(p);
		}
	}
}