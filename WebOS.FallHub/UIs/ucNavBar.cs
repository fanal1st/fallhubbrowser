using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebOS.FallHub.UIs
{
    public partial class ucNavBar : UserControl
    {
        public ucNavBar()
        {
            InitializeComponent();

            //btn event bind
            this.tsbBack.Click += new EventHandler(tsb_Click);
            this.tsbComment.Click += new EventHandler(tsb_Click);
            this.tsbTagIt.Click += new EventHandler(tsb_Click);
            this.tsbForward.Click += new EventHandler(tsb_Click);
            this.tsbFresh.Click += new EventHandler(tsb_Click);
            this.tsbGo.Click += new EventHandler(tsb_Click);
            this.tsbLike.Click += new EventHandler(tsb_Click);
            this.tsbLogin.Click += new EventHandler(tsb_Click);
            this.tsbHome.Click += new EventHandler(tsb_Click);
            this.lbUserName.Click += (o, args) =>
            {
                var cmdCode = this.lbUserName.Tag.ToString();
                eventTrigger(cmdCode);
            };
            this.tsbWebView.Click += delegate {
                var code = "MutiView";
                if (this.tsbWebView.CheckState == CheckState.Checked)
                {
                    code = "SingleView";
                    this.tsbWebView.CheckState = CheckState.Unchecked;
                    this.tsbWebView.ToolTipText = "SingleView";
                }
                else {
                    this.tsbWebView.CheckState = CheckState.Checked;
                    this.tsbWebView.ToolTipText = "MutiView";
                }
                eventTrigger(code);
            };
            this.tbUrl.KeyDown += (o, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    var cmdCode = this.tbUrl.Tag.ToString();
                    eventTrigger(cmdCode);
                }
            };

            this.tbUrl.DoubleClick += delegate { this.tbUrl.Focus(); this.tbUrl.SelectAll(); };
            
        }

        private void ucNavBar_Load(object sender, EventArgs e)
        {

        }

        string _currentUrl = "about:blank";

        public string CurrentUrl
        {
            get
            {
                _currentUrl = this.tbUrl.Text.Trim();
                return _currentUrl;
            }
            set
            {
                _currentUrl = value;
                this.tbUrl.Text = _currentUrl;
            }
        }

        void tsb_Click(object sender, EventArgs e)
        {
            var tsb = sender as ToolStripButton;
            var cmdCode = tsb.Tag.ToString();
            eventTrigger(cmdCode);
        }

        private void eventTrigger(string cmdCode)
        {
            var cmd = (NavbarCommand)Enum.Parse(typeof(NavbarCommand), cmdCode);
            OnNavbarEventHanppend(new NavbarEventArgs() { Cmd = cmd, Url = CurrentUrl });
            switch (cmd)
            {
                case  NavbarCommand.NavGo:
                    tsbStopState();
                    //pic to loading^^^^ 
                    break;
                case NavbarCommand.Stop:
                    tsbGoState();
                    break;
                case NavbarCommand.Login:
                    LoginForm lf = new LoginForm();
                    lf.ShowDialog(this);
                    break;
                case NavbarCommand.Comment:
                    CommentForm cf = new CommentForm();
                    cf.ShowDialog(this);
                    break;
                case NavbarCommand.Tag:
                    TagForm tf = new TagForm();
                   // tf.Location=
                    tf.ShowDialog(this);
                    break;
                case NavbarCommand.Like:
                    LikeSplash ls = new LikeSplash();
                    ls.ShowDialog(this);
                    break;
            }
           

        }

        /// <summary>
        /// change to go state,when nav stopped
        /// </summary>
        public void tsbGoState()
        {
            this.tsbGo.Tag = "NavGo";
            this.tsbGo.Text = "Go";
        }
        /// <summary>
        /// change to stop state,when nav starting
        /// </summary>
        public void tsbStopState()
        {
            this.tsbGo.Tag = "Stop";
            this.tsbGo.Text = "Stop";
        }


        protected virtual void OnNavbarEventHanppend(NavbarEventArgs e)
        {
            if (NavbarEventHappend != null)
            {
                NavbarEventHappend(this, e);
            }
        }

        public event NavbarEventHandler NavbarEventHappend;

        public delegate void NavbarEventHandler(object sender, NavbarEventArgs e);


    }




}
