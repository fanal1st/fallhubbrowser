using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Core
{
    public enum ConfigItem
    {
        RememberMe,

    }
    /// <summary>
    /// config object
    /// </summary>
    public class UserProfile
    {
        public bool RememberMe { get; set; }

        /// <summary>
        /// init userprofile by loginid
        /// </summary>
        /// <param name="loginid"></param>
        public UserProfile(string loginid)
        {
            var profile = Core.LocalData.LoadUserProfile(loginid);
            if (profile != null)
            {
                var key = profile.rememberme;
                if (key != null)
                {
                    RememberMe = (key == "1" ? true : false);
                }
            }
            else
            {
                //if can't find local profile ,then add it

            }
        }

        public UserProfile()
        {
            Core.LocalData.LoadConfig();
        }

        public void SaveConfigVal(ConfigItem it, object obj)
        {
            string configkey = "";
            switch (it)
            {
                case ConfigItem.RememberMe:
                    configkey = "rememberme";
                    break;
                default:
                    break;
            }
            LocalData.SaveConfigByKey(configkey, obj.ToString(), Utils.SysController.GetInstance().MySelf.LoginID);

        }

        public object GetConfigVal(ConfigItem it) {
            object ret = null;
            string configkey = "";
            switch (it)
            {
                case ConfigItem.RememberMe:
                    configkey = "rememberme";
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
