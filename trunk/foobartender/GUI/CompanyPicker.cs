using System;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using foobartender.forms;

namespace foobartender.GUI
{
    public partial class CompanyPicker : UserControl
    {
        public CompanyPicker()
        {
            InitializeComponent();
            LoadCompanies();
        }

        public bool ReadOnly
        {
            set
            {
                txtName.Enabled = !value;
            }
        }

        private void LoadCompanies()
        {
            var companies = new Company();
            companies.LoadAll();
            txtName.Items.Clear();
            txtName.Items.AddRange(companies.AsDataProxies());
        }

        private void LoadValues()
        {
            DataProxy selected;
            if (txtName.SelectedItem != null)
            {
                selected = (DataProxy) txtName.SelectedItem;
            }
            else
            {
                selected = new DataProxy();
            }
            txtCIF.Text = selected["CIF"];
            txtNrOrdReg.Text = selected["NrOrdReg"];
            txtAddress1.Text = selected["Address"];
            txtAddress2.Text = selected["PostalCode"].ToString() + " " + selected["City"] + ", jud. " +
                               selected["County"] + ", " + selected["CountryName"];
            txtBank.Text = selected["BankName"];
            txtIBAN.Text = selected["IBAN"];
            txtTelephone.Text = selected["Telephone"];
            txtFax.Text = selected["Fax"];
            txtSite.Text = selected["Website"];
            txtEmail.Text = selected["Email"];
        }

        public int CompanyId
        {
            get
            {
                try
                {
                    return int.Parse(((DataProxy) txtName.SelectedItem)["Id"]);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            set
            {
                foreach (DataProxy item in txtName.Items)
                {
                    if (item["Id"].ToInt() == value)
                    {
                        txtName.SelectedItem = item;
                    }
                }
            }
        }

        private void txtName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new CompanyEdit().ShowDialog();
            LoadCompanies();
        }
    }
}