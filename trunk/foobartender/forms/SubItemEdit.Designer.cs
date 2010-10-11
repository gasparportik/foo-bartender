namespace foobartender.forms
{
    partial class SubItemEdit
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
            this.panFields = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.panActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.panItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panFields
            // 
            this.panFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panFields.AutoScroll = true;
            this.panFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFields.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panFields.Location = new System.Drawing.Point(13, 13);
            this.panFields.Name = "panFields";
            this.panFields.Size = new System.Drawing.Size(675, 200);
            this.panFields.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(0, 46);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(0, 23);
            this.btnDiscard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(82, 23);
            this.btnDiscard.TabIndex = 3;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // panActions
            // 
            this.panActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panActions.Controls.Add(this.btnSave);
            this.panActions.Controls.Add(this.btnDiscard);
            this.panActions.Controls.Add(this.btnDelete);
            this.panActions.Controls.Add(this.btnFinalize);
            this.panActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panActions.Location = new System.Drawing.Point(695, 13);
            this.panActions.Margin = new System.Windows.Forms.Padding(0);
            this.panActions.Name = "panActions";
            this.panActions.Size = new System.Drawing.Size(82, 200);
            this.panActions.TabIndex = 5;
            // 
            // btnFinalize
            // 
            this.btnFinalize.Location = new System.Drawing.Point(0, 69);
            this.btnFinalize.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(82, 23);
            this.btnFinalize.TabIndex = 4;
            this.btnFinalize.Text = "Finalize";
            this.btnFinalize.UseVisualStyleBackColor = true;
            // 
            // panItems
            // 
            this.panItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panItems.AutoScroll = true;
            this.panItems.Location = new System.Drawing.Point(13, 220);
            this.panItems.Name = "panItems";
            this.panItems.Size = new System.Drawing.Size(764, 201);
            this.panItems.TabIndex = 6;
            // 
            // SubItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 433);
            this.Controls.Add(this.panItems);
            this.Controls.Add(this.panActions);
            this.Controls.Add(this.panFields);
            this.Name = "SubItemEdit";
            this.Text = "SubItemEdit";
            this.panActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.FlowLayoutPanel panFields;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnDiscard;
        protected System.Windows.Forms.FlowLayoutPanel panActions;
        protected System.Windows.Forms.FlowLayoutPanel panItems;
        protected System.Windows.Forms.Button btnFinalize;

    }
}