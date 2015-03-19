namespace Mod_Builder.Forms
{
    partial class InstructionEditor
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.inst_name = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.optional = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.methodEnd = new System.Windows.Forms.RadioButton();
            this.methodBefore = new System.Windows.Forms.RadioButton();
            this.methodAfter = new System.Windows.Forms.RadioButton();
            this.methodReplace = new System.Windows.Forms.RadioButton();
            this.methodLabel = new System.Windows.Forms.Label();
            this.fileToEditLabel = new System.Windows.Forms.Label();
            this.inst_fileprefix = new System.Windows.Forms.ComboBox();
            this.inst_filename = new System.Windows.Forms.TextBox();
            this.textContainers = new System.Windows.Forms.SplitContainer();
            this.leftTextBox = new System.Windows.Forms.TextBox();
            this.leftLabel = new System.Windows.Forms.Label();
            this.rightTextBox = new System.Windows.Forms.TextBox();
            this.rightLabel = new System.Windows.Forms.Label();
            this.errorBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textContainers)).BeginInit();
            this.textContainers.Panel1.SuspendLayout();
            this.textContainers.Panel2.SuspendLayout();
            this.textContainers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.separatorLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.inst_name);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.optional);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.methodLabel);
            this.panel1.Controls.Add(this.fileToEditLabel);
            this.panel1.Controls.Add(this.inst_fileprefix);
            this.panel1.Controls.Add(this.inst_filename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 99);
            this.panel1.TabIndex = 0;
            // 
            // separatorLabel
            // 
            this.separatorLabel.AutoSize = true;
            this.separatorLabel.Location = new System.Drawing.Point(304, 9);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(12, 13);
            this.separatorLabel.TabIndex = 10;
            this.separatorLabel.Text = "/";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(176, 76);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(95, 13);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "inst_custom_name";
            // 
            // inst_name
            // 
            this.inst_name.Location = new System.Drawing.Point(430, 74);
            this.inst_name.Name = "inst_name";
            this.inst_name.Size = new System.Drawing.Size(236, 20);
            this.inst_name.TabIndex = 8;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(757, 71);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(108, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(871, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // optional
            // 
            this.optional.AutoSize = true;
            this.optional.Location = new System.Drawing.Point(757, 48);
            this.optional.Name = "optional";
            this.optional.Size = new System.Drawing.Size(85, 17);
            this.optional.TabIndex = 5;
            this.optional.Text = "inst_optional";
            this.optional.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.methodEnd);
            this.panel2.Controls.Add(this.methodBefore);
            this.panel2.Controls.Add(this.methodAfter);
            this.panel2.Controls.Add(this.methodReplace);
            this.panel2.Location = new System.Drawing.Point(179, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 34);
            this.panel2.TabIndex = 4;
            // 
            // methodEnd
            // 
            this.methodEnd.AutoSize = true;
            this.methodEnd.Location = new System.Drawing.Point(335, 10);
            this.methodEnd.Name = "methodEnd";
            this.methodEnd.Size = new System.Drawing.Size(65, 17);
            this.methodEnd.TabIndex = 3;
            this.methodEnd.Text = "inst_end";
            this.methodEnd.UseVisualStyleBackColor = true;
            // 
            // methodBefore
            // 
            this.methodBefore.AutoSize = true;
            this.methodBefore.Location = new System.Drawing.Point(214, 10);
            this.methodBefore.Name = "methodBefore";
            this.methodBefore.Size = new System.Drawing.Size(77, 17);
            this.methodBefore.TabIndex = 2;
            this.methodBefore.Text = "inst_before";
            this.methodBefore.UseVisualStyleBackColor = true;
            // 
            // methodAfter
            // 
            this.methodAfter.AutoSize = true;
            this.methodAfter.Location = new System.Drawing.Point(104, 10);
            this.methodAfter.Name = "methodAfter";
            this.methodAfter.Size = new System.Drawing.Size(68, 17);
            this.methodAfter.TabIndex = 1;
            this.methodAfter.Text = "inst_after";
            this.methodAfter.UseVisualStyleBackColor = true;
            // 
            // methodReplace
            // 
            this.methodReplace.AutoSize = true;
            this.methodReplace.Checked = true;
            this.methodReplace.Location = new System.Drawing.Point(3, 10);
            this.methodReplace.Name = "methodReplace";
            this.methodReplace.Size = new System.Drawing.Size(82, 17);
            this.methodReplace.TabIndex = 0;
            this.methodReplace.TabStop = true;
            this.methodReplace.Text = "inst_replace";
            this.methodReplace.UseVisualStyleBackColor = true;
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(12, 45);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(64, 13);
            this.methodLabel.TabIndex = 3;
            this.methodLabel.Text = "inst_method";
            // 
            // fileToEditLabel
            // 
            this.fileToEditLabel.AutoSize = true;
            this.fileToEditLabel.Location = new System.Drawing.Point(12, 9);
            this.fileToEditLabel.Name = "fileToEditLabel";
            this.fileToEditLabel.Size = new System.Drawing.Size(68, 13);
            this.fileToEditLabel.TabIndex = 2;
            this.fileToEditLabel.Text = "inst_filetoedit";
            // 
            // inst_fileprefix
            // 
            this.inst_fileprefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inst_fileprefix.FormattingEnabled = true;
            this.inst_fileprefix.Items.AddRange(new object[] {
            "$boarddir",
            "$sourcedir",
            "$themedir",
            "$languagedir",
            "$avatardir",
            "$imagesdir"});
            this.inst_fileprefix.Location = new System.Drawing.Point(179, 6);
            this.inst_fileprefix.Name = "inst_fileprefix";
            this.inst_fileprefix.Size = new System.Drawing.Size(121, 21);
            this.inst_fileprefix.TabIndex = 1;
            // 
            // inst_filename
            // 
            this.inst_filename.Location = new System.Drawing.Point(322, 7);
            this.inst_filename.Name = "inst_filename";
            this.inst_filename.Size = new System.Drawing.Size(293, 20);
            this.inst_filename.TabIndex = 0;
            // 
            // textContainers
            // 
            this.textContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textContainers.Location = new System.Drawing.Point(0, 0);
            this.textContainers.Name = "textContainers";
            // 
            // textContainers.Panel1
            // 
            this.textContainers.Panel1.Controls.Add(this.leftTextBox);
            this.textContainers.Panel1.Controls.Add(this.leftLabel);
            // 
            // textContainers.Panel2
            // 
            this.textContainers.Panel2.Controls.Add(this.rightTextBox);
            this.textContainers.Panel2.Controls.Add(this.rightLabel);
            this.textContainers.Size = new System.Drawing.Size(958, 481);
            this.textContainers.SplitterDistance = 478;
            this.textContainers.TabIndex = 1;
            // 
            // leftTextBox
            // 
            this.leftTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTextBox.Location = new System.Drawing.Point(0, 13);
            this.leftTextBox.Multiline = true;
            this.leftTextBox.Name = "leftTextBox";
            this.leftTextBox.Size = new System.Drawing.Size(478, 468);
            this.leftTextBox.TabIndex = 1;
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftLabel.Location = new System.Drawing.Point(0, 0);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(46, 13);
            this.leftLabel.TabIndex = 0;
            this.leftLabel.Text = "inst_find";
            // 
            // rightTextBox
            // 
            this.rightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTextBox.Location = new System.Drawing.Point(0, 13);
            this.rightTextBox.Multiline = true;
            this.rightTextBox.Name = "rightTextBox";
            this.rightTextBox.Size = new System.Drawing.Size(476, 468);
            this.rightTextBox.TabIndex = 2;
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightLabel.Location = new System.Drawing.Point(0, 0);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(323, 13);
            this.rightLabel.TabIndex = 1;
            this.rightLabel.Text = "inst_replacewith / inst_add_after / inst_add_before / inst_add_end";
            // 
            // errorBalloon
            // 
            this.errorBalloon.IsBalloon = true;
            // 
            // InstructionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(958, 580);
            this.Controls.Add(this.textContainers);
            this.Controls.Add(this.panel1);
            this.Name = "InstructionEditor";
            this.Text = "Edit Instruction";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.textContainers.Panel1.ResumeLayout(false);
            this.textContainers.Panel1.PerformLayout();
            this.textContainers.Panel2.ResumeLayout(false);
            this.textContainers.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textContainers)).EndInit();
            this.textContainers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer textContainers;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Label fileToEditLabel;
        private System.Windows.Forms.ComboBox inst_fileprefix;
        private System.Windows.Forms.TextBox inst_filename;
        private System.Windows.Forms.TextBox leftTextBox;
        private System.Windows.Forms.TextBox rightTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox optional;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton methodEnd;
        private System.Windows.Forms.RadioButton methodBefore;
        private System.Windows.Forms.RadioButton methodAfter;
        private System.Windows.Forms.RadioButton methodReplace;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox inst_name;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.ToolTip errorBalloon;
    }
}