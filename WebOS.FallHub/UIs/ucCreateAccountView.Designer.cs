namespace WebOS.FallHub.UIs
{
    partial class ucCreateAccountView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPsw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPsw1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbmail = new System.Windows.Forms.Label();
            this.lbPsw = new System.Windows.Forms.Label();
            this.lbPsw1 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPsw
            // 
            this.tbPsw.Location = new System.Drawing.Point(117, 50);
            this.tbPsw.MaxLength = 18;
            this.tbPsw.Name = "tbPsw";
            this.tbPsw.PasswordChar = '*';
            this.tbPsw.Size = new System.Drawing.Size(161, 21);
            this.tbPsw.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "password:";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(117, 16);
            this.tbMail.MaxLength = 200;
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(161, 21);
            this.tbMail.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "email:";
            // 
            // tbPsw1
            // 
            this.tbPsw1.Location = new System.Drawing.Point(117, 89);
            this.tbPsw1.MaxLength = 18;
            this.tbPsw1.Name = "tbPsw1";
            this.tbPsw1.PasswordChar = '*';
            this.tbPsw1.Size = new System.Drawing.Size(161, 21);
            this.tbPsw1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "repeat:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(114, 125);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Create(&C)";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(233, 124);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back(&B)";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbmail
            // 
            this.lbmail.AutoSize = true;
            this.lbmail.ForeColor = System.Drawing.Color.Red;
            this.lbmail.Location = new System.Drawing.Point(285, 19);
            this.lbmail.Name = "lbmail";
            this.lbmail.Size = new System.Drawing.Size(0, 12);
            this.lbmail.TabIndex = 20;
            this.lbmail.Visible = false;
            // 
            // lbPsw
            // 
            this.lbPsw.AutoSize = true;
            this.lbPsw.ForeColor = System.Drawing.Color.Red;
            this.lbPsw.Location = new System.Drawing.Point(285, 53);
            this.lbPsw.Name = "lbPsw";
            this.lbPsw.Size = new System.Drawing.Size(0, 12);
            this.lbPsw.TabIndex = 21;
            this.lbPsw.Visible = false;
            // 
            // lbPsw1
            // 
            this.lbPsw1.AutoSize = true;
            this.lbPsw1.ForeColor = System.Drawing.Color.Red;
            this.lbPsw1.Location = new System.Drawing.Point(285, 92);
            this.lbPsw1.Name = "lbPsw1";
            this.lbPsw1.Size = new System.Drawing.Size(0, 12);
            this.lbPsw1.TabIndex = 22;
            this.lbPsw1.Visible = false;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(147, 155);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 12);
            this.lbInfo.TabIndex = 23;
            // 
            // ucCreateAccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbPsw1);
            this.Controls.Add(this.lbPsw);
            this.Controls.Add(this.lbmail);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbPsw1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPsw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.label1);
            this.Name = "ucCreateAccountView";
            this.Size = new System.Drawing.Size(395, 176);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPsw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPsw1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbmail;
        private System.Windows.Forms.Label lbPsw;
        private System.Windows.Forms.Label lbPsw1;
        private System.Windows.Forms.Label lbInfo;
    }
}
