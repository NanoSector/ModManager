﻿namespace OrganizingProjectC
{
    partial class modEditor
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("package-info.xml");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("readme.txt");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Files", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modEditor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.modDetails = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.modType = new System.Windows.Forms.ComboBox();
            this.genPkgID = new System.Windows.Forms.CheckBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.modName = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.modVersion = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modCompatibility = new System.Windows.Forms.TextBox();
            this.modID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.authorName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.refreshFileListButton = new System.Windows.Forms.Button();
            this.addFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.files = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.modReadme = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.instructionsRefresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regenerateSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.delInstruction = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.modDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.modDetails);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(591, 314);
            this.tabControl1.TabIndex = 0;
            // 
            // modDetails
            // 
            this.modDetails.Controls.Add(this.groupBox2);
            this.modDetails.Controls.Add(this.groupBox1);
            this.modDetails.Location = new System.Drawing.Point(4, 22);
            this.modDetails.Name = "modDetails";
            this.modDetails.Padding = new System.Windows.Forms.Padding(3);
            this.modDetails.Size = new System.Drawing.Size(583, 288);
            this.modDetails.TabIndex = 0;
            this.modDetails.Text = "Mod Details";
            this.modDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.modType);
            this.groupBox2.Controls.Add(this.genPkgID);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.modName);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.modVersion);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.versionLabel);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.modCompatibility);
            this.groupBox2.Controls.Add(this.modID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 203);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General information";
            // 
            // modType
            // 
            this.modType.FormattingEnabled = true;
            this.modType.Items.AddRange(new object[] {
            "Modification",
            "Avatar pack"});
            this.modType.Location = new System.Drawing.Point(223, 77);
            this.modType.Name = "modType";
            this.modType.Size = new System.Drawing.Size(334, 21);
            this.modType.TabIndex = 11;
            this.modType.SelectedIndexChanged += new System.EventHandler(this.modType_SelectedIndexChanged);
            // 
            // genPkgID
            // 
            this.genPkgID.AutoSize = true;
            this.genPkgID.Checked = true;
            this.genPkgID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genPkgID.Location = new System.Drawing.Point(31, 127);
            this.genPkgID.Name = "genPkgID";
            this.genPkgID.Size = new System.Drawing.Size(170, 17);
            this.genPkgID.TabIndex = 0;
            this.genPkgID.Text = "Automatically generate mod ID";
            this.genPkgID.UseVisualStyleBackColor = true;
            this.genPkgID.CheckedChanged += new System.EventHandler(this.genPkgID_CheckedChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox6.Image = global::OrganizingProjectC.Properties.Resources.question;
            this.pictureBox6.Location = new System.Drawing.Point(6, 55);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // modName
            // 
            this.modName.Location = new System.Drawing.Point(223, 25);
            this.modName.Name = "modName";
            this.modName.Size = new System.Drawing.Size(334, 20);
            this.modName.TabIndex = 4;
            this.modName.TextChanged += new System.EventHandler(this.modName_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox5.Image = global::OrganizingProjectC.Properties.Resources.question;
            this.pictureBox5.Location = new System.Drawing.Point(6, 82);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // modVersion
            // 
            this.modVersion.Location = new System.Drawing.Point(223, 51);
            this.modVersion.Name = "modVersion";
            this.modVersion.Size = new System.Drawing.Size(334, 20);
            this.modVersion.TabIndex = 3;
            this.modVersion.TextChanged += new System.EventHandler(this.modVersion_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox4.Image = global::OrganizingProjectC.Properties.Resources.question;
            this.pictureBox4.Location = new System.Drawing.Point(6, 108);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mod name";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox3.Image = global::OrganizingProjectC.Properties.Resources.question;
            this.pictureBox3.Location = new System.Drawing.Point(6, 153);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(28, 58);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(65, 13);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "Mod version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox1.Image = global::OrganizingProjectC.Properties.Resources.question;
            this.pictureBox1.Location = new System.Drawing.Point(6, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mod type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(529, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "(you can use a range, like 2.0 - 2.0.99, but just a single version will also work" +
    ". Separate versions with a comma)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mod ID";
            // 
            // modCompatibility
            // 
            this.modCompatibility.Location = new System.Drawing.Point(222, 149);
            this.modCompatibility.Name = "modCompatibility";
            this.modCompatibility.Size = new System.Drawing.Size(334, 20);
            this.modCompatibility.TabIndex = 16;
            this.modCompatibility.TextChanged += new System.EventHandler(this.modCompatibility_TextChanged);
            // 
            // modID
            // 
            this.modID.Enabled = false;
            this.modID.Location = new System.Drawing.Point(223, 104);
            this.modID.Name = "modID";
            this.modID.Size = new System.Drawing.Size(334, 20);
            this.modID.TabIndex = 10;
            this.modID.TextChanged += new System.EventHandler(this.modID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Compatibility";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.authorName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 64);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Author information";
            // 
            // authorName
            // 
            this.authorName.Location = new System.Drawing.Point(224, 27);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(334, 20);
            this.authorName.TabIndex = 14;
            this.authorName.TextChanged += new System.EventHandler(this.authorName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Username\r\n(please refrain from using spaces)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox2.Image = global::OrganizingProjectC.Properties.Resources.question;
            this.pictureBox2.Location = new System.Drawing.Point(7, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.refreshFileListButton);
            this.tabPage1.Controls.Add(this.addFileButton);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.files);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(583, 288);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // refreshFileListButton
            // 
            this.refreshFileListButton.Location = new System.Drawing.Point(255, 48);
            this.refreshFileListButton.Name = "refreshFileListButton";
            this.refreshFileListButton.Size = new System.Drawing.Size(100, 22);
            this.refreshFileListButton.TabIndex = 3;
            this.refreshFileListButton.Text = "Refresh";
            this.refreshFileListButton.UseVisualStyleBackColor = true;
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(255, 19);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(100, 23);
            this.addFileButton.TabIndex = 2;
            this.addFileButton.Text = "Add a new file";
            this.addFileButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(252, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "File Management";
            // 
            // files
            // 
            this.files.Dock = System.Windows.Forms.DockStyle.Left;
            this.files.Location = new System.Drawing.Point(3, 3);
            this.files.Name = "files";
            treeNode1.Name = "packageInfoXML";
            treeNode1.Text = "package-info.xml";
            treeNode2.Name = "readmeTXT";
            treeNode2.Text = "readme.txt";
            treeNode3.Name = "filesRoot";
            treeNode3.Text = "Files";
            this.files.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.files.Size = new System.Drawing.Size(243, 282);
            this.files.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.modReadme);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(583, 288);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Readme";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // modReadme
            // 
            this.modReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modReadme.Location = new System.Drawing.Point(3, 3);
            this.modReadme.Multiline = true;
            this.modReadme.Name = "modReadme";
            this.modReadme.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.modReadme.Size = new System.Drawing.Size(577, 244);
            this.modReadme.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 38);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(410, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "This is the readme your users will see when installing your mod. You can use BBCo" +
    "de.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.delInstruction);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.instructionsRefresh);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.instructions);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(583, 288);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Instructions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // instructionsRefresh
            // 
            this.instructionsRefresh.Location = new System.Drawing.Point(258, 88);
            this.instructionsRefresh.Name = "instructionsRefresh";
            this.instructionsRefresh.Size = new System.Drawing.Size(120, 23);
            this.instructionsRefresh.TabIndex = 4;
            this.instructionsRefresh.Text = "Refresh";
            this.instructionsRefresh.UseVisualStyleBackColor = true;
            this.instructionsRefresh.Click += new System.EventHandler(this.instructionsRefresh_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Add a new instruction";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(258, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Instruction Manager";
            // 
            // instructions
            // 
            this.instructions.Dock = System.Windows.Forms.DockStyle.Left;
            this.instructions.Location = new System.Drawing.Point(3, 37);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(249, 248);
            this.instructions.TabIndex = 1;
            this.instructions.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.instructions_NodeMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 34);
            this.panel2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(537, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "You can specify any custom instructions like replacing code that need to be perfo" +
    "rmed here. Double click to edit.";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(583, 288);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Hooks";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(659, 26);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mod Manager can generate and insert a hook installer for your mod. If you wish to" +
    " create your own installer, you can specify it\'s name here.\r\nMake sure you have " +
    "added it in the Files tab.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem});
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newProjectToolStripMenuItem.Text = "New project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "Open project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveProjectToolStripMenuItem.Text = "Save project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.regenerateSQLToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.compileToolStripMenuItem.Text = "Compile";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.buildToolStripMenuItem.Text = "Build";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // regenerateSQLToolStripMenuItem
            // 
            this.regenerateSQLToolStripMenuItem.Name = "regenerateSQLToolStripMenuItem";
            this.regenerateSQLToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.regenerateSQLToolStripMenuItem.Text = "Regenerate SQL";
            this.regenerateSQLToolStripMenuItem.Click += new System.EventHandler(this.regenerateSQLToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewDirectoryToolStripMenuItem,
            this.addAFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 48);
            // 
            // addNewDirectoryToolStripMenuItem
            // 
            this.addNewDirectoryToolStripMenuItem.Name = "addNewDirectoryToolStripMenuItem";
            this.addNewDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addNewDirectoryToolStripMenuItem.Text = "Add new directory";
            // 
            // addAFileToolStripMenuItem
            // 
            this.addAFileToolStripMenuItem.Name = "addAFileToolStripMenuItem";
            this.addAFileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addAFileToolStripMenuItem.Text = "Add a file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To delete an entry, select it on the left";
            // 
            // delInstruction
            // 
            this.delInstruction.Location = new System.Drawing.Point(258, 147);
            this.delInstruction.Name = "delInstruction";
            this.delInstruction.Size = new System.Drawing.Size(120, 25);
            this.delInstruction.TabIndex = 6;
            this.delInstruction.Text = "Delete instruction";
            this.delInstruction.UseVisualStyleBackColor = true;
            this.delInstruction.Click += new System.EventHandler(this.delInstruction_Click);
            // 
            // modEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 338);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "modEditor";
            this.Text = "Mod Editor";
            this.Load += new System.EventHandler(this.modEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.modDetails.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage modDetails;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox genPkgID;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView files;
        public System.Windows.Forms.ComboBox modType;
        public System.Windows.Forms.TextBox modID;
        public System.Windows.Forms.TextBox modVersion;
        public System.Windows.Forms.TextBox modName;
        public System.Windows.Forms.TextBox authorName;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAFileToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TreeView instructions;
        public System.Windows.Forms.TextBox modReadme;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem regenerateSQLToolStripMenuItem;
        public System.Windows.Forms.TextBox modCompatibility;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button refreshFileListButton;
        private System.Windows.Forms.Button instructionsRefresh;
        private System.Windows.Forms.Button delInstruction;
        private System.Windows.Forms.Label label2;
    }
}