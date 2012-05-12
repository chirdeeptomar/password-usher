using System;
using PasswordUsher.Domain.Entities;
using NUnit.Framework;
using System.Linq;

namespace PasswordUsher.Core.Tests
{
	[TestFixture]
	public class AccountDataAccessTests
	{
		AccountDataAccess accountData;
		
		public AccountDataAccessTests ()
		{
			accountData = new AccountDataAccess();
		}
		
		[Test]
		public void can_add_an_account()
		{
			var account = new Account();
			account.Name = "chirdeep.tomar";
			account.Password = "zxxklklkfdas";
			account.ProviderId = 10;
			var result = accountData.Insert(account);
			Assert.IsTrue(result);
		}
		
		[Test]
		public void can_get_all_accounts()
		{
			var accounts = accountData.GetAll();
			Assert.Greater(accounts.Count(), 0);
		}
		
		[Test]
		public void can_update_an_account()
		{
			var account = accountData.GetAll().FirstOrDefault();
			account.ProviderId = 11;
			var result = accountData.Update(account);
			Assert.IsTrue(result);
		}
		
		[Test]
		public void can_delete_an_account()
		{
			var account = accountData.GetAll().FirstOrDefault();
			accountData.Delete(account);
			Assert.IsNull(accountData.Get(account.Id));
		}
		
		[Test]
		public void can_get_by_provider()
		{
			var accounts = accountData.GetByProvider(14);
			Assert.AreEqual(1, accounts.Count());
		}
	}
}

