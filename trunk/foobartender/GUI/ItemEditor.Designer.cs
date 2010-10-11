namespace foobartender.GUI
{
    partial class ItemEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomRule = new System.Windows.Forms.Label();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.ComboBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtVatRate = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.panControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomRule
            // 
            this.bottomRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomRule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomRule.Location = new System.Drawing.Point(0, 23);
            this.bottomRule.Name = "bottomRule";
            this.bottomRule.Size = new System.Drawing.Size(800, 2);
            this.bottomRule.TabIndex = 999;
            this.bottomRule.Visible = false;
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Location = new System.Drawing.Point(2, 1);
            this.txtItemNumber.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.ReadOnly = true;
            this.txtItemNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemNumber.Size = new System.Drawing.Size(29, 20);
            this.txtItemNumber.TabIndex = 0;
            this.txtItemNumber.Text = "0";
            this.txtItemNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUnit.Enabled = false;
            this.txtUnit.FormattingEnabled = true;
            this.txtUnit.Location = new System.Drawing.Point(351, 1);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(55, 21);
            this.txtUnit.TabIndex = 3;
            this.txtUnit.SelectedValueChanged += new System.EventHandler(this.txtUnit_SelectedValueChanged);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Location = new System.Drawing.Point(410, 1);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnitPrice.Size = new System.Drawing.Size(65, 20);
            this.txtUnitPrice.TabIndex = 4;
            this.txtUnitPrice.Text = "0";
            this.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitPrice.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Enabled = false;
            this.txtValue.Location = new System.Drawing.Point(479, 1);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtValue.Name = "txtValue";
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValue.Size = new System.Drawing.Size(65, 20);
            this.txtValue.TabIndex = 5;
            this.txtValue.Text = "0";
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValue.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // txtVat
            // 
            this.txtVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVat.Enabled = false;
            this.txtVat.Location = new System.Drawing.Point(589, 1);
            this.txtVat.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtVat.Name = "txtVat";
            this.txtVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVat.Size = new System.Drawing.Size(65, 20);
            this.txtVat.TabIndex = 7;
            this.txtVat.Text = "0";
            this.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVat.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(658, 1);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.Size = new System.Drawing.Size(65, 20);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // txtVatRate
            // 
            this.txtVatRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVatRate.Enabled = false;
            this.txtVatRate.Location = new System.Drawing.Point(548, 1);
            this.txtVatRate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtVatRate.Name = "txtVatRate";
            this.txtVatRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVatRate.Size = new System.Drawing.Size(37, 20);
            this.txtVatRate.TabIndex = 6;
            this.txtVatRate.Text = "0";
            this.txtVatRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVatRate.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // txtProduct
            // 
            this.txtProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtProduct.FormattingEnabled = true;
            this.txtProduct.Location = new System.Drawing.Point(35, 1);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(256, 21);
            this.txtProduct.TabIndex = 1;
            this.txtProduct.SelectedValueChanged += new System.EventHandler(this.txtProduct_SelectedValueChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(295, 1);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(52, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "0";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // panControls
            // 
            this.panControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panControls.Controls.Add(this.txtItemNumber);
            this.panControls.Controls.Add(this.txtProduct);
            this.panControls.Controls.Add(this.txtQuantity);
            this.panControls.Controls.Add(this.txtUnit);
            this.panControls.Controls.Add(this.txtUnitPrice);
            this.panControls.Controls.Add(this.txtValue);
            this.panControls.Controls.Add(this.txtVatRate);
            this.panControls.Controls.Add(this.txtVat);
            this.panControls.Controls.Add(this.txtTotal);
            this.panControls.Controls.Add(this.btnInsert);
            this.panControls.Controls.Add(this.btnDelete);
            this.panControls.Location = new System.Drawing.Point(0, 0);
            this.panControls.Margin = new System.Windows.Forms.Padding(0);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(800, 23);
            this.panControls.TabIndex = 1001;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Image = global::foobartender.Properties.Resources.AliasArrow;
            this.btnInsert.Location = new System.Drawing.Point(727, 1);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(21, 21);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::foobartender.Properties.Resources.delete_icon;
            this.btnDelete.Location = new System.Drawing.Point(752, 1);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(21, 21);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panControls);
            this.Controls.Add(this.bottomRule);
            this.Name = "ItemEditor";
            this.Size = new System.Drawing.Size(800, 25);
            this.panControls.ResumeLayout(false);
            this.panControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label bottomRule;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.ComboBox txtUnit;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtVatRate;
        private System.Windows.Forms.ComboBox txtProduct;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.FlowLayoutPanel panControls;
    }
}
