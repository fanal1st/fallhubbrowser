using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Core
{
    /// <summary>
    /// account manager,reg,signin,logout
    /// </summary>
    public class Account
    {
        string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        string _loginID;

        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }
        string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Token { get; set; }

        public UserProfile UserProfile { get; set; }

        /// <summary>
        /// create a account
        /// </summary>
        /// <param name="logid"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public dynamic Create(string logid, string psw)
        {
            dynamic body = new { sLoginID = logid, sPsw = psw, dCreateTime = DateTime.Now };
            var jsData = Newtonsoft.Json.JsonConvert.SerializeObject(body);
            string err = string.Empty;
            var ar = Utilities.RequestManager.RequestByRest(LocalData.RemoteUrls["signup"], jsData, Utilities.RequestManager.MethodType.POST, "text/json", Encoding.UTF8, out err);
            dynamic outar = Newtonsoft.Json.JsonConvert.DeserializeObject(ar);
            if (outar.Instance == 1)
            {
                Token = outar.Info;
                _loginID = logid;
                _password = psw;
                LocalData.SaveLoginInfo(new { name = _userName, loginid = _loginID, psw = psw });
                //  UserProfile = new Config(logid);
            }
            return outar;
        }


        /// <summary>
        /// user login ,used in manual login
        /// </summary>
        /// <param name="logid"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public dynamic Login(string logid, string psw)
        {
            string err = string.Empty;
            var ar = Utilities.RequestManager.RequestByRest(string.Format(LocalData.RemoteUrls["login"], logid, psw), "", Utilities.RequestManager.MethodType.GET, "text/json", Encoding.UTF8, out err);
            dynamic outar = Newtonsoft.Json.JsonConvert.DeserializeObject(ar);
            if (outar != null && outar.Instance == 1)
            {
                Token = outar.Info;
                _loginID = logid;
                _password = psw;
                LocalData.SaveLoginInfo(new { name = _userName, loginid = _loginID, psw = psw });
                UserProfile = new UserProfile(logid);
            }
            else
            {
                Utils.SysController.GetInstance().OnSysChangeChanged(new Utils.SysChangeEventArgs()
                {
                    SystemCommand = SysEventCMD.Error,
                    Desc = err,
                    Title = "Login Erorr"
                });
            }
            return outar;
        }


        /// <summary>
        /// login and save info to localdb,used in auto login
        /// </summary>
        /// <returns></returns>
        public dynamic Login()
        {
            string err = string.Empty;
            var ar = Utilities.RequestManager.RequestByRest(string.Format(LocalData.RemoteUrls["login"], _loginID, _password), "", Utilities.RequestManager.MethodType.GET, "text/json", Encoding.UTF8, out err);
            dynamic outar = Newtonsoft.Json.JsonConvert.DeserializeObject(ar);
            if (outar != null && outar.Instance == 1)
            {
                Token = outar.Info;
                LocalData.SaveLoginInfo(new { name = _userName, loginid = _loginID, psw = _password });
                UserProfile = new UserProfile(_loginID);
            }
            else
            {
                Utils.SysController.GetInstance().OnSysChangeChanged(new Utils.SysChangeEventArgs()
                {
                    SystemCommand = SysEventCMD.Error,
                    Desc = err,
                    Title = "Login Erorr"
                });
            }
            return outar;
        }

    }
}
