using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebOS.Utilities
{
    /// <summary>
    /// text helper,regex,encoding,etc
    /// </summary>
    public class TextManager
    {
        public static  bool IsUrl(string url)
        {
            var ret = false ;
            if (!url.Contains(' '))
            {
                ret = url.Contains(".");
                if (!ret) {
                    if (url.StartsWith("http:")||url.StartsWith("https:")) {
                        ret = true;
                    }
                }
            }
            return ret;
            
        }

        public static bool IsEmail(string email) {

            var ret = false;
            string reg = @"^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$";
            Regex re = new Regex(reg);
            ret = re.IsMatch(email);
            return ret;
        }

        public static  string UrlEncode(string url)
        {
            byte[] bs = Encoding.GetEncoding("utf-8").GetBytes(url);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bs.Length; i++)
            {
                if (bs[i] < 128)
                    sb.Append((char)bs[i]);
                else
                {
                    sb.Append("%" + bs[i++].ToString("x").PadLeft(2, '0'));
                    sb.Append("%" + bs[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return sb.ToString();
        } 

    }
}
