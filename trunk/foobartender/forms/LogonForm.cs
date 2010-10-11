using System;
using System.Drawing;
using System.Windows.Forms;
using foobartender.Properties;
using foobartender.GUI;

namespace foobartender.forms
{
    public partial class LogonForm : InnerForm
    {
        private readonly MainForm parent;
        private readonly NumPad numPad;

        public LogonForm(MainForm parent)
        {
            singleton = true;
            closable = false;
            handleClosing = false;
            InitializeComponent();
            this.parent = parent;
            numPad = new NumPad();
            Controls.Add(numPad);
            numPad.BringToFront();
            numPad.Attach(txtPassword);
            FormClosing += StopClosing;
            pbLogo.ImageLocation = "logo.png";
        }

        private void StopClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            parent.Login(txtUsername.Text, txtPassword.Text);
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnLogin_Click(sender, null);
            }
        }

        private void panLoggedIn_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) txtPassword.Text = "";
            if (!Visible || parent.Accounts.Count == 0) return;
            panLoggedIn.Controls.Clear();
            foreach (var account in parent.Accounts)
            {
                var u = new Button
                            {
                                Text = account.Name,
                                Image = Resources.WaiterIcon,
                                ImageAlign = ContentAlignment.TopCenter,
                                TextAlign = ContentAlignment.BottomCenter,
                                Size = new Size(100, 90),
                                Tag = account["UserName"]
                            };
                u.Click += LoginButtonClicked;
                panLoggedIn.Controls.Add(u);
            }
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            var u = (Button) sender;
            txtUsername.Text = u.Tag.ToString();
            txtPassword.Text = "";
            txtPassword.Focus();
        }
    }
}