using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using foobartender.GUI;
using Util;

namespace foobartender.forms
{
    public class ReceptionSubEdit : SubItemEdit
    {
        private DateTimePicker dtCreation;
        private TextBox txtTotal;
        private ComboBox cmbSection;
        private bool enteredStock;

        public ReceptionSubEdit()
        {
            dao = new Reception();
            InitializeComponent();
            SetupComponent();
        }

        public override bool LoadData(int id)
        {
            base.LoadData(id);
            Text = "Reception #" + id;
            dtCreation.Enabled = false;
            dtCreation.Value = DateTime.Parse(dao["Date"].ToString());
            foreach (var item in cmbSection.Items)
            {
                if (((DataProxy)item)["Id"].ToString().Equals(dao["SectionId"].ToString()))
                {
                    cmbSection.SelectedItem = item;
                }
            }
            enteredStock = dao["EnteredStock"]!=null && dao["EnteredStock"].ToBoolean();
            if (enteredStock)
            {
                MakeReadOnly();
            }
            txtTotal.Text = Converter.ReFormat(dao["Total"]);
            return false;
        }

        public override void Reset()
        {
            base.Reset();
            dtCreation.Value = DateTime.Now;
            cmbSection.SelectedItem = null;
            txtTotal.Text = Converter.ToString(0F);
            enteredStock = false;
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

            cmbSection = new ComboBox
            {
                TabIndex = tabIndex++

            };
            var section = new Section();
            section.LoadAll();
            foreach (var row in section.AsDataProxies())
            {
                cmbSection.Items.Add(row);
            }

            var bigFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);

            txtTotal = new TextBox
            {
                Font = bigFont,
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                // ReSharper disable RedundantAssignment
                TabIndex = tabIndex++,
                // ReSharper restore RedundantAssignment
                Text = "0.00"
            };
            btnSave.Click += Save_Click;
            btnFinalize.Click += DeliverReception;
        }

        public override void SetupComponent()
        {
            // ACTIONS
            //panActions.Controls.Add(btnPrint);

            //FIELDS
            AddPanelField("Date", dtCreation);

            AddPanelField("Section", cmbSection);

            AddPanelField("Total", txtTotal);

            //ITEMS
            iHeader = new ItemEditor { Header = true };
            itemManager = new ItemManager(this, panItems, iHeader);
        }

        public override void ChangeReadOnlyState(bool readOnly)
        {
            base.ChangeReadOnlyState(readOnly);
            cmbSection.Enabled = !readOnly;
        }

        public void DeliverReception(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will finalize the reception and add all products to stock", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
            if (cmbSection.SelectedItem == null)
            {
                error = "No source section selected";
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
            dao["SectionId"] = new DbValue(((DataProxy)cmbSection.SelectedItem)["Id"]);
            dao["Date"] = new DbValue(dtCreation.Value);
            dao["Total"] = new DbValue(Converter.ToDouble(txtTotal.Text));
            dao["EnteredStock"] = new DbValue(dao.Id == 0 ? false : enteredStock);
            dao["CreatedBy"] = new DbValue(MainForm.AccountId);
            if (Save() && enteredStock)
            {
                MakeReadOnly();
            }
        }

        override public void UpdateTotals(double net, double vat, double total)
        {
            txtTotal.Text = Converter.ToString(total);
        }
    }
}