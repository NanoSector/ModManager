namespace ModBuilder.Forms
{
    partial class addDeletionInstructionDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.filePrefix = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.whatIs_File = new System.Windows.Forms.RadioButton();
            this.whatIs_Dir = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "/";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(150, 33);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(325, 20);
            this.fileName.TabIndex = 14;
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
            this.filePrefix.Location = new System.Drawing.Point(5, 32);
            this.filePrefix.Name = "filePrefix";
            this.filePrefix.Size = new System.Drawing.Size(121, 21);
            this.filePrefix.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "File/directory:";
            // 
            // whatIs_File
            // 
            this.whatIs_File.AutoSize = true;
            this.whatIs_File.Checked = true;
            this.whatIs_File.Location = new System.Drawing.Point(12, 68);
            this.whatIs_File.Name = "whatIs_File";
            this.whatIs_File.Size = new System.Drawing.Size(41, 17);
            this.whatIs_File.TabIndex = 18;
            this.whatIs_File.TabStop = true;
            this.whatIs_File.Text = "File";
            this.whatIs_File.UseVisualStyleBackColor = true;
            this.whatIs_File.CheckedChanged += new System.EventHandler(this.whatIs_File_CheckedChanged);
            // 
            // whatIs_Dir
            // 
            this.whatIs_Dir.AutoSize = true;
            this.whatIs_Dir.Location = new System.Drawing.Point(68, 68);
            this.whatIs_Dir.Name = "whatIs_Dir";
            this.whatIs_Dir.Size = new System.Drawing.Size(67, 17);
            this.whatIs_Dir.TabIndex = 19;
            this.whatIs_Dir.Text = "Directory";
            this.whatIs_Dir.UseVisualStyleBackColor = true;
            this.whatIs_Dir.CheckedChanged += new System.EventHandler(this.whatIs_Dir_CheckedChanged);
            // 
            // addDeletionInstructionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 99);
            this.Controls.Add(this.whatIs_Dir);
            this.Controls.Add(this.whatIs_File);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.filePrefix);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 137);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 137);
            this.Name = "addDeletionInstructionDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "addDeletionInstructionDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.ComboBox filePrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton whatIs_File;
        private System.Windows.Forms.RadioButton whatIs_Dir;
    }
}