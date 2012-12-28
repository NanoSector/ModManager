namespace ModBuilder.Forms
{
    partial class addExtractionInstructionDialog
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
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshComboBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileComboBox
            // 
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(12, 25);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(471, 21);
            this.fileComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File/directory:";
            // 
            // refreshComboBox
            // 
            this.refreshComboBox.Location = new System.Drawing.Point(385, 3);
            this.refreshComboBox.Name = "refreshComboBox";
            this.refreshComboBox.Size = new System.Drawing.Size(97, 22);
            this.refreshComboBox.TabIndex = 2;
            this.refreshComboBox.Text = "Refresh";
            this.refreshComboBox.UseVisualStyleBackColor = true;
            this.refreshComboBox.Click += new System.EventHandler(this.refreshComboBox_Click);
            // 
            // addExtractionInstructionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 172);
            this.Controls.Add(this.refreshComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileComboBox);
            this.Name = "addExtractionInstructionDialog";
            this.Text = "addExtractionInstructionDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshComboBox;
    }
}