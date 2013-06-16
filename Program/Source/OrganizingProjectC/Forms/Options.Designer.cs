namespace ModBuilder.Forms
{
    partial class Options
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.testSmOrgDetails = new System.Windows.Forms.Button();
            this.smOrgPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.smOrgUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.idUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dsmfver = new System.Windows.Forms.Label();
            this.dsmfverp = new System.Windows.Forms.Label();
            this.onever = new System.Windows.Forms.Label();
            this.twover = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dl11 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dl20 = new System.Windows.Forms.Button();
            this.browseSmfPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.smfPath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bypassArchiveError = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupInstr = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.autoCheckUpdates = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 246);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.idUsername);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.testSmOrgDetails);
            this.groupBox3.Controls.Add(this.smOrgPassword);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.smOrgUsername);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(8, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 113);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simple Machines integration";
            this.groupBox3.Visible = false;
            // 
            // testSmOrgDetails
            // 
            this.testSmOrgDetails.Location = new System.Drawing.Point(213, 84);
            this.testSmOrgDetails.Name = "testSmOrgDetails";
            this.testSmOrgDetails.Size = new System.Drawing.Size(126, 23);
            this.testSmOrgDetails.TabIndex = 5;
            this.testSmOrgDetails.Text = "Test your login details";
            this.testSmOrgDetails.UseVisualStyleBackColor = true;
            this.testSmOrgDetails.Click += new System.EventHandler(this.testSmOrgDetails_Click);
            // 
            // smOrgPassword
            // 
            this.smOrgPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModBuilder.Properties.Settings.Default, "smOrgPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smOrgPassword.Location = new System.Drawing.Point(98, 58);
            this.smOrgPassword.Name = "smOrgPassword";
            this.smOrgPassword.Size = new System.Drawing.Size(241, 20);
            this.smOrgPassword.TabIndex = 4;
            this.smOrgPassword.Text = global::ModBuilder.Properties.Settings.Default.smOrgPassword;
            this.smOrgPassword.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Username:";
            // 
            // smOrgUsername
            // 
            this.smOrgUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModBuilder.Properties.Settings.Default, "smOrgUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smOrgUsername.Location = new System.Drawing.Point(98, 32);
            this.smOrgUsername.Name = "smOrgUsername";
            this.smOrgUsername.Size = new System.Drawing.Size(241, 20);
            this.smOrgUsername.TabIndex = 1;
            this.smOrgUsername.Text = global::ModBuilder.Properties.Settings.Default.smOrgUsername;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(333, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "This will integrate your SimpleMachines.org account into Mod Builder.";
            // 
            // idUsername
            // 
            this.idUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModBuilder.Properties.Settings.Default, "idUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.idUsername.Location = new System.Drawing.Point(106, 12);
            this.idUsername.Name = "idUsername";
            this.idUsername.Size = new System.Drawing.Size(241, 20);
            this.idUsername.TabIndex = 2;
            this.idUsername.Text = global::ModBuilder.Properties.Settings.Default.idUsername;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(328, 26);
            this.label8.TabIndex = 1;
            this.label8.Text = "This will be used to generate a unique mod ID for your modifications.\r\nIt does no" +
    "t need to be a username for a specific site.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Your username:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dsmfver);
            this.tabPage2.Controls.Add(this.dsmfverp);
            this.tabPage2.Controls.Add(this.onever);
            this.tabPage2.Controls.Add(this.twover);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dl11);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.dl20);
            this.tabPage2.Controls.Add(this.browseSmfPath);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.smfPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debugging";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dsmfver
            // 
            this.dsmfver.AutoSize = true;
            this.dsmfver.Location = new System.Drawing.Point(278, 86);
            this.dsmfver.Name = "dsmfver";
            this.dsmfver.Size = new System.Drawing.Size(57, 13);
            this.dsmfver.TabIndex = 12;
            this.dsmfver.Text = "(unknown)";
            // 
            // dsmfverp
            // 
            this.dsmfverp.AutoSize = true;
            this.dsmfverp.Location = new System.Drawing.Point(21, 86);
            this.dsmfverp.Name = "dsmfverp";
            this.dsmfverp.Size = new System.Drawing.Size(255, 13);
            this.dsmfverp.TabIndex = 11;
            this.dsmfverp.Text = "Mod Builder has detected the following SMF version:\r\n";
            // 
            // onever
            // 
            this.onever.AutoSize = true;
            this.onever.Location = new System.Drawing.Point(103, 196);
            this.onever.Name = "onever";
            this.onever.Size = new System.Drawing.Size(57, 13);
            this.onever.TabIndex = 10;
            this.onever.Text = "(unknown)";
            // 
            // twover
            // 
            this.twover.AutoSize = true;
            this.twover.Location = new System.Drawing.Point(103, 167);
            this.twover.Name = "twover";
            this.twover.Size = new System.Drawing.Size(57, 13);
            this.twover.TabIndex = 9;
            this.twover.Text = "(unknown)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Latest in 1.1.x:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Latest in 2.0.x:";
            // 
            // dl11
            // 
            this.dl11.Enabled = false;
            this.dl11.Location = new System.Drawing.Point(206, 191);
            this.dl11.Name = "dl11";
            this.dl11.Size = new System.Drawing.Size(150, 23);
            this.dl11.TabIndex = 6;
            this.dl11.Text = "Download this version";
            this.dl11.UseVisualStyleBackColor = true;
            this.dl11.Click += new System.EventHandler(this.dl11_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 130);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Check SMF versions";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dl20
            // 
            this.dl20.Enabled = false;
            this.dl20.Location = new System.Drawing.Point(206, 162);
            this.dl20.Name = "dl20";
            this.dl20.Size = new System.Drawing.Size(150, 23);
            this.dl20.TabIndex = 4;
            this.dl20.Text = "Download this version";
            this.dl20.UseVisualStyleBackColor = true;
            this.dl20.Click += new System.EventHandler(this.dl20_Click);
            // 
            // browseSmfPath
            // 
            this.browseSmfPath.Location = new System.Drawing.Point(281, 15);
            this.browseSmfPath.Name = "browseSmfPath";
            this.browseSmfPath.Size = new System.Drawing.Size(75, 23);
            this.browseSmfPath.TabIndex = 3;
            this.browseSmfPath.Text = "Browse";
            this.browseSmfPath.UseVisualStyleBackColor = true;
            this.browseSmfPath.Click += new System.EventHandler(this.browseSmfPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Note: This does not need to be a live installation.\r\nMod Builder only needs the f" +
    "iles in order to test any instructions.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to SMF files...";
            // 
            // smfPath
            // 
            this.smfPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModBuilder.Properties.Settings.Default, "smfPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smfPath.Location = new System.Drawing.Point(123, 17);
            this.smfPath.Name = "smfPath";
            this.smfPath.Size = new System.Drawing.Size(152, 20);
            this.smfPath.TabIndex = 2;
            this.smfPath.Text = global::ModBuilder.Properties.Settings.Default.smfPath;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(370, 220);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Building";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.bypassArchiveError);
            this.groupBox2.Location = new System.Drawing.Point(8, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 89);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compiling";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "WARNING!!! This feature can have undesired side effects!\r\nYou should also disable" +
    " this when writing mods for SMF 2.1!";
            // 
            // bypassArchiveError
            // 
            this.bypassArchiveError.AutoSize = true;
            this.bypassArchiveError.Checked = global::ModBuilder.Properties.Settings.Default.bypassArchiveError;
            this.bypassArchiveError.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ModBuilder.Properties.Settings.Default, "bypassArchiveError", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bypassArchiveError.Location = new System.Drawing.Point(6, 19);
            this.bypassArchiveError.Name = "bypassArchiveError";
            this.bypassArchiveError.Size = new System.Drawing.Size(245, 17);
            this.bypassArchiveError.TabIndex = 0;
            this.bypassArchiveError.Text = "Attempt to bypass \"The archive is empty\" error";
            this.bypassArchiveError.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupInstr);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Smart Building features";
            // 
            // groupInstr
            // 
            this.groupInstr.AutoSize = true;
            this.groupInstr.Checked = global::ModBuilder.Properties.Settings.Default.groupInstructions;
            this.groupInstr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.groupInstr.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ModBuilder.Properties.Settings.Default, "groupInstructions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.groupInstr.Location = new System.Drawing.Point(6, 19);
            this.groupInstr.Name = "groupInstr";
            this.groupInstr.Size = new System.Drawing.Size(300, 17);
            this.groupInstr.TabIndex = 0;
            this.groupInstr.Text = "Group instructions on the same file together in the XML file";
            this.groupInstr.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.autoCheckUpdates);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(370, 220);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Updates";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "This feature can cause Mod Builder to start up really slow,\r\nso please keep that " +
    "in mind when using this feature.";
            // 
            // autoCheckUpdates
            // 
            this.autoCheckUpdates.AutoSize = true;
            this.autoCheckUpdates.Checked = global::ModBuilder.Properties.Settings.Default.autoCheckUpdates;
            this.autoCheckUpdates.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ModBuilder.Properties.Settings.Default, "autoCheckUpdates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoCheckUpdates.Location = new System.Drawing.Point(8, 6);
            this.autoCheckUpdates.Name = "autoCheckUpdates";
            this.autoCheckUpdates.Size = new System.Drawing.Size(319, 17);
            this.autoCheckUpdates.TabIndex = 0;
            this.autoCheckUpdates.Text = "When Mod Builder launches, automatically check for updates.";
            this.autoCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 34);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(210, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Options
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(378, 280);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Options";
            this.Text = "Mod Builder Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox smfPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button browseSmfPath;
        private System.Windows.Forms.CheckBox autoCheckUpdates;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label onever;
        private System.Windows.Forms.Label twover;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button dl11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button dl20;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox bypassArchiveError;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox groupInstr;
        private System.Windows.Forms.Label dsmfver;
        private System.Windows.Forms.Label dsmfverp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox smOrgPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox smOrgUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox idUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button testSmOrgDetails;
    }
}