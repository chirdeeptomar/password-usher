using System;
using System.Configuration;

namespace PasswordUsher.Core
{
	public class ConfigHelper
	{
		public static string EncyptionKey {
			get { return System.Configuration.ConfigurationManager.AppSettings ["encryptionKey"];}
		}

		public static string EncyptionPassword {
			get { return System.Configuration.ConfigurationManager.AppSettings ["encryptionPassword"];}
		}
	}
}

