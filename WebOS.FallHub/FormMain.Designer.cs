namespace WebOS.FallHub
{
    partial class FormMain
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
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.customTabControl1 = new MySQL.Controls.FlatTabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customTabControl1
            // 
            this.customTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTabControl1.BackgroundColor = System.Drawing.Color.Transparent;
            this.customTabControl1.CanCloseLastTab = false;
            this.customTabControl1.CanReorderTabs = true;
            this.customTabControl1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.customTabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.customTabControl1.HideWhenEmpty = false;
            this.customTabControl1.ItemPadding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.customTabControl1.Location = new System.Drawing.Point(-3, 0);
            this.customTabControl1.MaxTabSize = 250;
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.ShowCloseButton = true;
            this.customTabControl1.ShowFocusState = true;
            this.customTabControl1.Size = new System.Drawing.Size(747, 531);
            this.customTabControl1.TabIndex = 4;
            this.customTabControl1.TabStyle = MySQL.Controls.FlatTabControl.TabStyleType.TopTransparent;
            this.customTabControl1.TabClosing += new System.EventHandler<MySQL.Controls.TabClosingEventArgs>(this.customTabControl1_TabClosing);
            this.customTabControl1.TabClosed += new System.EventHandler<MySQL.Controls.TabClosedEventArgs>(this.customTabControl1_TabClosed);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.关闭全部ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 70);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            // 
            // 关闭全部ToolStripMenuItem
            // 
            this.关闭全部ToolStripMenuItem.Name = "关闭全部ToolStripMenuItem";
            this.关闭全部ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.关闭全部ToolStripMenuItem.Text = "关闭全部";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(742, 528);
            this.Controls.Add(this.customTabControl1);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(2, 27, 2, 1);
            this.Text = "FallHub Browser";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MySQL.Controls.FlatTabControl customTabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭全部ToolStripMenuItem;
       // private UIs.CustomTabControl customTabControl1;

    }
}

