using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.Utilities
{
    /*=============================================================================
*
*	(C) Copyright 2007, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*	All rights reserved.
*	The code and information is provided "as-is" without waranty of any kind,
*	either expresed or implied.
*
*-----------------------------------------------------------------------------
*	History:
*		18/02/2007	Michael Carlisle				Version 1.0
*=============================================================================
*/
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;

    namespace CodeKing.Native
    {
        public static class Win32
        {
            /// <summary>
            /// The struct used to pass the Glass margins to the Win32 API
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct MARGINS
            {
                public int Left;
                public int Right;
                public int Top;
                public int Bottom;
            }
            /// <summary>
            /// The API used to extend the GLass margins into the client area
            /// </summary>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

            /// <summary>
            /// Determins whether the Desktop Windows Manager is enabled
            /// and can therefore display Aero 
            /// </summary>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern bool DwmIsCompositionEnabled();
        }
    }

}
