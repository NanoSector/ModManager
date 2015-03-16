namespace Mod_Builder.Forms
{
    partial class About
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
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewLicense = new System.Windows.Forms.Button();
            this.fugueLink = new System.Windows.Forms.LinkLabel();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(403, 126);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(71, 26);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mod Builder - A tool to build modifications for SMF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(c) 2015 Rick \"NanoSector\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Some icons by Yusuke Kamiyamane. Licensed under a Creative Commons Attribution 3." +
    "0 License.";
            // 
            // viewLicense
            // 
            this.viewLicense.Location = new System.Drawing.Point(281, 126);
            this.viewLicense.Name = "viewLicense";
            this.viewLicense.Size = new System.Drawing.Size(99, 25);
            this.viewLicense.TabIndex = 5;
            this.viewLicense.Text = "View license";
            this.viewLicense.UseVisualStyleBackColor = true;
            this.viewLicense.Click += new System.EventHandler(this.viewLicense_Click);
            // 
            // fugueLink
            // 
            this.fugueLink.AutoSize = true;
            this.fugueLink.Location = new System.Drawing.Point(12, 105);
            this.fugueLink.Name = "fugueLink";
            this.fugueLink.Size = new System.Drawing.Size(170, 13);
            this.fugueLink.TabIndex = 6;
            this.fugueLink.TabStop = true;
            this.fugueLink.Text = "Admire the awesome Fugue Icons!";
            this.fugueLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.fugueLink_LinkClicked);
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(12, 132);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(104, 13);
            this.githubLink.TabIndex = 7;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "Available on GitHub!";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mod Builder is licensed under the MIT license.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mod_Builder.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(32, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 36);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 164);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.fugueLink);
            this.Controls.Add(this.viewLicense);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Mod Builder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewLicense;
        private System.Windows.Forms.LinkLabel fugueLink;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}