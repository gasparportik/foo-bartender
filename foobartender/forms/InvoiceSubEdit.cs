using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using foobartender.GUI;
using Util;

namespace foobartender.forms
{
    public class InvoiceSubEdit : SubItemEdit
    {
        private const int DELIVERY_DAYS = 5;
        private const int EXPIRATION_DAYS = 30;
        private const String INVOICE_NUMBER_TEMPLATE = "PPR-___-___-___";
        private bool delivered;
        private Button btnGenerateNumber;
        private Button btnPrint;
        private CompanyPicker company;
        private DateTimePicker dtInvoicing;
        private DateTimePicker dtDelivery;
        private DateTimePicker dtExpiration;
        private DateTimePicker dtPay;
        private TextBox txtSeriesNumber;
        private TextBox txtSumNet;
        private TextBox txtSumVat;
        private TextBox txtTotal;
        private ComboBox cmbSection;

        public InvoiceSubEdit()
        {
            dao = new Invoice();
            InitializeComponent();
            SetupComponent();
        }

        public override bool LoadData(int id)
        {
            base.LoadData(id);
            Text = "Invoice #" + id;
            company.CompanyId = dao["CompanyId"].ToInt();
            txtSeriesNumber.Text = dao["SeriesNumber"].ToString();
            dtInvoicing.Value = DateTime.Parse(dao["CreationDate"].ToString());
            dtPay.Value = DateTime.Parse(dao["PayDate"].ToString());
            dtDelivery.Value = DateTime.Parse(dao["DeliveryDate"].ToString());
            dtExpiration.Value = DateTime.Parse(dao["PaymentExpiration"].ToString());
            foreach (var item in cmbSection.Items)
            {
                if (((DataProxy)item)["Id"].ToInt().Equals(dao["SectionId"].ToInt()))
                {
                    cmbSection.SelectedItem = item;
                }
            }
            txtSumNet.Text = Converter.ReFormat(dao["SumNet"]);
            txtSumVat.Text = Converter.ReFormat(dao["SumVat"]);
            txtTotal.Text = Converter.ToString(Converter.ToFloat(dao["SumNet"]) + Converter.ToFloat(dao["SumVat"]));
            delivered = dao["Delivered"] != null && dao["Delivered"].ToBoolean();
            if (delivered)
            {
                btnFinalize.Enabled = false;
                MakeReadOnly();
            }
            return false;
        }

        public override void Reset()
        {
            base.Reset();
            company.CompanyId = 0;
            txtSeriesNumber.Text = "";
            dtInvoicing.Value = DateTime.Now;
            dtPay.Value = DateTime.Now;
            dtDelivery.Value = DateTime.Now.AddDays(DELIVERY_DAYS);
            dtExpiration.Value = DateTime.Now.AddDays(EXPIRATION_DAYS);
            cmbSection.SelectedItem = null;
            txtSumNet.Text = Converter.ToString(0F);
            txtSumVat.Text = Converter.ToString(0F);
            txtTotal.Text = Converter.ToString(0F);
            delivered = false;
            ChangeReadOnlyState(false);
            btnFinalize.Enabled = true;
        }

