using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub
{
   /// <summary>
   /// browser state change event args
   /// </summary>
    public class BrowserStaChangeArgs:EventArgs
    {
        BrowSTACommand _command;

        public BrowSTACommand Command
        {
            get { return _command; }
            set { _command = value; }
        }
        object _tag;

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        string _tarTabUid;
        /// <summary>
        /// specified browser id
        /// </summary>
        public string TarTabUid
        {
            get { return _tarTabUid; }
            set { _tarTabUid = value; }
        }

        public BrowserStaChangeArgs(BrowSTACommand cmd, string uidTab, object tag = null)
        {
            _command = cmd;
            _tag = tag;
            _tarTabUid = uidTab;
        }
    }
}
