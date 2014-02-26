namespace ModBuilder.Forms
{
    partial class convertProject
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
            this.outputDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseOutputDirectory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cleanReadme = new System.Windows.Forms.Button();
            this.cleanInstall = new System.Windows.Forms.Button();
            this.cleanInstallCode = new System.Windows.Forms.Button();
            this.cleanDeinstallCode = new System.Windows.Forms.Button();
            this.cleanDBInstall = new System.Windows.Forms.Button();
            this.cleanDBDeinstall = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.readmeTXTPath = new System.Windows.Forms.TextBox();
            this.browseReadmeTXT = new System.Windows.Forms.Button();
            this.uninstallDatabaseLabel = new System.Windows.Forms.Label();
            this.uninstallDatabasePHPPath = new System.Windows.Forms.TextBox();
            this.browseUninstallDatabasePHP = new System.Windows.Forms.Button();
            this.installDatabasePHPLabel = new System.Windows.Forms.Label();
            this.installDatabasePHPPath = new System.Windows.Forms.TextBox();
            this.browseInstallDatabasePHP = new System.Windows.Forms.Button();
            this.uninstallPHPLabel = new System.Windows.Forms.Label();
            this.uninstallPHPPath = new System.Windows.Forms.TextBox();
            this.browseUninstallPHP = new System.Windows.Forms.Button();
            this.installPHPLabel = new System.Windows.Forms.Label();
            this.installPHPPath = new System.Windows.Forms.TextBox();
            this.browseInstallPHP = new System.Windows.Forms.Button();
            this.installationInstructionsLabel = new System.Windows.Forms.Label();
            this.installXmlPath = new System.Windows.Forms.TextBox();
            this.browseInstallXML = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.packageInfoXMLPath = new System.Windows.Forms.TextBox();
            this.browsePackageInfoXML = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.packageInputPath = new System.Windows.Forms.TextBox();
            this.browseInputPackageDirectory = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.cvWorking = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select the appropriate files in your package. Items in bold are required.";
            // 
            // outputDirectory
            // 
            this.outputDirectory.Location = new System.Drawing.Point(173, 25);
            this.outputDirectory.Name = "outputDirectory";
            this.outputDirectory.ReadOnly = true;
            this.outputDirectory.Size = new System.Drawing.Size(601, 20);
            this.outputDirectory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output directory:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseOutputDirectory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.outputDirectory);
            this.groupBox1.Location = new System.Drawing.Point(15, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project";
            // 
            // browseOutputDirectory
            // 
            this.browseOutputDirectory.Location = new System.Drawing.Point(780, 23);
            this.browseOutputDirectory.Name = "browseOutputDirectory";
            this.browseOutputDirectory.Size = new System.Drawing.Size(75, 23);
            this.browseOutputDirectory.TabIndex = 3;
            this.browseOutputDirectory.Text = "Browse";
            this.browseOutputDirectory.UseVisualStyleBackColor = true;
            this.browseOutputDirectory.Click += new System.EventHandler(this.browseOutputDirectory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cleanReadme);
            this.groupBox2.Controls.Add(this.cleanInstall);
            this.groupBox2.Controls.Add(this.cleanInstallCode);
            this.groupBox2.Controls.Add(this.cleanDeinstallCode);
            this.groupBox2.Controls.Add(this.cleanDBInstall);
            this.groupBox2.Controls.Add(this.cleanDBDeinstall);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.readmeTXTPath);
            this.groupBox2.Controls.Add(this.browseReadmeTXT);
            this.groupBox2.Controls.Add(this.uninstallDatabaseLabel);
            this.groupBox2.Controls.Add(this.uninstallDatabasePHPPath);
            this.groupBox2.Controls.Add(this.browseUninstallDatabasePHP);
            this.groupBox2.Controls.Add(this.installDatabasePHPLabel);
            this.groupBox2.Controls.Add(this.installDatabasePHPPath);
            this.groupBox2.Controls.Add(this.browseInstallDatabasePHP);
            this.groupBox2.Controls.Add(this.uninstallPHPLabel);
            this.groupBox2.Controls.Add(this.uninstallPHPPath);
            this.groupBox2.Controls.Add(this.browseUninstallPHP);
            this.groupBox2.Controls.Add(this.installPHPLabel);
            this.groupBox2.Controls.Add(this.installPHPPath);
            this.groupBox2.Controls.Add(this.browseInstallPHP);
            this.groupBox2.Controls.Add(this.installationInstructionsLabel);
            this.groupBox2.Controls.Add(this.installXmlPath);
            this.groupBox2.Controls.Add(this.browseInstallXML);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.packageInfoXMLPath);
            this.groupBox2.Controls.Add(this.browsePackageInfoXML);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.packageInputPath);
            this.groupBox2.Controls.Add(this.browseInputPackageDirectory);
            this.groupBox2.Location = new System.Drawing.Point(15, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(861, 379);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Package";
            // 
            // cleanReadme
            // 
            this.cleanReadme.Location = new System.Drawing.Point(747, 129);
            this.cleanReadme.Name = "cleanReadme";
            this.cleanReadme.Size = new System.Drawing.Size(27, 23);
            this.cleanReadme.TabIndex = 35;
            this.cleanReadme.Text = "-";
            this.cleanReadme.UseVisualStyleBackColor = true;
            this.cleanReadme.Click += new System.EventHandler(this.cleanReadme_Click);
            // 
            // cleanInstall
            // 
            this.cleanInstall.Location = new System.Drawing.Point(747, 170);
            this.cleanInstall.Name = "cleanInstall";
            this.cleanInstall.Size = new System.Drawing.Size(27, 23);
            this.cleanInstall.TabIndex = 34;
            this.cleanInstall.Text = "-";
            this.cleanInstall.UseVisualStyleBackColor = true;
            this.cleanInstall.Click += new System.EventHandler(this.cleanInstall_Click);
            // 
            // cleanInstallCode
            // 
            this.cleanInstallCode.Location = new System.Drawing.Point(747, 212);
            this.cleanInstallCode.Name = "cleanInstallCode";
            this.cleanInstallCode.Size = new System.Drawing.Size(27, 23);
            this.cleanInstallCode.TabIndex = 33;
            this.cleanInstallCode.Text = "-";
            this.cleanInstallCode.UseVisualStyleBackColor = true;
            this.cleanInstallCode.Click += new System.EventHandler(this.cleanInstallCode_Click);
            // 
            // cleanDeinstallCode
            // 
            this.cleanDeinstallCode.Location = new System.Drawing.Point(747, 254);
            this.cleanDeinstallCode.Name = "cleanDeinstallCode";
            this.cleanDeinstallCode.Size = new System.Drawing.Size(27, 23);
            this.cleanDeinstallCode.TabIndex = 32;
            this.cleanDeinstallCode.Text = "-";
            this.cleanDeinstallCode.UseVisualStyleBackColor = true;
            this.cleanDeinstallCode.Click += new System.EventHandler(this.cleanDeinstallCode_Click);
            // 
            // cleanDBInstall
            // 
            this.cleanDBInstall.Location = new System.Drawing.Point(747, 296);
            this.cleanDBInstall.Name = "cleanDBInstall";
            this.cleanDBInstall.Size = new System.Drawing.Size(27, 23);
            this.cleanDBInstall.TabIndex = 30;
            this.cleanDBInstall.Text = "-";
            this.cleanDBInstall.UseVisualStyleBackColor = true;
            this.cleanDBInstall.Click += new System.EventHandler(this.cleanDBInstall_Click);
            // 
            // cleanDBDeinstall
            // 
            this.cleanDBDeinstall.Location = new System.Drawing.Point(747, 339);
            this.cleanDBDeinstall.Name = "cleanDBDeinstall";
            this.cleanDBDeinstall.Size = new System.Drawing.Size(27, 23);
            this.cleanDBDeinstall.TabIndex = 29;
            this.cleanDBDeinstall.Text = "-";
            this.cleanDBDeinstall.UseVisualStyleBackColor = true;
            this.cleanDBDeinstall.Click += new System.EventHandler(this.cleanDBDeinstall_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 26);
            this.label6.TabIndex = 27;
            this.label6.Text = "Readme file:\r\n(e.g. readme.txt)";
            // 
            // readmeTXTPath
            // 
            this.readmeTXTPath.Location = new System.Drawing.Point(173, 131);
            this.readmeTXTPath.Name = "readmeTXTPath";
            this.readmeTXTPath.ReadOnly = true;
            this.readmeTXTPath.Size = new System.Drawing.Size(568, 20);
            this.readmeTXTPath.TabIndex = 26;
            // 
            // browseReadmeTXT
            // 
            this.browseReadmeTXT.Location = new System.Drawing.Point(780, 129);
            this.browseReadmeTXT.Name = "browseReadmeTXT";
            this.browseReadmeTXT.Size = new System.Drawing.Size(75, 23);
            this.browseReadmeTXT.TabIndex = 25;
            this.browseReadmeTXT.Text = "Browse";
            this.browseReadmeTXT.UseVisualStyleBackColor = true;
            this.browseReadmeTXT.Click += new System.EventHandler(this.browseReadmeTXT_Click);
            // 
            // uninstallDatabaseLabel
            // 
            this.uninstallDatabaseLabel.AutoSize = true;
            this.uninstallDatabaseLabel.BackColor = System.Drawing.Color.Transparent;
            this.uninstallDatabaseLabel.Location = new System.Drawing.Point(23, 344);
            this.uninstallDatabaseLabel.Name = "uninstallDatabaseLabel";
            this.uninstallDatabaseLabel.Size = new System.Drawing.Size(139, 26);
            this.uninstallDatabaseLabel.TabIndex = 24;
            this.uninstallDatabaseLabel.Text = "Database deinstallation:\r\n(e.g. uninstallDatabase.php)";
            // 
            // uninstallDatabasePHPPath
            // 
            this.uninstallDatabasePHPPath.Location = new System.Drawing.Point(173, 341);
            this.uninstallDatabasePHPPath.Name = "uninstallDatabasePHPPath";
            this.uninstallDatabasePHPPath.ReadOnly = true;
            this.uninstallDatabasePHPPath.Size = new System.Drawing.Size(568, 20);
            this.uninstallDatabasePHPPath.TabIndex = 23;
            // 
            // browseUninstallDatabasePHP
            // 
            this.browseUninstallDatabasePHP.Location = new System.Drawing.Point(780, 339);
            this.browseUninstallDatabasePHP.Name = "browseUninstallDatabasePHP";
            this.browseUninstallDatabasePHP.Size = new System.Drawing.Size(75, 23);
            this.browseUninstallDatabasePHP.TabIndex = 22;
            this.browseUninstallDatabasePHP.Text = "Browse";
            this.browseUninstallDatabasePHP.UseVisualStyleBackColor = true;
            this.browseUninstallDatabasePHP.Click += new System.EventHandler(this.browseUninstallDatabasePHP_Click);
            // 
            // installDatabasePHPLabel
            // 
            this.installDatabasePHPLabel.AutoSize = true;
            this.installDatabasePHPLabel.Location = new System.Drawing.Point(23, 301);
            this.installDatabasePHPLabel.Name = "installDatabasePHPLabel";
            this.installDatabasePHPLabel.Size = new System.Drawing.Size(127, 26);
            this.installDatabasePHPLabel.TabIndex = 21;
            this.installDatabasePHPLabel.Text = "Database installation:\r\n(e.g. installDatabase.php)";
            // 
            // installDatabasePHPPath
            // 
            this.installDatabasePHPPath.Location = new System.Drawing.Point(173, 298);
            this.installDatabasePHPPath.Name = "installDatabasePHPPath";
            this.installDatabasePHPPath.ReadOnly = true;
            this.installDatabasePHPPath.Size = new System.Drawing.Size(568, 20);
            this.installDatabasePHPPath.TabIndex = 20;
            // 
            // browseInstallDatabasePHP
            // 
            this.browseInstallDatabasePHP.Location = new System.Drawing.Point(780, 296);
            this.browseInstallDatabasePHP.Name = "browseInstallDatabasePHP";
            this.browseInstallDatabasePHP.Size = new System.Drawing.Size(75, 23);
            this.browseInstallDatabasePHP.TabIndex = 19;
            this.browseInstallDatabasePHP.Text = "Browse";
            this.browseInstallDatabasePHP.UseVisualStyleBackColor = true;
            this.browseInstallDatabasePHP.Click += new System.EventHandler(this.browseInstallDatabasePHP_Click);
            // 
            // uninstallPHPLabel
            // 
            this.uninstallPHPLabel.AutoSize = true;
            this.uninstallPHPLabel.Location = new System.Drawing.Point(23, 259);
            this.uninstallPHPLabel.Name = "uninstallPHPLabel";
            this.uninstallPHPLabel.Size = new System.Drawing.Size(100, 26);
            this.uninstallPHPLabel.TabIndex = 18;
            this.uninstallPHPLabel.Text = "Deinstallation code:\r\n(e.g. uninstall.php)";
            // 
            // uninstallPHPPath
            // 
            this.uninstallPHPPath.Location = new System.Drawing.Point(173, 256);
            this.uninstallPHPPath.Name = "uninstallPHPPath";
            this.uninstallPHPPath.ReadOnly = true;
            this.uninstallPHPPath.Size = new System.Drawing.Size(568, 20);
            this.uninstallPHPPath.TabIndex = 17;
            // 
            // browseUninstallPHP
            // 
            this.browseUninstallPHP.Location = new System.Drawing.Point(780, 254);
            this.browseUninstallPHP.Name = "browseUninstallPHP";
            this.browseUninstallPHP.Size = new System.Drawing.Size(75, 23);
            this.browseUninstallPHP.TabIndex = 16;
            this.browseUninstallPHP.Text = "Browse";
            this.browseUninstallPHP.UseVisualStyleBackColor = true;
            this.browseUninstallPHP.Click += new System.EventHandler(this.browseUninstallPHP_Click);
            // 
            // installPHPLabel
            // 
            this.installPHPLabel.AutoSize = true;
            this.installPHPLabel.Location = new System.Drawing.Point(23, 217);
            this.installPHPLabel.Name = "installPHPLabel";
            this.installPHPLabel.Size = new System.Drawing.Size(87, 26);
            this.installPHPLabel.TabIndex = 15;
            this.installPHPLabel.Text = "Installation code:\r\n(e.g. install.php)";
            // 
            // installPHPPath
            // 
            this.installPHPPath.Location = new System.Drawing.Point(173, 214);
            this.installPHPPath.Name = "installPHPPath";
            this.installPHPPath.ReadOnly = true;
            this.installPHPPath.Size = new System.Drawing.Size(568, 20);
            this.installPHPPath.TabIndex = 14;
            // 
            // browseInstallPHP
            // 
            this.browseInstallPHP.Location = new System.Drawing.Point(780, 212);
            this.browseInstallPHP.Name = "browseInstallPHP";
            this.browseInstallPHP.Size = new System.Drawing.Size(75, 23);
            this.browseInstallPHP.TabIndex = 13;
            this.browseInstallPHP.Text = "Browse";
            this.browseInstallPHP.UseVisualStyleBackColor = true;
            this.browseInstallPHP.Click += new System.EventHandler(this.browseInstallPHP_Click);
            // 
            // installationInstructionsLabel
            // 
            this.installationInstructionsLabel.AutoSize = true;
            this.installationInstructionsLabel.Location = new System.Drawing.Point(23, 175);
            this.installationInstructionsLabel.Name = "installationInstructionsLabel";
            this.installationInstructionsLabel.Size = new System.Drawing.Size(116, 26);
            this.installationInstructionsLabel.TabIndex = 12;
            this.installationInstructionsLabel.Text = "Installation instructions:\r\n(e.g. install.xml)";
            // 
            // installXmlPath
            // 
            this.installXmlPath.Location = new System.Drawing.Point(173, 172);
            this.installXmlPath.Name = "installXmlPath";
            this.installXmlPath.ReadOnly = true;
            this.installXmlPath.Size = new System.Drawing.Size(568, 20);
            this.installXmlPath.TabIndex = 11;
            // 
            // browseInstallXML
            // 
            this.browseInstallXML.Location = new System.Drawing.Point(780, 170);
            this.browseInstallXML.Name = "browseInstallXML";
            this.browseInstallXML.Size = new System.Drawing.Size(75, 23);
            this.browseInstallXML.TabIndex = 10;
            this.browseInstallXML.Text = "Browse";
            this.browseInstallXML.UseVisualStyleBackColor = true;
            this.browseInstallXML.Click += new System.EventHandler(this.browseInstallXML_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "package-info.xml:";
            // 
            // packageInfoXMLPath
            // 
            this.packageInfoXMLPath.Location = new System.Drawing.Point(173, 92);
            this.packageInfoXMLPath.Name = "packageInfoXMLPath";
            this.packageInfoXMLPath.ReadOnly = true;
            this.packageInfoXMLPath.Size = new System.Drawing.Size(601, 20);
            this.packageInfoXMLPath.TabIndex = 8;
            // 
            // browsePackageInfoXML
            // 
            this.browsePackageInfoXML.Location = new System.Drawing.Point(780, 90);
            this.browsePackageInfoXML.Name = "browsePackageInfoXML";
            this.browsePackageInfoXML.Size = new System.Drawing.Size(75, 23);
            this.browsePackageInfoXML.TabIndex = 7;
            this.browsePackageInfoXML.Text = "Browse";
            this.browsePackageInfoXML.UseVisualStyleBackColor = true;
            this.browsePackageInfoXML.Click += new System.EventHandler(this.browsePackageInfoXML_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(683, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mod Manager will try to autodetect the package files when you select a directory." +
    " In case it fails to do so correctly, select the correct files below.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Package directory:";
            // 
            // packageInputPath
            // 
            this.packageInputPath.Location = new System.Drawing.Point(173, 20);
            this.packageInputPath.Name = "packageInputPath";
            this.packageInputPath.ReadOnly = true;
            this.packageInputPath.Size = new System.Drawing.Size(601, 20);
            this.packageInputPath.TabIndex = 4;
            // 
            // browseInputPackageDirectory
            // 
            this.browseInputPackageDirectory.Location = new System.Drawing.Point(780, 18);
            this.browseInputPackageDirectory.Name = "browseInputPackageDirectory";
            this.browseInputPackageDirectory.Size = new System.Drawing.Size(75, 23);
            this.browseInputPackageDirectory.TabIndex = 0;
            this.browseInputPackageDirectory.Text = "Browse";
            this.browseInputPackageDirectory.UseVisualStyleBackColor = true;
            this.browseInputPackageDirectory.Click += new System.EventHandler(this.browseInputPackageDirectory_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(801, 6);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(720, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // cvWorking
            // 
            this.cvWorking.AutoSize = true;
            this.cvWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvWorking.Location = new System.Drawing.Point(12, 11);
            this.cvWorking.Name = "cvWorking";
            this.cvWorking.Size = new System.Drawing.Size(332, 13);
            this.cvWorking.TabIndex = 7;
            this.cvWorking.Text = "Converting your project, hold on... This may take a while.";
            this.cvWorking.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.cvWorking);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 32);
            this.panel1.TabIndex = 8;
            // 
            // convertProject
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(884, 544);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "convertProject";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Convert a Package";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseOutputDirectory;
        private System.Windows.Forms.TextBox packageInputPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseInputPackageDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox packageInfoXMLPath;
        private System.Windows.Forms.Button browsePackageInfoXML;
        private System.Windows.Forms.Label installDatabasePHPLabel;
        private System.Windows.Forms.TextBox installDatabasePHPPath;
        private System.Windows.Forms.Button browseInstallDatabasePHP;
        private System.Windows.Forms.Label uninstallPHPLabel;
        private System.Windows.Forms.TextBox uninstallPHPPath;
        private System.Windows.Forms.Button browseUninstallPHP;
        private System.Windows.Forms.Label installPHPLabel;
        private System.Windows.Forms.TextBox installPHPPath;
        private System.Windows.Forms.Button browseInstallPHP;
        private System.Windows.Forms.Label installationInstructionsLabel;
        private System.Windows.Forms.TextBox installXmlPath;
        private System.Windows.Forms.Button browseInstallXML;
        private System.Windows.Forms.Label uninstallDatabaseLabel;
        private System.Windows.Forms.TextBox uninstallDatabasePHPPath;
        private System.Windows.Forms.Button browseUninstallDatabasePHP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox readmeTXTPath;
        private System.Windows.Forms.Button browseReadmeTXT;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button cleanReadme;
        private System.Windows.Forms.Button cleanInstall;
        private System.Windows.Forms.Button cleanInstallCode;
        private System.Windows.Forms.Button cleanDeinstallCode;
        private System.Windows.Forms.Button cleanDBInstall;
        private System.Windows.Forms.Button cleanDBDeinstall;
        private System.Windows.Forms.Label cvWorking;
        private System.Windows.Forms.Panel panel1;
    }
}