using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ImbarkPlatform.Lib.Helper
{
    public class Encryption
    {
        public static string EncryptText( string text )
        {
            byte[] data = new byte[text.Length];
            int i = 0;
            foreach ( char c in text.ToCharArray() )
            {
                data[i] = Convert.ToByte(c);
                i++;
            }

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] result = md5.ComputeHash(data);
            return Convert.ToBase64String(result);
        }
    }
}
