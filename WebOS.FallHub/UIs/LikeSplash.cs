using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WebOS.FallHub.UIs
{
    public partial class LikeSplash : Form
    {
        public LikeSplash()
        {
            InitializeComponent();
        }

        private void LikeSplash_Load(object sender, EventArgs e)
        {
            Thread td = new Thread(new ParameterizedThreadStart(delegate
            {
                //while (true)
                {
                    Thread.Sleep(1000);
                    this.Invoke(new MethodInvoker(delegate {
                        this.Close();
                    }));
                }
            }));
            td.IsBackground = true;
            td.Start();

        }
    }
}
