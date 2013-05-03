using System;
using NUnit.Framework;
using System.Security.Cryptography;

namespace PasswordUsher.Core.Tests
{
	[TestFixture]
	public class EncryptionTests
	{
		[Test]
		public void can_encrypt_text()
		{		
			string original = "Lazy brown fox jumped over the fence.";
			try
            {
				string encrypted = Encryptor.Encrypt<RijndaelManaged>(original, ConfigHelper.EncyptionPassword, ConfigHelper.EncyptionKey);

                    // Decrypt the bytes to a string.
				string roundtrip = Encryptor.Decrypt<RijndaelManaged>(encrypted, ConfigHelper.EncyptionPassword, ConfigHelper.EncyptionKey);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip);
                    
                    Assert.That(encrypted.ToString().Equals(roundtrip.ToString()));
              
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
			
		}
	}
}

