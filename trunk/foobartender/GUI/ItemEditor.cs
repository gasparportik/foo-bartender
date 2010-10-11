using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using foobartender.Properties;
using System.Drawing;
using Util;

namespace foobartender.GUI
{
    public partial class ItemEditor : UserControl
    {
        //DATA RELATED MEMBERS
        private DataRow dataRow;
        //FUNCTION RELATED MEMBERS
        private Boolean headerized;
        private Boolean isHeader;
        private ItemManager manager;
        private bool readOnly;
        private ItemEditorStyle style;
        private NumPad numPad;
        private bool rawProductsOnly = true;
        private bool deleted;

        public ItemEditor()
        {
            InitializeComponent();
            SetupComponent();
            if (isHeader)
            {
                ChangeToHeader();
            }
            else
            {
                LoadProducts();
            }
        }

        //DATA RELATED PROPERTIES
        public int ItemNumber
        {
            get { return Convert.ToInt32(txtItemNumber.Text); }
            set { txtItemNumber.Text = value.ToString(); }
        }

        public int ProductId
        {
            get { return txtProduct.SelectedItem == null ? 0 : ((DataProxy)txtProduct.SelectedItem)["Id"].ToInt(); }
            set
            {
                foreach (DataProxy item in txtProduct.Items)
                {
                    if (item["Id"].ToInt() != value) continue;
                    txtProduct.SelectedItem = item;
                }
            }
        }

        public double Quantity
        {
            get { return double.Parse(txtQuantity.Text); }
            set
            {
                txtQuantity.Text = value.ToString();
                Recalculate(2);
            }
        }

        public double Value
        {
            get { return Converter.ToDouble(txtValue.Text); }
        }

        public double Vat
        {
            get { return Converter.ToDouble(txtVat.Text); }
        }

        public DataRow Row
        {
            get
            {
                return dataRow;
            }
        }

