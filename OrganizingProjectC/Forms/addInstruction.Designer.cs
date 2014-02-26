namespace ModBuilder
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
            this.labelBefore = new System.Windows.Forms.Label();
            this.labelAfter = new System.Windows.Forms.Label();
            this.after = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.testInstruction = new System.Windows.Forms.Button();
            this.optionalCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.method = new System.Windows.Forms.ComboBox();
            this.fileEdited = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.filePrefix = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // before
            // 
            this.before.Dock = System.Windows.Forms.DockStyle.Fill;
            this.before.Location = new System.Drawing.Point(0, 13);
            this.before.Multiline = true;
            this.before.Name = "before";
            this.before.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.before.Size = new System.Drawing.Size(418, 328);
            this.before.TabIndex = 0;
            this.before.WordWrap = false;
            // 
            // labelBefore
            // 
            this.labelBefore.AutoSize = true;
            this.labelBefore.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBefore.Location = new System.Drawing.Point(0, 0);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(68, 13);
            this.labelBefore.TabIndex = 1;
            this.labelBefore.Text = "Code before:";
            // 
            // labelAfter
            // 
            this.labelAfter.AutoSize = true;
            this.labelAfter.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAfter.Location = new System.Drawing.Point(0, 0);
            this.labelAfter.Name = "labelAfter";
            this.labelAfter.Size = new System.Drawing.Size(59, 13);
            this.labelAfter.TabIndex = 2;
            this.labelAfter.Text = "Code after:";
            // 
            // after
            // 
            this.after.Dock = System.Windows.Forms.DockStyle.Fill;
            this.after.Location = new System.Drawing.Point(0, 13);
            this.after.Multiline = true;
            this.after.Name = "after";
            this.after.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.after.Size = new System.Drawing.Size(427, 328);
            this.after.TabIndex = 3;
            this.after.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.testInstruction);
            this.panel1.Controls.Add(this.optionalCheck);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.method);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 26);
            this.panel1.TabIndex = 4;
            // 
            // testInstruction
            // 
            this.testInstruction.Dock = System.Windows.Forms.DockStyle.Right;
            this.testInstruction.Location = new System.Drawing.Point(555, 0);
            this.testInstruction.Name = "testInstruction";
            this.testInstruction.Size = new System.Drawing.Size(126, 26);
            this.testInstruction.TabIndex = 5;
            this.testInstruction.Text = "Test instruction";
            this.testInstruction.UseVisualStyleBackColor = true;
            this.testInstruction.Click += new System.EventHandler(this.testInstruction_Click);
            // 
            // optionalCheck
            // 
            this.optionalCheck.AutoSize = true;
            this.optionalCheck.Location = new System.Drawing.Point(217, 5);
            this.optionalCheck.Name = "optionalCheck";
            this.optionalCheck.Size = new System.Drawing.Size(65, 17);
            this.optionalCheck.TabIndex = 4;
            this.optionalCheck.Text = "Optional";
            this.optionalCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Method:";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(681, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(756, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 26);
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
            this.method.Location = new System.Drawing.Point(64, 3);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(147, 21);
            this.method.TabIndex = 0;
            this.method.Text = "Replace";
            this.method.SelectedIndexChanged += new System.EventHandler(this.method_SelectedIndexChanged);
            // 
            // fileEdited
            // 
            this.fileEdited.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileEdited.Location = new System.Drawing.Point(276, 7);
            this.fileEdited.Name = "fileEdited";
            this.fileEdited.Size = new System.Drawing.Size(555, 20);
            this.fileEdited.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File to be edited:";
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
            this.filePrefix.Location = new System.Drawing.Point(94, 7);
            this.filePrefix.Name = "filePrefix";
            this.filePrefix.Size = new System.Drawing.Size(157, 21);
            this.filePrefix.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "/";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.before);
            this.splitContainer1.Panel1.Controls.Add(this.labelBefore);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.after);
            this.splitContainer1.Panel2.Controls.Add(this.labelAfter);
            this.splitContainer1.Size = new System.Drawing.Size(849, 341);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.fileEdited);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.filePrefix);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 35);
            this.panel2.TabIndex = 10;
            // 
            // addInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 402);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "addInstruction";
            this.Text = "Add/edit an instruction";
            this.Load += new System.EventHandler(this.addInstruction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox before;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.Label labelAfter;
        private System.Windows.Forms.TextBox after;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fileEdited;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox optionalCheck;
        private System.Windows.Forms.ComboBox filePrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button testInstruction;
    }
}