using System;
using System.Linq;
using NUnit.Framework;
using PasswordUsher.Core;
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
	}
}