        //FUNCTION RELATED PROPERTIES
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                MakeReadOnly(value);
            }
        }

        public NumPad NumPad
        {
            get
            {
                return numPad;
            }

            set
            {
                numPad = value;
                if (value != null)
                    numPad.Attach(txtQuantity);
            }
        }

        public ItemEditorStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                SetupStyle();
            }
        }

        public ItemManager Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        public Boolean Header
        {
            get { return isHeader; }
            set { isHeader = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
        }

        //METHODS

        private void SetupComponent()
        {
            txtVatRate.Text = Settings.Default.VatRate;
        }

        private void SetupStyle()
        {
            switch (style)
            {
                case ItemEditorStyle.FullEditor:

                    break;
                case ItemEditorStyle.VatlessEditor:
                    txtVatRate.Visible = false;
                    txtVat.Visible = false;
                    break;
                case ItemEditorStyle.SaleItemEditor:
                    rawProductsOnly = false;
                    LoadProducts();
                    if (Header) { btnInsert.Visible = false; }
                    else
                    {
                        btnInsert.Enabled = false;
                        btnInsert.Image = Resources.valid;
                        btnDelete.Image = Resources.invalid;
                    }
                    txtProduct.DropDownStyle = ComboBoxStyle.DropDownList;
                    txtVatRate.Visible = false;
                    txtVat.Visible = false;
                    txtValue.ReadOnly = true;
                    txtTotal.ReadOnly = true;
                    txtUnitPrice.ReadOnly = true;
                    Font = new Font(FontFamily.GenericMonospace, 12F);
                    break;
                case ItemEditorStyle.QuantityOnly:
                    txtVatRate.Visible = false;
                    txtVat.Visible = false;
                    txtValue.Visible = false;
                    txtTotal.Visible = false;
                    txtUnitPrice.ReadOnly = true;
                    Font = new Font("monospace", 12F);
                    break;
            }
        }

        private void MakeReadOnly(bool value)
        {
            UnlockFields(!value);
            txtProduct.Enabled = !value;
            btnInsert.Enabled = !value;
            btnDelete.Enabled = !value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (isHeader && !headerized)
            {
                ChangeToHeader();
                headerized = true;
            }
        }

        public void LoadProducts()
        {
            var products = new Product();
            if (rawProductsOnly)
            {
                products.LoadFiltered("RecipeId IS NULL");
            }
            else
            {
                products.LoadAll();
            }
            txtProduct.Items.Clear();
            txtProduct.Items.AddRange(products.AsDataProxies());
        }

        private void ChangeToHeader()
        {
            var lblProduct = new TextBox { Size = txtProduct.Size, Margin = txtProduct.Margin };
            panControls.Controls.Add(lblProduct);
            panControls.Controls.SetChildIndex(lblProduct, panControls.Controls.IndexOf(txtProduct));
            panControls.Controls.Remove(txtProduct);

            var lblUnit = new TextBox { Size = txtUnit.Size, Margin = txtProduct.Margin };
            panControls.Controls.Add(lblUnit);
            panControls.Controls.SetChildIndex(lblUnit, panControls.Controls.IndexOf(txtUnit));
            panControls.Controls.Remove(txtUnit);

            var controls = new Dictionary<TextBox, string>
                               {
                                   {txtItemNumber, "No."},
                                   {lblProduct, "Product"},
                                   {txtQuantity, "Quantity"},
                                   {lblUnit, "Unit"},
                                   {txtUnitPrice, "UnitPrice"},
                                   {txtValue, "Value"},
                                   {txtVatRate, "VAT%"},
                                   {txtVat, "VAT"},
                                   {txtTotal, "Total"},
                               };
            bottomRule.Visible = true;
            //panControls.Controls.Clear();

            foreach (var control in controls)
            {
                control.Key.Text = control.Value;
                control.Key.BackColor = SystemColors.Control;
                control.Key.Enabled = false;
                control.Key.ReadOnly = true;
                control.Key.BorderStyle = BorderStyle.None;
            }
            btnInsert.Image = Resources.AddSign;
            btnDelete.Visible = false;
        }


        private void txtProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtProduct.SelectedItem == null) return;
            var dp = (DataProxy)txtProduct.SelectedItem;
            txtUnit.Items.Clear();
            txtUnit.Items.AddRange(new Product(int.Parse(dp["Id"])).GetUnits());
            UnlockFields(true);
            if (Style == ItemEditorStyle.SaleItemEditor)
            {
                btnInsert.Enabled = dp["RecipeId"].ToInt() == 0;
            }
            txtUnit.SelectedIndex = 0;
        }

        private void FieldChanged(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Focused) return;
            Recalculate(panControls.Controls.IndexOf((Control)sender));
        }

        public void Recalculate(int by)
        {
            var quantity = Converter.ToDouble(txtQuantity.Text);
            var unitPrice = Converter.ToDouble(txtUnitPrice.Text);
            var value = Converter.ToDouble(txtValue.Text);
            var vatRate = Converter.ToDouble(txtVatRate.Text);
            var vat = Converter.ToDouble(txtVat.Text);
            var total = Converter.ToDouble(txtTotal.Text);
            switch (by)
            {
                case 2: //Quantity
                case 4: //UnitPrice
                    value = quantity * unitPrice;
                    vat = vatRate * value / 100;
                    total = value + vat;
                    break;
                case 5: //Value
                    if (quantity > 0)
                    {
                        unitPrice = value / quantity;
                    }
                    vat = vatRate * value / 100;
                    total = value + vat;
                    break;
                case 6: //Vat%
                    vat = vatRate * value / 100;
                    total = value + vat;
                    break;
                case 7: //Vat
                case 8: //Total
                    value = total * 100 / (vatRate + 100);
                    vat = total - value;
                    if (quantity > 0)
                    {
                        unitPrice = value / quantity;
                    }
                    break;
                default:
                    MessageBox.Show(by.ToString());
                    break;
            }
            if (!txtQuantity.Focused) txtQuantity.Text = Converter.ToString(quantity);
            if (!txtUnitPrice.Focused) txtUnitPrice.Text = Converter.ToString(unitPrice);
            if (!txtValue.Focused) txtValue.Text = Converter.ToString(value);
            if (!txtVatRate.Focused) txtVatRate.Text = Converter.ToString(vatRate);
            if (!txtVat.Focused) txtVat.Text = Converter.ToString(vat);
            if (!txtTotal.Focused) txtTotal.Text = Converter.ToString(total);
            if (manager != null)
            {
                manager.Recalculate();
            }
            else
            {
                Logger.Instance.Log("Null manager found for " + this);
            }
        }

        private void UnlockFields(bool enable)
        {
            txtQuantity.Enabled = enable;
            txtUnit.Enabled = enable;
            txtUnitPrice.Enabled = enable;
            txtValue.Enabled = enable;
            txtVatRate.Enabled = enable;
            txtVat.Enabled = enable;
            txtTotal.Enabled = enable;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (manager == null) return;
            if (isHeader)
            {
                manager.Append(this);
            }
            else
            {
                manager.Insert(this);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.deleted = true;
            if (manager == null) return;
            manager.Delete(this);
        }

        public Dictionary<String, String> AsAssociativeArray()
        {
            var values = new Dictionary<string, string>
                             {
                                 {"ItemNumber", txtItemNumber.Text},
                                 {
                                     "ProductId",
                                     (txtProduct.SelectedItem != null)
                                         ? ((DataProxy) txtProduct.SelectedItem)["Id"]
                                         : ""
                                     },
                                 {"Quantity", txtQuantity.Text},
                                 {"UnitId", ((DataHolder) txtUnit.SelectedItem)["Id"].ToString()},
                                 {"UnitPrice", txtUnitPrice.Text},
                                 {"Value", txtValue.Text},
                                 {"Vat", txtVat.Text},
                                 {"Total", txtTotal.Text}
                             };
            return values;
        }

        public bool UpdateFromRow(DataRow row)
        {
            dataRow = row;
            DataColumnCollection columns = dataRow.Table.Columns;
            if (columns.Contains("ProductId"))
            {
                ProductId = new DbValue(dataRow["ProductId"]).ToInt();
            }
            if (columns.Contains("Quantity"))
            {
                txtQuantity.Text = Converter.ReFormat(dataRow["Quantity"]);
            }
            if (columns.Contains("Price"))
            {
                txtUnitPrice.Text = Converter.ReFormat(dataRow["Price"]);
            }
            if (columns.Contains("Value"))
            {
                txtValue.Text = Converter.ReFormat(dataRow["Value"]);
            }
            if (columns.Contains("Vat"))
            {
                txtVat.Text = Converter.ReFormat(dataRow["Vat"]);
            }
            if (columns.Contains("Total"))
            {
                txtTotal.Text = Converter.ReFormat(dataRow["Total"]);
            }
            else
            {
                Recalculate(4);
            }
            if (columns.Contains("Delivered") && new DbValue(dataRow["Delivered"]).ToBoolean())
            {
                ReadOnly = true;
            }
            return false;
        }

        public bool UpdateRow()
        {
            return UpdateRow(ref dataRow);
        }

        public bool UpdateRow(ref DataRow row)
        {
            if (row == null)
            {
                return false;
            }
            dataRow = row;
            DataColumnCollection columns = row.Table.Columns;
            if (columns.Contains("ProductId"))
            {
                row["ProductId"] = ((DataProxy)txtProduct.SelectedItem)["Id"].ToInt();
            }
            if (columns.Contains("Quantity"))
            {
                row["Quantity"] = Converter.ToDouble(txtQuantity.Text);
            }
            if (columns.Contains("UnitId"))
            {
                row["UnitId"] = ((DataHolder)txtUnit.SelectedItem)["Id"];
            }
            if (columns.Contains("Price"))
            {
                row["Price"] = Converter.ToDouble(txtUnitPrice.Text);
            }
            if (columns.Contains("Value"))
            {
                row["Value"] = Converter.ToDouble(txtValue.Text);
            }
            if (columns.Contains("Vat"))
            {
                row["Vat"] = Converter.ToDouble(txtVat.Text);
            }
            if (columns.Contains("Total"))
            {
                row["Total"] = Converter.ToDouble(txtTotal.Text);
            }
            return true;
        }

        public bool Validate(out string error)
        {
            if (txtProduct.SelectedItem == null)
            {
                error = "No product selected!";
                return false;
            }
            if (txtUnit.SelectedItem == null)
            {
                error = "No unit selected!";
                return false;
            }
            var fieldName = "";
            try
            {
                fieldName = "quantity";
                var value = Converter.ToDouble(txtQuantity.Text);
                if (value <= 0) throw new Exception();
                fieldName = "unit price";
                value = Converter.ToDouble(txtUnitPrice.Text);
                if (value <= 0) throw new Exception();
                fieldName = "value";
                value = Converter.ToDouble(txtValue.Text);
                if (value <= 0) throw new Exception();
                fieldName = "VAT";
                value = Converter.ToDouble(txtVat.Text);
                if (value <= 0) throw new Exception();
                fieldName = "total";
                value = Converter.ToDouble(txtTotal.Text);
                if (value <= 0) throw new Exception();
            }
            catch (Exception)
            {
                error = "Invalid value for " + fieldName;
                return false;
            }
            error = null;
            return true;
        }

        public void Delete()
        {
            Visible = false;
            if (dataRow != null)
                dataRow.Delete();
        }

        private void txtUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var unitPrice = Converter.ToDouble(((DataHolder)txtUnit.SelectedItem)["Ratio"].ToString()) *
                                  Converter.ToDouble(((DataProxy)txtProduct.SelectedItem)["Price"]);
                txtUnitPrice.Text = Converter.ToString(unitPrice);
                Recalculate(4);
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }
    }

    public enum ItemEditorStyle
    {
        FullEditor,
        VatlessEditor,
        SaleItemEditor,
        QuantityOnly
    }
}