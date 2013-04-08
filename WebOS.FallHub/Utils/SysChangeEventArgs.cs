using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Utils
{
    public class SysChangeEventArgs:EventArgs
    {
        SysEventCMD _systemCommand;

        public SysEventCMD SystemCommand
        {
            get { return _systemCommand; }
            set { _systemCommand = value; }
        }
        dynamic _beforeChangedObj;

        public dynamic BeforeChangedObj
        {
            get { return _beforeChangedObj; }
            set { _beforeChangedObj = value; }
        }
        dynamic _afterChangedObj;

        public dynamic AfterChangedObj
        {
            get { return _afterChangedObj; }
            set { _afterChangedObj = value; }
        }

        string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        string _desc;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

    }
}
