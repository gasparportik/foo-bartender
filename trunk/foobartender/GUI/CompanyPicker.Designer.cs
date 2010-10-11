namespace foobartender.GUI
{
    partial class CompanyPicker
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNrOrdReg = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCIF = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Company name";
            // 
            // txtName
            // 
            this.txtName.FormattingEnabled = true;
            this.txtName.Location = new System.Drawing.Point(92, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 21);
            this.txtName.TabIndex = 1;
            this.txtName.SelectedIndexChanged += new System.EventHandler(this.txtName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CIF";
            // 
            // txtNrOrdReg
            // 
            this.txtNrOrdReg.Location = new System.Drawing.Point(274, 30);
            this.txtNrOrdReg.Name = "txtNrOrdReg";
            this.txtNrOrdReg.ReadOnly = true;
            this.txtNrOrdReg.Size = new System.Drawing.Size(123, 20);
            this.txtNrOrdReg.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(376, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(21, 21);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "+";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nr. Ord. Reg.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Address";
            // 
            // txtCIF
            // 
            this.txtCIF.Location = new System.Drawing.Point(92, 30);
            this.txtCIF.Name = "txtCIF";
            this.txtCIF.ReadOnly = true;
            this.txtCIF.Size = new System.Drawing.Size(100, 20);
            this.txtCIF.TabIndex = 7;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(92, 54);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ReadOnly = true;
            this.txtAddress1.Size = new System.Drawing.Size(305, 20);
            this.txtAddress1.TabIndex = 8;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(236, 106);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.ReadOnly = true;
            this.txtIBAN.Size = new System.Drawing.Size(161, 20);
            this.txtIBAN.TabIndex = 9;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(92, 80);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.ReadOnly = true;
            this.txtAddress2.Size = new System.Drawing.Size(305, 20);
            this.txtAddress2.TabIndex = 10;
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(92, 106);
            this.txtBank.Name = "txtBank";
            this.txtBank.ReadOnly = true;
            this.txtBank.Size = new System.Drawing.Size(138, 20);
            this.txtBank.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bank";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(92, 132);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.ReadOnly = true;
            this.txtTelephone.Size = new System.Drawing.Size(138, 20);
            this.txtTelephone.TabIndex = 13;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(236, 132);
            this.txtFax.Name = "txtFax";
            this.txtFax.ReadOnly = true;
            this.txtFax.Size = new System.Drawing.Size(161, 20);
            this.txtFax.TabIndex = 14;
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(92, 158);
            this.txtSite.Name = "txtSite";
            this.txtSite.ReadOnly = true;
            this.txtSite.Size = new System.Drawing.Size(138, 20);
            this.txtSite.TabIndex = 15;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(236, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(161, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tel/fax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Website/e-mail";
            // 
            // CompanyPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.txtCIF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtNrOrdReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(400, 185);
            this.MinimumSize = new System.Drawing.Size(400, 185);
            this.Name = "CompanyPicker";
            this.Size = new System.Drawing.Size(398, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNrOrdReg;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCIF;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
