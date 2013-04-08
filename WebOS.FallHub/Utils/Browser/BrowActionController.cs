using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Utils
{
    /// <summary>
    /// sys state controller
    /// 2012-11-4 22:00:47
    /// </summary>
    internal class BrowActionController
    {
        private BrowActionController()
        {
        }

        private  static BrowActionController Instance = null;
        public static BrowActionController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BrowActionController();
            }
            return Instance;
        }

        public delegate void BrowStaChangeHandler(object sender, BrowserStaChangeArgs e);
        public event BrowStaChangeHandler BrowStaChanged;

        public virtual void OnBrowStaChanged(BrowserStaChangeArgs e)
        {
            if (BrowStaChanged != null)
            {
                BrowStaChanged(this, e);
            }
        }

        string _homePage = "http://www.google.com";

        public string HomePage
        {
            get { return _homePage; }
            set { _homePage = value; }
        }
        string _searchPage = "http://www.google.com/search?newwindow=1&safe=strict&site=&source=hp&q=";

        public string SearchPage
        {
            get { return _searchPage; }
            set { _searchPage = value; }
        }

        


    }
}
