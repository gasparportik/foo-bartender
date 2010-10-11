using System;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using foobartender.GUI;

namespace foobartender.forms
{
    public class TransferSubEdit : SubItemEdit
    {
        private DateTimePicker dtCreation;
        private ComboBox cmbSectionFrom;
        private ComboBox cmbSectionTo;
        private bool transferred;

        public TransferSubEdit()
        {
            dao = new Transfer();
            InitializeComponent();
            SetupComponent();
        }

        public override bool LoadData(int id)
        {
            base.LoadData(id);
            Text = "Transfer #" + id;
            dtCreation.Enabled = false;
            dtCreation.Value = DateTime.Parse(dao["Date"].ToString());
            foreach (var item in cmbSectionFrom.Items)
            {
                if (((DataProxy)item)["Id"].Equals(dao["SectionFrom"].ToString()))
                {
                    cmbSectionFrom.SelectedItem = item;
                }
            }
            foreach (var item in cmbSectionTo.Items)
            {
                if (((DataProxy)item)["Id"].Equals(dao["SectionTo"].ToString()))
                {
                    cmbSectionTo.SelectedItem = item;
                }
            }
            transferred = dao["Transferred"] != null && dao["Transferred"].ToBoolean();
            if (transferred)
            {
                MakeReadOnly();
            }
            return false;
        }

        public override void Reset()
        {
            base.Reset();
            dtCreation.Value = DateTime.Now;
            cmbSectionFrom.SelectedItem = null;
            cmbSectionTo.SelectedItem = null;
            transferred = false;
            ChangeReadOnlyState(false);
            btnFinalize.Enabled = true;
        }

        private void InitializeComponent()
        {
            Text = "Invoice";

            var tabIndex = 0;

            dtCreation = new DateTimePicker
            {
                TabIndex = tabIndex++,
                Enabled = false
            };

            cmbSectionFrom = new ComboBox
            {
                TabIndex = tabIndex++

            };

            cmbSectionTo = new ComboBox
            {
                TabIndex = tabIndex++

            };

            var section = new Section();
            section.LoadAll();
            foreach (var row in section.AsDataProxies())
            {
                cmbSectionFrom.Items.Add(row);
                cmbSectionTo.Items.Add(row);
            }

            btnSave.Click += Save_Click;
            btnFinalize.Click += TransferProducts;
        }

        public override void SetupComponent()
        {
            // ACTIONS
            //panActions.Controls.Add(btnPrint);

            //FIELDS
            AddPanelField("Date", dtCreation);

            AddPanelField("From section", cmbSectionFrom);

            AddPanelField("To section", cmbSectionTo);

            //ITEMS
            iHeader = new ItemEditor { Header = true ,Style = ItemEditorStyle.QuantityOnly };
            itemManager = new ItemManager(this, panItems, iHeader);
        }

        public override void ChangeReadOnlyState(bool readOnly)
        {
            base.ChangeReadOnlyState(readOnly);
            cmbSectionFrom.Enabled = !readOnly;
        }

        public void TransferProducts(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will finalize the transfer and move all products in stock", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Save_Click(btnSave, new EventArgs());
            if (dao.Commit())
            {
                MakeReadOnly();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("An unknown error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override Boolean Validate(out String error)
        {
            if (cmbSectionFrom.SelectedItem == null)
            {
                error = "No source section selected";
                return false;
            }
            if (cmbSectionTo.SelectedItem == null)
            {
                error = "No target section selected";
                return false;
            }
            if (cmbSectionFrom.SelectedItem == cmbSectionTo.SelectedItem)
            {
                error = "Source and target sections are the same";
                return false;
            }
            String itemsError;
            if (!itemManager.Validate(out itemsError))
            {
                error = "Error in items: \n" + itemsError;
                return false;
            }
            error = null;
            return true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string error;
            if (!Validate(out error))
            {
                MessageBox.Show("Error:" + error);
                return;
            }
            dao["SectionFrom"] = new DbValue(((DataProxy)cmbSectionFrom.SelectedItem)["Id"]);
            dao["SectionTo"] = new DbValue(((DataProxy)cmbSectionTo.SelectedItem)["Id"]);
            dao["Date"] = new DbValue(dtCreation.Value);
            dao["Transferred"] = new DbValue(dao.Id == 0 ? false : transferred);
            dao["CreatedBy"] = new DbValue(MainForm.AccountId);
            if (Save() && transferred)
            {
                MakeReadOnly();
            }
        }
    }
}