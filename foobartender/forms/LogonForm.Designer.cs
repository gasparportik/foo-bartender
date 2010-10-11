namespace foobartender.forms
{
    partial class LogonForm
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
            this.panLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panLoggedIn = new System.Windows.Forms.FlowLayoutPanel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panLogin
            // 
            this.panLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panLogin.BackColor = System.Drawing.Color.Transparent;
            this.panLogin.Controls.Add(this.btnLogin);
            this.panLogin.Controls.Add(this.txtPassword);
            this.panLogin.Controls.Add(this.txtUsername);
            this.panLogin.Controls.Add(this.label2);
            this.panLogin.Controls.Add(this.label1);
            this.panLogin.Location = new System.Drawing.Point(152, 12);
            this.panLogin.Name = "panLogin";
            this.panLogin.Size = new System.Drawing.Size(253, 84);
            this.panLogin.TabIndex = 6;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(186, 14);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(64, 62);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtPassword.Location = new System.Drawing.Point(3, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(177, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txtUsername
            // 
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtUsername.Location = new System.Drawing.Point(3, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(177, 20);
            this.txtUsername.TabIndex = 7;
            this.txtUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // panLoggedIn
            // 
            this.panLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panLoggedIn.Location = new System.Drawing.Point(12, 210);
            this.panLoggedIn.Name = "panLoggedIn";
            this.panLoggedIn.Size = new System.Drawing.Size(521, 100);
            this.panLoggedIn.TabIndex = 7;
            this.panLoggedIn.VisibleChanged += new System.EventHandler(this.panLoggedIn_VisibleChanged);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.ErrorImage = null;
            this.pbLogo.InitialImage = null;
            this.pbLogo.Location = new System.Drawing.Point(12, 102);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(521, 102);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLogo.TabIndex = 8;
            this.pbLogo.TabStop = false;
            // 
            // LogonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(545, 322);
            this.ControlBox = false;
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.panLoggedIn);
            this.Controls.Add(this.panLogin);
            this.Name = "LogonForm";
            this.Text = "LogonForm";
            this.panLogin.ResumeLayout(false);
            this.panLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panLoggedIn;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}