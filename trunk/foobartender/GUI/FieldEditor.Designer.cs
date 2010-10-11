namespace foobartender.GUI
{
    partial class FieldEditor
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
            this.panControls = new System.Windows.Forms.FlowLayoutPanel();
            this.imgValidation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // panControls
            // 
            this.panControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panControls.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panControls.Location = new System.Drawing.Point(0, 0);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(200, 50);
            this.panControls.TabIndex = 0;
            // 
            // imgValidation
            // 
            this.imgValidation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgValidation.BackColor = System.Drawing.Color.Transparent;
            this.imgValidation.Location = new System.Drawing.Point(181, 3);
            this.imgValidation.Name = "imgValidation";
            this.imgValidation.Size = new System.Drawing.Size(16, 16);
            this.imgValidation.TabIndex = 1;
            this.imgValidation.TabStop = false;
            // 
            // FieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.imgValidation);
            this.Controls.Add(this.panControls);
            this.Name = "FieldEditor";
            this.Size = new System.Drawing.Size(200, 50);
            this.Validated += new System.EventHandler(this.FieldEditor_Validated);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.FieldEditor_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.imgValidation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panControls;
        private System.Windows.Forms.PictureBox imgValidation;
    }
}
