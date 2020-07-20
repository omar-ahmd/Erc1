using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;

namespace Projet
{
   
    
        class Hashing
        {
         static string salt = "0edd29a061ae4a9e9942ec672cba517a";
            private static string HashString(string toHash)
            {
                using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider())
                {
                    byte[] dataToHash = Encoding.UTF8.GetBytes(toHash);
                    byte[] hashed = sha.ComputeHash(dataToHash);
                    return Convert.ToBase64String(hashed);
                }
            }
            public static string HashPassword(string password)
            {
                string combined = password + salt;
                return HashString(combined);
            }
            public static bool CheckPassword(string password, string hash)
            {
                return HashPassword(password) == hash;
            }

            public static void HashAndAdd(string user,string pass) 
            {
                
                string hash;
              




            }
        }
    }

