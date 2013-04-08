using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Utils
{
    /// <summary>
    /// system state ,event change controller
    /// 2012-12-15 14:26:24
    /// </summary>
    public class SysController
    {
        Core.Account _mySelf = new Core.Account();
        //current user info
        public Core.Account MySelf
        {
            get { return _mySelf; }
            set { _mySelf = value; }
        }
        private SysController()
        {
        }

        private static SysController Instance = null;
        public static SysController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SysController();
            }
            return Instance;
        }

        public delegate void SysChangeHandler(object sender, SysChangeEventArgs e);
        public event SysChangeHandler SysChangeChanged;
        /// <summary>
        /// trigger sys event 
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnSysChangeChanged(SysChangeEventArgs e)
        {
            if (SysChangeChanged != null)
            {
                SysChangeChanged(this, e);
            }
        }





        /// <summary>
        /// load localdata when app startup
        /// </summary>
        public void AppStartInit()
        {
            Core.LocalData.LoadServerConfig();
            Core.LocalData.LoadUrls();
            

        }
        /// <summary>
        /// auto login by local data 
        /// </summary>
        public void AutoLogin()
        {
            var person=Core.LocalData.LoadLastLoginLocalUser();
            _mySelf.LoginID = person.loginid;
            _mySelf.Password = person.psw;
            _mySelf.UserName = person.name;
            _mySelf.Login();
        }

    }
}
