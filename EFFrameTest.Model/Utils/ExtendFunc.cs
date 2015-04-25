using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.Security.Cryptography;

namespace EFFrameTest2.Model.Utils
{
    public static class ExtendFunc
    {
        public static string Md5(this string input)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            //byte[] buffer=

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <encrypt.Length; i++)
            {
                sb.Append(encrypt[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
