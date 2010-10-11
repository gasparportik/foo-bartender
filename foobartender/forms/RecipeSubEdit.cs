using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer.DAO;
using foobartender.GUI;
using Util;

namespace foobartender.forms
{
    public class RecipeSubEdit : SubItemEdit
    {
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtTotal;

        public RecipeSubEdit()
        {
            dao = new Recipe();
            InitializeComponent();
            SetupComponent();
        }

        public override bool LoadData(int id)
        {
            base.LoadData(id);
            txtName.Text = dao["Name"].ToString();
            txtDescription.Text = dao["Description"].ToString();
            txtTotal.Text = Converter.ReFormat(dao["Total"]);
            Text = "Recipe for Product #" + id;
            return false;
        }

        public override void Reset()
        {
            base.Reset();
            txtName.Text = "";
            txtDescription.Text = "";
            txtTotal.Text = Converter.ToString(0F);
        }

        private void InitializeComponent()
        {
            Text = "Recipe";

            var tabIndex = 0;

            var bigFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);

            txtName = new TextBox
            {
                Size = new Size(300, 20),
                TabIndex = tabIndex++,
            };

            txtDescription = new TextBox
            {
                Size = new Size(300, 150),
                TabIndex = tabIndex++,
                Multiline = true
            };

            txtTotal = new TextBox
            {
                Font = bigFont,
                ReadOnly = true,
                RightToLeft = RightToLeft.Yes,
                TabIndex = tabIndex++,
                Text = "0.00"
            };
            btnSave.Click += Save_Click;
        }

        public override void SetupComponent()
        {
            // ACTIONS
            //panActions.Controls.Add(btnPrint);

            //FIELDS
            AddPanelField("Name", txtName);

            AddPanelField("Description", txtDescription);

            AddPanelField("Total", txtTotal);

            //ITEMS
            iHeader = new ItemEditor { Header = true };
            itemManager = new ItemManager(this, panItems, iHeader);
        }

        public override Boolean Validate(out String error)
        {
            if (txtName.Text.Length == 0)
            {
                error = "No name given";
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
            dao["Name"] += txtName.Text;
            dao["Description"] += txtDescription.Text;
            dao["Total"] += Converter.ReFormat(txtTotal.Text);
            dao["CreatedBy"] += MainForm.AccountId.ToString();
            if (Save())
            {
            }
        }

        override public void UpdateTotals(double net, double vat, double total)
        {
            txtTotal.Text = Converter.ToString(total);
        }
    }
}