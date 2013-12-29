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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupInstr = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.autoCheckUpdates = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.phpver = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.phppath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 246);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
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
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(370, 220);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Building";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(370, 220);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Updates";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.autoCheckUpdates);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 84);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Updating";
            // 
            // autoCheckUpdates
            // 
            this.autoCheckUpdates.AutoSize = true;
            this.autoCheckUpdates.Checked = global::ModBuilder.Properties.Settings.Default.autoCheckUpdates;
            this.autoCheckUpdates.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ModBuilder.Properties.Settings.Default, "autoCheckUpdates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoCheckUpdates.Location = new System.Drawing.Point(6, 19);
            this.autoCheckUpdates.Name = "autoCheckUpdates";
            this.autoCheckUpdates.Size = new System.Drawing.Size(319, 17);
            this.autoCheckUpdates.TabIndex = 0;
            this.autoCheckUpdates.Text = "When Mod Builder launches, automatically check for updates.";
            this.autoCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "This feature can cause Mod Builder to start up really slow,\r\nso please keep that " +
    "in mind when using this feature.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(8, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 108);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recovery";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Delete all stored update executables";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Revert to version:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(303, 26);
            this.label12.TabIndex = 2;
            this.label12.Text = "Mod Manager stores all update executables. This allows you to\r\nrevert to an older" +
    " version, when features do not work correctly.";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.phpver);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.button6);
            this.tabPage5.Controls.Add(this.phppath);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(370, 220);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "PHP Code Checking";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // phpver
            // 
            this.phpver.AutoSize = true;
            this.phpver.Location = new System.Drawing.Point(216, 50);
            this.phpver.Name = "phpver";
            this.phpver.Size = new System.Drawing.Size(57, 13);
            this.phpver.TabIndex = 6;
            this.phpver.Text = "(unknown)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(202, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "The following PHP version was detected:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(287, 8);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Browse";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // phppath
            // 
            this.phppath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModBuilder.Properties.Settings.Default, "phppath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.phppath.Location = new System.Drawing.Point(99, 10);
            this.phppath.Name = "phppath";
            this.phppath.Size = new System.Drawing.Size(182, 20);
            this.phppath.TabIndex = 1;
            this.phppath.Text = global::ModBuilder.Properties.Settings.Default.phppath;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Path to php.exe:";
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Mod Builder Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox groupInstr;
        private System.Windows.Forms.Label dsmfver;
        private System.Windows.Forms.Label dsmfverp;
        private System.Windows.Forms.TextBox idUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label phpver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox phppath;
        private System.Windows.Forms.Label label9;
    }
}