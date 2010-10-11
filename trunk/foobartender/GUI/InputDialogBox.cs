using System;
using System.Drawing;
using System.Windows.Forms;

namespace foobartender.GUI
{
    public class SimpleInputDialog : Form
    {
        private Button btnOk;
        private Button btnCancel;
        private Label lblInfo;
        private string strMessage;
        private TextBox txtInput;

        public SimpleInputDialog(string headerText)
        {
            InitializeComponent();
            lblInfo.Text = headerText;
        }

        public string InputMessage
        {
            get { return strMessage; }
            set
            {
                strMessage = value;
                txtInput.Text = value;
            }
        }

        public bool Password
        {
            get
            {
                return txtInput.PasswordChar == '*';
            }
            set
            {
                txtInput.PasswordChar = value ? '*' : '\u0000';
            }
        }

        private void InitializeComponent()
        {
            btnOk = new Button();
            btnCancel = new Button();
            lblInfo = new Label();
            txtInput = new TextBox();
            SuspendLayout();

            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(10, 10);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(250, 20);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Enter Text:";

            btnOk.Location = new Point(50, 86);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 25);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += OkClick;

            btnCancel.Location = new Point(175, 86);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += Cancel_Click;

            txtInput.Location = new Point(45, 50);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(239, 20);
            txtInput.TabIndex = 1;
            txtInput.KeyPress += CheckEnter;

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(300, 80);
            Controls.Add(txtInput);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ControlBox = false;
            Name = "SimpleInputDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Input";
            ResumeLayout(false);
            PerformLayout();
        }

        private void OkClick(object sender, EventArgs e)
        {
            InputMessage = txtInput.Text;
            Close();
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                OkClick(sender, e);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            strMessage = null;
            Close();
        }
    }

    public static class InputDialogBox
    {
        public static string Show(string text)
        {
            return Show(text, "", "Input", false);
        }

        public static string Show(string text, string inputText)
        {
            return Show(text, inputText, "Input", false);
        }

        public static string Show(string text, string inputText, string caption)
        {
            return Show(text, inputText, caption, false);
        }

        public static string Show(string text, string inputText, string caption, bool password)
        {
            var dialog = new SimpleInputDialog(text) { Text = caption, InputMessage = inputText, Password = password };
            dialog.ShowDialog();
            return dialog.InputMessage;
        }
    }
}