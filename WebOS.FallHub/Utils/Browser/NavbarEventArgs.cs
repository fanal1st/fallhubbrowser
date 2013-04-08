using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub
{
   
    /// <summary>
    /// nav bar 
    /// 2012年11月3日20:19:17
    /// </summary>
    public class NavbarEventArgs : EventArgs
    {
        NavbarCommand _cmd;

        public NavbarCommand Cmd
        {
            get { return _cmd; }
            set { _cmd = value; }
        }
        DateTime _happennedTime = DateTime.Now;

        public DateTime HappennedTime
        {
            get { return _happennedTime; }
            set { _happennedTime = value; }
        }
        string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}
