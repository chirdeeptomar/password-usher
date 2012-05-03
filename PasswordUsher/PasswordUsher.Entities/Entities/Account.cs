using System;

namespace PasswordUsher.Domain.Entities
{
	public class Account
	{		
		public int Id {
			get;
			set;
		}
		
		public string Name {
			get;
			set;
		}
		
		public string Password {
			get;
			set;
		}
		
		public Provider Provider {
			get;
			set;
		}
	}
}

