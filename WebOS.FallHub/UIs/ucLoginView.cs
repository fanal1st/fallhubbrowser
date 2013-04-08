using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WebOS.FallHub.UIs
{
    public partial class ucLoginView : UserControl
    {
        public ucLoginView()
        {
            InitializeComponent();
        }
        //nav to signup panel
        private void lbCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var pLoc = this.Location;
            var pForm = this.TopLevelControl;
            this.TopLevelControl.Controls.Clear();
            ucCreateAccountView cv = new ucCreateAccountView();
            cv.Location = pLoc;
            pForm.Controls.Add(cv);
        }

        //login click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var logid = this.tbMail.Text.Trim();
            var despsw = Utilities.DESCrypt.Encrypt(this.tbPsw.Text.Trim(), Core.ServerInfo.DesKey);
            this.btnLogin.Enabled = false;
            Thread td = new Thread(new ParameterizedThreadStart(
                    delegate
                    {
                        var ar = Utils.SysController.GetInstance().MySelf.Login(logid, despsw);
                        if (ar != null && ar.Instance == 1)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                this.btnLogin.Enabled = true;
                            }));
                        }
                    }
                ));
            td.IsBackground = true;
            td.Start();
        }

        //init form
        private void ucLoginView_Load(object sender, EventArgs e)
        {
            //load local data
            var loginid = "";
            if (!string.IsNullOrEmpty(Utils.SysController.GetInstance().MySelf.LoginID))
            {
                loginid = Utils.SysController.GetInstance().MySelf.LoginID;
            }
            else
            {//get from coredata 
                var user = Core.LocalData.LoadLastLoginLocalUser();
                if (user != null)
                {
                    loginid = user.loginid;
                    Utils.SysController.GetInstance().MySelf.LoginID = loginid;
                    Utils.SysController.GetInstance().MySelf.Password = user.psw;
                    Utils.SysController.GetInstance().MySelf.UserName = user.name;
                }
            }

            Utils.SysController.GetInstance().MySelf.UserProfile = new Core.UserProfile(loginid);
            //
            this.tbMail.Text = loginid;
            
            this.cbRememberMe.Checked=Utils.SysController.GetInstance().MySelf.UserProfile.RememberMe;

            this.tbPsw.Text = Utils.SysController.GetInstance().MySelf.Password;
        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
