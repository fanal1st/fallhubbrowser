using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Utils
{
    public class STAChangeEventArgs:EventArgs
    {
        string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        BrowSTACommand _command;

        public BrowSTACommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public STAChangeEventArgs(string txt,BrowSTACommand cmd)
        {
            _command = cmd;
            _title = txt;
        }
    }
}