        private void InitializeComponent()
        {
            Text = "Invoice";

            var tabIndex = 0;

            company = new CompanyPicker
            {
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(2),
                TabIndex = tabIndex++
            };

            txtSeriesNumber = new TextBox
            {
                TabIndex = tabIndex++
            };


            btnGenerateNumber = new Button
            {
                TabIndex = tabIndex++,
                Text = "Generate",
            };
            btnGenerateNumber.Click += GenerateNumber_Click;

            dtInvoicing = new DateTimePicker
            {
                TabIndex = tabIndex++
            };

            dtPay = new DateTimePicker
            {
                TabIndex = tabIndex++,
            };
            dtDelivery = new DateTimePicker
            {
                TabIndex = tabIndex++,
                Value = dtInvoicing.Value.AddDays(DELIVERY_DAYS)
            };

            dtExpiration = new DateTimePicker
            {
                TabIndex = tabIndex++,
                Value = dtInvoicing.Value.AddDays(EXPIRATION_DAYS)
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

            txtSumNet = new TextBox
            {
                Font = bigFont,
                Name = "txtSumNet",
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                TabIndex = tabIndex++,
                Text = "0.00"
            };

            txtSumVat = new TextBox
            {
                Font = bigFont,
                Name = "txtSumVat",
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                TabIndex = tabIndex++,
                Text = "0.00"
            };

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

            btnPrint = new Button
            {
                Text = "Print preview",
                Size = btnSave.Size,
                Margin = btnSave.Margin
            };
            btnPrint.Click += BtnPrintClick;

            btnSave.Click += Save_Click;
            btnFinalize.Click += DeliverInvoice;
        }

        public override void SetupComponent()
        {
            // ACTIONS
            panActions.Controls.Add(btnPrint);

            //FIELDS
            panFields.Controls.Add(company);
            AddPanelField("Series number", txtSeriesNumber).Controls.Add(btnGenerateNumber);

            AddPanelField("Date", dtInvoicing);

            AddPanelField("Delivery", dtDelivery);

            AddPanelField("Payment", dtPay);

            AddPanelField("Expiration", dtExpiration);

            AddPanelField("Section", cmbSection);

            AddPanelField("Value", txtSumNet);
            AddPanelField("VAT", txtSumVat);
            AddPanelField("Total", txtTotal);

            //ITEMS
            iHeader = new ItemEditor { Header = true };
            itemManager = new ItemManager(this, panItems, iHeader);
        }

        public override void ChangeReadOnlyState(bool readOnly)
        {
            base.ChangeReadOnlyState(readOnly);
            company.ReadOnly = readOnly;
            cmbSection.Enabled = !readOnly;
            dtInvoicing.Enabled = !readOnly;
            dtExpiration.Enabled = !readOnly;
            dtDelivery.Enabled = !readOnly;
            txtSeriesNumber.ReadOnly = readOnly;
            btnGenerateNumber.Enabled = !readOnly;
        }

        public void DeliverInvoice(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will finalize the invoice and deduct all products from stock", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                MessageBox.Show("Not enough products on stock to finalize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override Boolean Validate(out String error)
        {
            if (company.CompanyId == 0)
            {
                error = "No company selected";
                return false;
            }
            if (txtSeriesNumber.Text.Length < 3)
            {
                error = "Invalid series/number specified";
                return false;
            }
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
            dao["CompanyId"] = new DbValue(company.CompanyId.ToString());
            dao["SectionId"] = new DbValue(((DataProxy)cmbSection.SelectedItem)["Id"]);
            dao["SeriesNumber"] = new DbValue(txtSeriesNumber.Text);
            dao["CreationDate"] = new DbValue(dtInvoicing.Value.ToString());
            dao["PayDate"] = new DbValue(dtPay.Value.ToString());
            dao["DeliveryDate"] = new DbValue(dtDelivery.Value.ToString());
            dao["PaymentExpiration"] = new DbValue(dtExpiration.Value.ToString());
            dao["SumNet"] = new DbValue(txtSumNet.Text);
            dao["SumVat"] = new DbValue(txtSumVat.Text);
            dao["Delivered"] = new DbValue(delivered);
            dao["CreatedBy"] = new DbValue(MainForm.AccountId);

            if (Save() && delivered)
            {
                MakeReadOnly();
            }
        }

        private void GenerateNumber_Click(object sender, EventArgs e)
        {
            var nr = "";
            var rand = new Random();
            foreach (var c in INVOICE_NUMBER_TEMPLATE)
            {
                if (c.Equals('_'))
                {
                    nr += Char.Parse(rand.Next(10).ToString());
                }
                else
                {
                    nr += c;
                }
            }
            txtSeriesNumber.Text = nr;
        }

        override public void UpdateTotals(double net, double vat, double total)
        {
            txtSumNet.Text = Converter.ToString(net);
            txtSumVat.Text = Converter.ToString(vat);
            txtTotal.Text = Converter.ToString(total);
        }

        private void BtnPrintClick(object sender, EventArgs e)
        {
            //MessageBox.Show(this, "No printer available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            new InvoicePrint(dao["Id"].ToInt()).ShowDialog();
            //dlgPrint.Document = pdPaper;
            //string strText = this.richTextBox1.Text;
            //myReader = new StringReader(strText);
            //if (dlgPrint.ShowDialog() == DialogResult.OK)
            //{
            //    this.pdPaper.Print();
            //}
        }
    }
}