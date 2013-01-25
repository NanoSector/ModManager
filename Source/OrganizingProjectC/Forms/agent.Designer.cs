namespace ModBuilder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.editProjectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.repairProject = new System.Windows.Forms.Button();
            this.createProjectFromPackage = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.supportLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose a task...";
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(15, 25);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(243, 30);
            this.createProjectButton.TabIndex = 2;
            this.createProjectButton.Text = "Create a new project";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // editProjectButton
            // 
            this.editProjectButton.Location = new System.Drawing.Point(15, 61);
            this.editProjectButton.Name = "editProjectButton";
            this.editProjectButton.Size = new System.Drawing.Size(243, 30);
            this.editProjectButton.TabIndex = 3;
            this.editProjectButton.Text = "Edit a project";
            this.editProjectButton.UseVisualStyleBackColor = true;
            this.editProjectButton.Click += new System.EventHandler(this.editProjectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "(c) 2013 - Rick \"Yoshi2889\" Kerkhof";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(881, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "What are you looking for?";
            // 
            // repairProject
            // 
            this.repairProject.Location = new System.Drawing.Point(15, 97);
            this.repairProject.Name = "repairProject";
            this.repairProject.Size = new System.Drawing.Size(243, 29);
            this.repairProject.TabIndex = 6;
            this.repairProject.Text = "Repair a project";
            this.repairProject.UseVisualStyleBackColor = true;
            this.repairProject.Click += new System.EventHandler(this.repairProject_Click);
            // 
            // createProjectFromPackage
            // 
            this.createProjectFromPackage.Enabled = false;
            this.createProjectFromPackage.Location = new System.Drawing.Point(15, 132);
            this.createProjectFromPackage.Name = "createProjectFromPackage";
            this.createProjectFromPackage.Size = new System.Drawing.Size(243, 32);
            this.createProjectFromPackage.TabIndex = 7;
            this.createProjectFromPackage.Text = "Create project from package (unfinished)";
            this.createProjectFromPackage.UseVisualStyleBackColor = true;
            this.createProjectFromPackage.Click += new System.EventHandler(this.createProjectFromPackage_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(12, 203);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(103, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Check for updates...";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Downloading update...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 260);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(246, 17);
            this.progressBar1.TabIndex = 11;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(222, 9);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(26, 13);
            this.versionLabel.TabIndex = 13;
            this.versionLabel.Text = "vx.x";
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "________________________________________";
            // 
            // supportLink
            // 
            this.supportLink.AutoSize = true;
            this.supportLink.Location = new System.Drawing.Point(214, 203);
            this.supportLink.Name = "supportLink";
            this.supportLink.Size = new System.Drawing.Size(44, 13);
            this.supportLink.TabIndex = 15;
            this.supportLink.TabStop = true;
            this.supportLink.Text = "Support";
            this.supportLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.supportLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 225);
            this.Controls.Add(this.supportLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.createProjectFromPackage);
            this.Controls.Add(this.repairProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editProjectButton);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Mod Manager Agent";
            this.Shown += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createProjectButton;
        private System.Windows.Forms.Button editProjectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button repairProject;
        private System.Windows.Forms.Button createProjectFromPackage;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel supportLink;
    }
}

