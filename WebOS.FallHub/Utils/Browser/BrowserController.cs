using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Utils
{
    /// <summary>
    /// browser view collection manager
    /// </summary>
    public  class BrowserController
    {
        private static List<UIs.ucBrowserView> _browserViewlist = new List<UIs.ucBrowserView>();
        /// <summary>
        /// mananges all the browser tabpages
        /// </summary>
        public static List<UIs.ucBrowserView> BrowserViewlist
        {
            get { return BrowserController._browserViewlist; }
            private set { BrowserController._browserViewlist = value; }
        }

        /// <summary>
        /// if you want to add a new tabcontrolpage for a new WebPage,this method help you 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static UIs.ucBrowserView AddNewWebView(string url="about:blank")
        {
            UIs.ucBrowserView browserView =new UIs.ucBrowserView(url);
            if (browserView != null)
            {
                _browserViewlist.Add(browserView);
                BrowActionController.GetInstance().OnBrowStaChanged(new BrowserStaChangeArgs(BrowSTACommand.NewWindow, "", browserView));
            }
            return browserView;
        }

        /// <summary>
        /// remove a tabpage from tabcontrol ,you need to remove this specified browserview too
        /// </summary>
        /// <param name="bv"></param>
        public static void RemoveWebView( UIs.ucBrowserView bv)
        {
            if (bv != null)
            {
                _browserViewlist.Remove(bv);
                bv.Dispose();
            }
        }

        public static void RemoveWebViewByGuid(string uid)
        {
            var bv=GetWebViewByGUID(uid);
            RemoveWebView(bv);
        }

        public static  bool Contains(UIs.ucBrowserView bv)
        {
            bool ret = false;
            ret=_browserViewlist.Contains(bv);
            return ret;
        }
        /// <summary>
        /// get object by uid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static UIs.ucBrowserView GetWebViewByGUID(string uid)
        {
            var ret=_browserViewlist.FirstOrDefault(c => c.BrowserUniqueID == uid);
            return ret;
        }
    }
}
