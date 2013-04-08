using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WebOS.FallHub.Utils
{
    static class NativeMethods
    {
        public enum OLECMDF
        {
            // Fields
            OLECMDF_DEFHIDEONCTXTMENU = 0x20,
            OLECMDF_ENABLED = 2,
            OLECMDF_INVISIBLE = 0x10,
            OLECMDF_LATCHED = 4,
            OLECMDF_NINCHED = 8,
            OLECMDF_SUPPORTED = 1
        }

        public enum OLECMDID
        {
            // Fields
            OLECMDID_PAGESETUP = 8,
            OLECMDID_PRINT = 6,
            OLECMDID_PRINTPREVIEW = 7,
            OLECMDID_PROPERTIES = 10,
            OLECMDID_SAVEAS = 4,
            // OLECMDID_SHOWSCRIPTERROR = 40
        }
        public enum OLECMDEXECOPT
        {
            // Fields
            OLECMDEXECOPT_DODEFAULT = 0,
            OLECMDEXECOPT_DONTPROMPTUSER = 2,
            OLECMDEXECOPT_PROMPTUSER = 1,
            OLECMDEXECOPT_SHOWHELP = 3
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]

        public static extern int SendMessage(

        IntPtr hWnd,　　　// handle to destination window 

        int Msg,　　　 // message 

        int wParam,　// first message parameter 

        int lParam // second message parameter 

        );

        private static  int _paintFrozen;
        /// <summary>
        /// winform text status flash control method
        /// </summary>
        /// <param name="toFreezeControl"></param>
        /// <param name="isToFreeze"></param>
        public static  void FreezePainting(Control toFreezeControl, bool isToFreeze)
        {
            if (null == toFreezeControl)
                throw new ArgumentNullException("toFreezeControl error");

            if (isToFreeze && toFreezeControl.IsHandleCreated && toFreezeControl.Visible)
            {
                if (0 == _paintFrozen++)
                {
                    NativeMethods.SendMessage(toFreezeControl.Handle, 11, 0, 0);
                }
            }
            if (!isToFreeze)
            {
                if (0 == _paintFrozen) return;
                if (0 == --_paintFrozen)
                {
                    NativeMethods.SendMessage(toFreezeControl.Handle,11, 1, 0);
                    toFreezeControl.Invalidate(true);
                }
            }
        }




    }
}
