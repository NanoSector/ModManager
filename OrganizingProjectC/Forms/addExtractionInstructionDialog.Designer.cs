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
            this.label2 = new System.Windows.Forms.Label();
            this.filePrefix = new System.Windows.Forms.ComboBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination:";
            // 
            // filePrefix
            // 
            this.filePrefix.FormattingEnabled = true;
            this.filePrefix.Items.AddRange(new object[] {
            "$boarddir",
            "$sourcedir",
            "$themedir",
            "$languagedir",
            "$avatardir",
            "$imagesdir"});
            this.filePrefix.Location = new System.Drawing.Point(12, 65);
            this.filePrefix.Name = "filePrefix";
            this.filePrefix.Size = new System.Drawing.Size(121, 21);
            this.filePrefix.TabIndex = 4;
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(157, 66);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(325, 20);
            this.fileName.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "/";
            // 
            // addExtractionInstructionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 135);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.filePrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(511, 174);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(511, 174);
            this.Name = "addExtractionInstructionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add or edit an extract instruction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox filePrefix;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
    }
}