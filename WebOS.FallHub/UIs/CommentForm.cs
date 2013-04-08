using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebOS.FallHub.UIs
{
    public partial class CommentForm : Form
    {
        public CommentForm()
        {
            InitializeComponent();
        }

        private void tbNote_TextChanged(object sender, EventArgs e)
        {
            var leftCount=this.tbNote.MaxLength - this.tbNote.Text.Length;
            this.lbCount.Text = leftCount.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.tbNote.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //--do sth send
        }
    }
}
