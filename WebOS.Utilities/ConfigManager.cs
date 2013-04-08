using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WebOS.Utilities
{
    public class ConfigManager
    {

        ///// <summary>
        ///// 返回appstring
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static string GetAppString(string key)
        //{
        //    if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
        //    {
        //        return ConfigurationManager.AppSettings[key];
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// 获取AppSettings
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static string GetAppString(string key, string defaultValue)
        //{
        //    if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
        //    {
        //        return ConfigurationManager.AppSettings[key];
        //    }
        //    return defaultValue;
        //}

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

       
        



    }
}
