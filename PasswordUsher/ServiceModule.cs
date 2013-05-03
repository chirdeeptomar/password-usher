using Ninject.Modules;
using PasswordUsher.Service.Contracts;
using PasswordUsher.Service.Impl;

namespace PasswordUsher
{
	public class ServiceModule : NinjectModule
	{
		public override void Load ()
		{
			Bind<IProviderService>().To<ProviderService>().InSingletonScope();
			Bind<IAccountService>().To<AccountService>().InSingletonScope();			
		}
	}
}

