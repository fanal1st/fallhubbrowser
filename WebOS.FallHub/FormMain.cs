using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebOS.FallHub
{
    public partial class FormMain : BaseForm
    {
        public FormMain()
        {
            InitializeComponent();
            Utils.BrowActionController.GetInstance().BrowStaChanged += new Utils.BrowActionController.BrowStaChangeHandler(FormMain_BrowStaChanged);
            //tab selected event
            this.customTabControl1.Selected += delegate
            {
                //add a new tab web page 
                if (this.customTabControl1.SelectedTab.Text == "*New")
                {
                    Utils.BrowserController.AddNewWebView();
                }
                //when selected change zhe current title for mian window
                this.Text = this.customTabControl1.SelectedTab.ToolTipText;
            };
        }

        #region browser signal to main form event

        void FormMain_BrowStaChanged(object sender, BrowserStaChangeArgs e)
        {
            switch (e.Command)
            {
                case BrowSTACommand.NewWindow:
                    NewTabWindow(e);
                    break;
                case BrowSTACommand.TitleChanged:
                    TabPageTitleChange(e);
                    break;
                default:
                    break;
            }
        }

        private void NewTabWindow(BrowserStaChangeArgs e)
        {
            TabPage tp = new TabPage("New Window");
            tp.BorderStyle = BorderStyle.FixedSingle;
            tp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customTabControl1.TabPages.Add(tp);//.Insert(this.customTabControl1.TabPages.Count - 1, tp);
            this.customTabControl1.TabPages.RemoveAt(this.customTabControl1.TabPages.Count - 2);
            CreateNewStarTab();
            this.customTabControl1.SelectedTab = tp;
            var webView = (UIs.ucBrowserView)e.Tag;
            if (webView != null)
            {
                webView.Dock = DockStyle.Fill;
                tp.Controls.Add(webView);
                tp.Tag = webView.BrowserUniqueID;
            }
        }
        /// <summary>
        /// close a tab control page
        /// </summary>
        /// <param name="tp"></param>
        private void RemoveFromTabControl(TabPage tp)
        {
            this.customTabControl1.TabPages.Remove(tp);
            Utils.BrowserController.RemoveWebViewByGuid(tp.Tag.ToString());
        }

        private void TabPageTitleChange(BrowserStaChangeArgs e)
        {
            var webview = Utils.BrowserController.GetWebViewByGUID(e.TarTabUid);
            var list = this.customTabControl1.TabPages;
            foreach (TabPage p in list)
            {
                if (p.Controls.Contains(webview) && this.customTabControl1.SelectedTab == p)
                {
                    var title = e.Tag.ToString();
                    p.Text = title.Length < 10 ? title : title.Substring(0, 10) + "..";
                    this.Text = title;
                    p.ToolTipText = title;
                    break;
                }
            }

        }

        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {

            CreateNewStarTab();
            Utils.BrowserController.AddNewWebView();
            //if auto login failed ,lunch the loginform
            if (string.IsNullOrEmpty(Utils.SysController.GetInstance().MySelf.Token))
            {
                //UIs.LoginForm loginForm = new UIs.LoginForm();
                //loginForm.ShowDialog(this);
            }
        }

        private void CreateNewStarTab()
        {
            var pg = new TabPage("*New") { };
            this.customTabControl1.TabPages.Add(pg);

        }

        private void customTabControl1_TabClosing(object sender, MySQL.Controls.TabClosingEventArgs e)
        {

        }

        private void customTabControl1_TabClosed(object sender, MySQL.Controls.TabClosedEventArgs e)
        {
            Utils.BrowserController.RemoveWebViewByGuid(e.page.Tag.ToString());
        }








    }
}
