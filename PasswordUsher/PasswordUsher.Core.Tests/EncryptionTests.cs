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
                // Create a new instance of the Rijndael
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (Rijndael myRijndael = Rijndael.Create())
                {
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = CryptManager.EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

                    // Decrypt the bytes to a string.
                    string roundtrip = CryptManager.DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip);
                    
                    Assert.That(encrypted.ToString().Equals(roundtrip.ToString()));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
			
		}
	}
}

