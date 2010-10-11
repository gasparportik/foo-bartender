namespace foobartender.forms
{
    partial class InvoicePrint
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
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreview = new System.Windows.Forms.PrintPreviewControl();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pdInvoice = new System.Drawing.Printing.PrintDocument();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnOriginal = new System.Windows.Forms.Button();
            this.btnOrientation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreview
            // 
            this.printPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printPreview.Location = new System.Drawing.Point(12, 12);
            this.printPreview.Name = "printPreview";
            this.printPreview.Size = new System.Drawing.Size(633, 435);
            this.printPreview.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(651, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.Location = new System.Drawing.Point(651, 43);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(89, 23);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.Location = new System.Drawing.Point(651, 72);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(89, 23);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnOriginal
            // 
            this.btnOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOriginal.Location = new System.Drawing.Point(650, 101);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(89, 23);
            this.btnOriginal.TabIndex = 4;
            this.btnOriginal.Text = "Original";
            this.btnOriginal.UseVisualStyleBackColor = true;
            this.btnOriginal.Click += new System.EventHandler(this.btnOriginal_Click);
            // 
            // btnOrientation
            // 
            this.btnOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrientation.Location = new System.Drawing.Point(650, 130);
            this.btnOrientation.Name = "btnOrientation";
            this.btnOrientation.Size = new System.Drawing.Size(89, 23);
            this.btnOrientation.TabIndex = 5;
            this.btnOrientation.Text = "Orientation";
            this.btnOrientation.UseVisualStyleBackColor = true;
            this.btnOrientation.Click += new System.EventHandler(this.btnOrientation_Click);
            // 
            // InvoicePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 459);
            this.Controls.Add(this.btnOrientation);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.printPreview);
            this.Name = "InvoicePrint";
            this.Text = "InvoicePrint";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewControl printPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument pdInvoice;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnOriginal;
        private System.Windows.Forms.Button btnOrientation;
    }
}