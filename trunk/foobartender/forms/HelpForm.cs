using System;
using System.Windows.Forms;
using Util;

namespace foobartender.forms
{
    public partial class HelpForm : InnerForm
    {
        public HelpForm()
        {
            InitializeComponent();
            try
            {
                rbHelp.LoadFile("Help.rtf");
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message);
                MessageBox.Show("Could not load help file");
            }
        }
    }
}