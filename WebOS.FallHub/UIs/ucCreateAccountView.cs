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
    public partial class ucCreateAccountView : UserControl
    {
        public ucCreateAccountView()
        {
            InitializeComponent();

            //-----
            this.tbMail.LostFocus += delegate
            {
                FormatCheck();
            };
            this.tbPsw.LostFocus += delegate
            {
                FormatCheck();
            };
            this.tbPsw1.LostFocus += delegate
            {
                FormatCheck();
            };
        }

        private bool FormatCheck()
        {
            var ret = true;
            if (!Utilities.TextManager.IsEmail(this.tbMail.Text))
            {
                this.lbmail.Text = "Illegal email!";
                this.lbmail.Show();
                ret = false;
            }
            else
            {
                this.lbmail.Text = "";
            }

            if (this.tbPsw.Text.Length < 6)
            {
                this.lbPsw.Text = "At least 6 char";
                this.lbPsw.Show();
                ret = false;
            }
            else
            {
                this.lbPsw.Text = "";
            }
            if (this.tbPsw1.Text != this.tbPsw.Text)
            {
                this.lbPsw1.Text = "Repeat not equal";
                this.lbPsw1.Show();
                ret = false;
            }
            else
            {
                this.lbPsw1.Text = "";
            }
            return ret;
        }


        //return to login form
        private void btnBack_Click(object sender, EventArgs e)
        {
            var pLoc = this.Location;
            var pForm = this.TopLevelControl;
            this.TopLevelControl.Controls.Clear();
            ucLoginView cv = new ucLoginView();
            cv.Location = pLoc;
            pForm.Controls.Add(cv);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (FormatCheck())
            {
                var logid = this.tbMail.Text.Trim();
                var despsw = Utilities.DESCrypt.Encrypt(this.tbPsw.Text.Trim(), Core.ServerInfo.DesKey);
                this.btnBack.Enabled = false;
                this.btnCreate.Enabled = false;
                Thread td = new Thread(new ParameterizedThreadStart(
                        delegate
                        {
                            var ar =Utils.SysController.GetInstance().MySelf.Create(logid, despsw);
                            if (ar != null && ar.Instance == 1)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    this.lbInfo.Text = "Success！";
                                    this.btnCreate.Enabled = true;
                                    this.btnBack.Enabled = true;
                                }));
                            }
                        }
                    ));
                td.IsBackground = true;
                td.Start();

            }
        }
    }
}
