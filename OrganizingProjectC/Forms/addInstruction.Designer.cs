namespace OrganizingProjectC
{
    partial class addInstruction
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
            this.before = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.after = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optionalCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.method = new System.Windows.Forms.ComboBox();
            this.fileEdited = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // before
            // 
            this.before.Location = new System.Drawing.Point(12, 25);
            this.before.Multiline = true;
            this.before.Name = "before";
            this.before.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.before.Size = new System.Drawing.Size(235, 238);
            this.before.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code before:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code after:";
            // 
            // after
            // 
            this.after.Location = new System.Drawing.Point(271, 25);
            this.after.Multiline = true;
            this.after.Name = "after";
            this.after.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.after.Size = new System.Drawing.Size(253, 238);
            this.after.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.optionalCheck);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.method);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 33);
            this.panel1.TabIndex = 4;
            // 
            // optionalCheck
            // 
            this.optionalCheck.AutoSize = true;
            this.optionalCheck.Location = new System.Drawing.Point(217, 8);
            this.optionalCheck.Name = "optionalCheck";
            this.optionalCheck.Size = new System.Drawing.Size(65, 17);
            this.optionalCheck.TabIndex = 4;
            this.optionalCheck.Text = "Optional";
            this.optionalCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Method:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(449, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Items.AddRange(new object[] {
            "Replace",
            "Add before",
            "Add after",
            "At the end of file"});
            this.method.Location = new System.Drawing.Point(64, 7);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(147, 21);
            this.method.TabIndex = 0;
            this.method.Text = "Replace";
            this.method.SelectedIndexChanged += new System.EventHandler(this.method_SelectedIndexChanged);
            // 
            // fileEdited
            // 
            this.fileEdited.Location = new System.Drawing.Point(133, 272);
            this.fileEdited.Name = "fileEdited";
            this.fileEdited.Size = new System.Drawing.Size(391, 20);
            this.fileEdited.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File to be edited: ROOT/";
            // 
            // addInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 331);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileEdited);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.after);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.before);
            this.Name = "addInstruction";
            this.Text = "Add/edit an instruction";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox before;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox after;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fileEdited;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox optionalCheck;
    }
}