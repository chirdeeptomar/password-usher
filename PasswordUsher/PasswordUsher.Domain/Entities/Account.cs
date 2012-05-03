using System;

namespace PasswordUsher.Domain.Entities
{
	public class Account
	{		
		public Int64 Id { get; set; }
		
		public string Name { get; set; }
		
		public string Password { get; set; }		
	}
}

