namespace WebOS.FallHub.UIs
{
    partial class ucBrowserView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                this.webBrowser.Dispose();
                System.GC.Collect();
                
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbMsgState = new System.Windows.Forms.Label();
            this.webBrowser = new WebOS.FallHub.ExtendedWebBrowser();
            this.webBrowserComment = new System.Windows.Forms.WebBrowser();
            this.ucNavBar1 = new WebOS.FallHub.UIs.ucNavBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbMsgState);
            this.splitContainer1.Panel1.Controls.Add(this.webBrowser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.webBrowserComment);
            this.splitContainer1.Size = new System.Drawing.Size(801, 543);
            this.splitContainer1.SplitterDistance = 612;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbMsgState
            // 
            this.lbMsgState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMsgState.AutoSize = true;
            this.lbMsgState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbMsgState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMsgState.Location = new System.Drawing.Point(0, 527);
            this.lbMsgState.Name = "lbMsgState";
            this.lbMsgState.Size = new System.Drawing.Size(2, 14);
            this.lbMsgState.TabIndex = 1;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(612, 543);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            // 
            // webBrowserComment
            // 
            this.webBrowserComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserComment.Location = new System.Drawing.Point(0, 0);
            this.webBrowserComment.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserComment.Name = "webBrowserComment";
            this.webBrowserComment.ScriptErrorsSuppressed = true;
            this.webBrowserComment.Size = new System.Drawing.Size(185, 543);
            this.webBrowserComment.TabIndex = 0;
            this.webBrowserComment.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // ucNavBar1
            // 
            this.ucNavBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucNavBar1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucNavBar1.CurrentUrl = "";
            this.ucNavBar1.ForeColor = System.Drawing.Color.Transparent;
            this.ucNavBar1.Location = new System.Drawing.Point(0, 0);
            this.ucNavBar1.Name = "ucNavBar1";
            this.ucNavBar1.Size = new System.Drawing.Size(801, 24);
            this.ucNavBar1.TabIndex = 0;
            this.ucNavBar1.Tag = "profile";
            // 
            // ucBrowserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ucNavBar1);
            this.Name = "ucBrowserView";
            this.Size = new System.Drawing.Size(801, 569);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucNavBar ucNavBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ExtendedWebBrowser webBrowser;
        private System.Windows.Forms.WebBrowser webBrowserComment;
        private System.Windows.Forms.Label lbMsgState;

    }
}
