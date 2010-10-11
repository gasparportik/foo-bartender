namespace foobartender.forms
{
    partial class OrderForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstCategories = new System.Windows.Forms.ListView();
            this.lstProducts = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panItems = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCatScrollUp = new System.Windows.Forms.Button();
            this.btnCatScrollDown = new System.Windows.Forms.Button();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstCategories
            // 
            this.lstCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCategories.HideSelection = false;
            this.lstCategories.Location = new System.Drawing.Point(12, 25);
            this.lstCategories.MultiSelect = false;
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(682, 80);
            this.lstCategories.TabIndex = 0;
            this.lstCategories.UseCompatibleStateImageBehavior = false;
            this.lstCategories.SelectedIndexChanged += new System.EventHandler(this.lstCategories_SelectedIndexChanged);
            // 
            // lstProducts
            // 
            this.lstProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProducts.HideSelection = false;
            this.lstProducts.Location = new System.Drawing.Point(12, 124);
            this.lstProducts.MultiSelect = false;
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(682, 80);
            this.lstProducts.TabIndex = 1;
            this.lstProducts.UseCompatibleStateImageBehavior = false;
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
            this.lstProducts.DoubleClick += new System.EventHandler(this.lstProducts_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Products";
            // 
            // panItems
            // 
            this.panItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panItems.AutoScroll = true;
            this.panItems.Location = new System.Drawing.Point(13, 248);
            this.panItems.Name = "panItems";
            this.panItems.Size = new System.Drawing.Size(710, 230);
            this.panItems.TabIndex = 9;
            // 
            // btnCatScrollUp
            // 
            this.btnCatScrollUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatScrollUp.Location = new System.Drawing.Point(700, 25);
            this.btnCatScrollUp.Name = "btnCatScrollUp";
            this.btnCatScrollUp.Size = new System.Drawing.Size(23, 23);
            this.btnCatScrollUp.TabIndex = 10;
            this.btnCatScrollUp.Text = "^";
            this.btnCatScrollUp.UseVisualStyleBackColor = true;
            this.btnCatScrollUp.Click += new System.EventHandler(this.ScrollCategories);
            // 
            // btnCatScrollDown
            // 
            this.btnCatScrollDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatScrollDown.Location = new System.Drawing.Point(700, 82);
            this.btnCatScrollDown.Name = "btnCatScrollDown";
            this.btnCatScrollDown.Size = new System.Drawing.Size(23, 23);
            this.btnCatScrollDown.TabIndex = 11;
            this.btnCatScrollDown.Text = "v";
            this.btnCatScrollDown.UseVisualStyleBackColor = true;
            this.btnCatScrollDown.Click += new System.EventHandler(this.ScrollCategories);
            // 
            // txtTable
            // 
            this.txtTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTable.Location = new System.Drawing.Point(12, 210);
            this.txtTable.Name = "txtTable";
            this.txtTable.ReadOnly = true;
            this.txtTable.Size = new System.Drawing.Size(233, 31);
            this.txtTable.TabIndex = 12;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(626, 210);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 32);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back to tables";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(511, 210);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(109, 31);
            this.txtTotal.TabIndex = 14;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 490);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.btnCatScrollDown);
            this.Controls.Add(this.btnCatScrollUp);
            this.Controls.Add(this.panItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.lstCategories);
            this.Name = "OrderForm";
            this.Text = "Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstCategories;
        private System.Windows.Forms.ListView lstProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panItems;
        private System.Windows.Forms.Button btnCatScrollUp;
        private System.Windows.Forms.Button btnCatScrollDown;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtTotal;
    }
}