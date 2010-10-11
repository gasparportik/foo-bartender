using System;
using System.Windows.Forms;
using DataAccessLayer;
using foobartender.GUI;
using System.Data;
using Util;

namespace foobartender.forms
{
    public partial class SubItemEdit : InnerForm
    {
        protected bool deleted;
        protected SubItem dao;
        protected ItemManager itemManager;
        protected ItemEditor iHeader;

        public SubItemEdit()
        {
            InitializeComponent();
        }

        public virtual void SetupComponent()
        {
        }
        
        public virtual void Reset()
        {
            iHeader.ReadOnly = false;
            itemManager = new ItemManager(this, panItems, iHeader);
        }

        virtual public bool CreateNew()
        {
            Reset();
            try
            {
                dao = (SubItem) dao.GetType().GetConstructor(new Type[] {}).Invoke(new object[] {});
            } catch( Exception ex)
            {
                Logger.Instance.Exception(this,ex);
            }
            dao.Load();
            dao.CreateNew();
            return false;
        }

        virtual public bool LoadData(int id)
        {
            Reset();
            dao.Id = id;
            dao.Load();
            foreach (DataRow row in dao.Items)
            {
                var x = new ItemEditor();
                itemManager.AddItem(x);
                x.UpdateFromRow(row);
            }
            return true;
        }

        protected virtual bool Save()
        {
            itemManager.Recalculate();
            foreach (var item in itemManager.Items)
            {
                if (item.Header || !item.Visible) continue;
                if (item.UpdateRow()) continue;
                var row = dao.AddItem();
                item.UpdateRow(ref row);
            }
            return dao.Save();
        }

        virtual public Boolean Validate(out String error)
        {
            error = "";
            return false;
        }

        virtual public void UpdateTotals(double net, double vat, double total)
        {
            //
        }

        public virtual void MakeReadOnly()
        {
            ChangeReadOnlyState(true);
        }

        public virtual void ChangeReadOnlyState(bool readOnly)
        {
            itemManager.ChangeReadOnlyState(readOnly);
        }

        protected Panel AddPanelField(string name, Control control)
        {
            var panel = new FlowLayoutPanel();
            panel.Controls.Add(new Label { Text = name });
            panel.Controls.Add(control);
            panFields.Controls.Add(panel);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            return panel;
        }

        public void Delete()
        {
            if (dao != null)
            {
                deleted = dao.Delete();
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                return;
            Delete();
            if (deleted)
            {
                Close();
            }
        }
    }
}
