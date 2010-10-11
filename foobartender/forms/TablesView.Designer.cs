namespace foobartender.forms
{
    partial class TablesView
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
            this.lstTables = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnOccupy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTables
            // 
            this.lstTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstTables.HideSelection = false;
            this.lstTables.Location = new System.Drawing.Point(12, 12);
            this.lstTables.MultiSelect = false;
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(461, 165);
            this.lstTables.TabIndex = 0;
            this.lstTables.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Table name";
            this.columnHeader1.Width = 161;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Waiter name";
            this.columnHeader2.Width = 98;
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.Location = new System.Drawing.Point(398, 183);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 1;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder.Location = new System.Drawing.Point(317, 183);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // btnOccupy
            // 
            this.btnOccupy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOccupy.Location = new System.Drawing.Point(236, 183);
            this.btnOccupy.Name = "btnOccupy";
            this.btnOccupy.Size = new System.Drawing.Size(75, 23);
            this.btnOccupy.TabIndex = 3;
            this.btnOccupy.Text = "Occupy";
            this.btnOccupy.UseVisualStyleBackColor = true;
            // 
            // TablesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 218);
            this.Controls.Add(this.btnOccupy);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.lstTables);
            this.Name = "TablesView";
            this.Text = "TablesView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstTables;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnOccupy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}