namespace ModBuilder.Forms
{
    partial class Updater
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
            this.label1 = new System.Windows.Forms.Label();
            this.informationIcon = new System.Windows.Forms.PictureBox();
            this.installedVer = new System.Windows.Forms.Label();
            this.availableVer = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.remindButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changelog = new System.Windows.Forms.RichTextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.informationIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A new version of Mod Builder is available!";
            // 
            // informationIcon
            // 
            this.informationIcon.Location = new System.Drawing.Point(12, 12);
            this.informationIcon.Name = "informationIcon";
            this.informationIcon.Size = new System.Drawing.Size(32, 32);
            this.informationIcon.TabIndex = 1;
            this.informationIcon.TabStop = false;
            // 
            // installedVer
            // 
            this.installedVer.AutoSize = true;
            this.installedVer.Location = new System.Drawing.Point(64, 49);
            this.installedVer.Name = "installedVer";
            this.installedVer.Size = new System.Drawing.Size(86, 13);
            this.installedVer.TabIndex = 2;
            this.installedVer.Text = "Installed version:";
            // 
            // availableVer
            // 
            this.availableVer.AutoSize = true;
            this.availableVer.Location = new System.Drawing.Point(64, 62);
            this.availableVer.Name = "availableVer";
            this.availableVer.Size = new System.Drawing.Size(90, 13);
            this.availableVer.TabIndex = 3;
            this.availableVer.Text = "Available version:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(410, 11);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(88, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Update now!";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // remindButton
            // 
            this.remindButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.remindButton.Location = new System.Drawing.Point(292, 11);
            this.remindButton.Name = "remindButton";
            this.remindButton.Size = new System.Drawing.Size(112, 23);
            this.remindButton.TabIndex = 5;
            this.remindButton.Text = "Remind me later";
            this.remindButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show changelog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.remindButton);
            this.panel1.Controls.Add(this.progress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 46);
            this.panel1.TabIndex = 7;
            // 
            // changelog
            // 
            this.changelog.Location = new System.Drawing.Point(12, 100);
            this.changelog.Name = "changelog";
            this.changelog.Size = new System.Drawing.Size(486, 246);
            this.changelog.TabIndex = 8;
            this.changelog.Text = "";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 11);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(255, 23);
            this.progress.TabIndex = 7;
            this.progress.Visible = false;
            // 
            // Updater
            // 
            this.AcceptButton = this.updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.remindButton;
            this.ClientSize = new System.Drawing.Size(510, 143);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.availableVer);
            this.Controls.Add(this.installedVer);
            this.Controls.Add(this.informationIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changelog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.Text = "Updater";
            this.Load += new System.EventHandler(this.Updater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.informationIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox informationIcon;
        private System.Windows.Forms.Label installedVer;
        private System.Windows.Forms.Label availableVer;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button remindButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox changelog;
        private System.Windows.Forms.ProgressBar progress;
    }
}