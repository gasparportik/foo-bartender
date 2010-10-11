using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace foobartender.forms
{
    public class InnerForm : Form
    {
        private List<InnerForm> notifiedForms;
        protected bool closable = true;
        protected bool singleton;
        protected bool handleClosing = true;

        public List<InnerForm> NotifiedForms
        {
            get
            {
                if (notifiedForms == null)
                {
                    notifiedForms = new List<InnerForm>();
                }
                return notifiedForms;
            }
        }

        public bool Closable
        {
            get { return closable; }
        }

        public bool Singleton
        {
            get { return singleton; }
        }

        public bool HandleClosing
        {
            get { return handleClosing; }
        }

        public virtual void ClosingNotification(InnerForm form)
        {
            //May be implemented to catch child form closings
        }
    }
}
