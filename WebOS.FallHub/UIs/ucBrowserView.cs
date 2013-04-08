using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebOS.FallHub.Utils;
using System.Threading;

namespace WebOS.FallHub.UIs
{
    public partial class ucBrowserView : UserControl
    {
        string _browserUniqueID = Guid.NewGuid().ToString();

        public string BrowserUniqueID
        {
            get { return _browserUniqueID; }
            set { _browserUniqueID = value; }
        }

        /// <summary>
        /// init by url for default page
        /// </summary>
        /// <param name="url"></param>
        public ucBrowserView(string url)
            : this()
        {
            if (Utilities.TextManager.IsUrl(url))
            {
                webBrowser.Navigate(url);
            }
        }

        public ucBrowserView()
        {
            InitializeComponent();
            this.ucNavBar1.NavbarEventHappend += new ucNavBar.NavbarEventHandler(ucNavBar1_NavbarEventHappend);
            this.webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            this.webBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser_Navigated);
            this.webBrowser.Navigating += new WebBrowserNavigatingEventHandler(webBrowser_Navigating);
            this.webBrowser.StartNewWindow += new EventHandler<Utils.BrowserExtendedNavigatingEventArgs>(webBrowser_StartNewWindow);
            this.webBrowser.ExTitleChanged += new EventHandler<STAChangeEventArgs>(webBrowser_ExTitleChanged);

        }



        #region webBrowser events

        /// <summary>
        /// browser title,browser status text change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webBrowser_ExTitleChanged(object sender, STAChangeEventArgs e)
        {
            ExtendedWebBrowser ewb = sender as ExtendedWebBrowser;
            switch (e.Command)
            {
                case BrowSTACommand.TitleChanged:
                    BrowActionController.GetInstance().OnBrowStaChanged(new BrowserStaChangeArgs(BrowSTACommand.TitleChanged, _browserUniqueID, e.Title));
                    break;
                case BrowSTACommand.StatusChanged:
                    this.lbMsgState.Text = e.Title;
                    break;
            }
        }

        /// <summary>
        /// popup new window in custom tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webBrowser_StartNewWindow(object sender, Utils.BrowserExtendedNavigatingEventArgs e)
        {
            // Here we do the pop-up blocker work

            // Note that in Windows 2000 or lower this event will fire, but the
            // event arguments will not contain any useful information
            // for blocking pop-ups.

            // There are 4 filter levels.
            // None: Allow all pop-ups
            // Low: Allow pop-ups from secure sites
            // Medium: Block most pop-ups
            // High: Block all pop-ups (Use Ctrl to override)

            // We need the instance of the main form, because this holds the instance
            // to the WindowManager.

            if (!Utils.BrowserController.Contains(this))
                return;

            // Allow a popup when there is no information available or when the Ctrl key is pressed
            bool allowPopup = (e.NavigationContext == UrlContext.None) || ((e.NavigationContext & UrlContext.OverrideKey) == UrlContext.OverrideKey);

            if (!allowPopup)
            {
                // Give None, Low & Medium still a chance.
                switch (SettingsHelper.Current.FilterLevel)
                {
                    case PopupBlockerFilterLevel.None:
                        allowPopup = true;
                        break;
                    case PopupBlockerFilterLevel.Low:
                        // See if this is a secure site
                        if (this.webBrowser.EncryptionLevel != WebBrowserEncryptionLevel.Insecure)
                            allowPopup = true;
                        else
                            // Not a secure site, handle this like the medium filter
                            goto case PopupBlockerFilterLevel.Medium;
                        break;
                    case PopupBlockerFilterLevel.Medium:
                        // This is the most dificult one.
                        // Only when the user first inited and the new window is user inited
                        if ((e.NavigationContext & UrlContext.UserFirstInited) == UrlContext.UserFirstInited && (e.NavigationContext & UrlContext.UserInited) == UrlContext.UserInited)
                            allowPopup = true;
                        break;
                }
            }

            if (allowPopup)
            {
                // Check wheter it's a HTML dialog box. If so, allow the popup but do not open a new tab
                if (!((e.NavigationContext & UrlContext.HtmlDialog) == UrlContext.HtmlDialog))
                {
                    ExtendedWebBrowser ewb = BrowserController.AddNewWebView().webBrowser;
                    // The (in)famous application object
                    e.AutomationObject = ewb.Application;
                }
            }
            else
                // Here you could notify the user that the pop-up was blocked
                e.Cancel = true;
        }


        
        void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.ucNavBar1.tsbStopState();
            
            
        }
        //index url,notify right panel  redirecting to fallhub liveweb
        void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Thread td = new Thread(new ParameterizedThreadStart(delegate
            {
                var ar = Core.Weblink.WebIndex(this.webBrowser.Url.ToString());
                if (ar != null && ar.Instance >= 0)
                {
                    string url = ar.Info;
                    if (this.webBrowserComment.Url!=null&&!this.webBrowserComment.Url.ToString().Equals(url))
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            // notify right browser 
                            webBrowserComment.Navigate(url);
                        }));
                    }
                }
            })) { IsBackground = true };
            td.Start();
            if (this.webBrowser.Url != null)
            {
                this.ucNavBar1.CurrentUrl = this.webBrowser.Url.ToString();
            }
        }
    

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.ucNavBar1.tsbGoState();

        }

        #endregion

        void ucNavBar1_NavbarEventHappend(object sender, NavbarEventArgs e)
        {
            switch (e.Cmd)
            {
                case NavbarCommand.NavGo:
                    if (Utilities.TextManager.IsUrl(e.Url))
                    {
                        var url = Utilities.TextManager.UrlEncode(e.Url);
                        this.webBrowser.Navigate(url);
                    }
                    else
                    {

                        var shUrl = Utils.BrowActionController.GetInstance().SearchPage + e.Url;
                        this.webBrowser.Navigate(shUrl);
                    }
                    break;
                case NavbarCommand.Back:
                    this.webBrowser.GoBack();
                    break;
                case NavbarCommand.Forward:
                    this.webBrowser.GoForward();
                    break;
                case NavbarCommand.Refresh:
                    this.webBrowser.Refresh();
                    break;
                case NavbarCommand.Stop:
                    this.webBrowser.Stop();
                    break;
                case NavbarCommand.Home:
                    this.webBrowser.GoHome();
                    break;
                case NavbarCommand.Like:
                    break;
                case NavbarCommand.Comment:
                    break;
                case NavbarCommand.Tag:
                    break;
                case NavbarCommand.Profile:
                    break;
                case NavbarCommand.Login:
                    break;
                case NavbarCommand.Logout:
                    break;
                case NavbarCommand.MutiView:
                    this.splitContainer1.Panel2Collapsed = true;
                    break;
                case NavbarCommand.SingleView:
                    this.splitContainer1.Panel2Collapsed = false;
                    break;
                default:
                    break;
            }
        }
    }
}
