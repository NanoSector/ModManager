namespace Mod_Builder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Instructions");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Project", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.instructionContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createInstructionButton = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.viewMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.projectMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.openProjectDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installToInstallationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromInstallationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.projectSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.showLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.forumTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusbar = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.projectOverview = new System.Windows.Forms.TreeView();
            this.treeImages = new System.Windows.Forms.ImageList(this.components);
            this.projectDetailsTabs = new System.Windows.Forms.TabControl();
            this.detailsPane = new System.Windows.Forms.TabPage();
            this.genModID = new System.Windows.Forms.CheckBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modID = new System.Windows.Forms.TextBox();
            this.compatibleCustom = new System.Windows.Forms.TextBox();
            this.compatibilityCustomEnabler = new System.Windows.Forms.CheckBox();
            this.compatible21 = new System.Windows.Forms.CheckBox();
            this.compatible20 = new System.Windows.Forms.CheckBox();
            this.projectVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.compatible11 = new System.Windows.Forms.CheckBox();
            this.projectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.globalErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fsWatcher = new System.IO.FileSystemWatcher();
            this.instructionContext.SuspendLayout();
            this.mainToolbar.SuspendLayout();
            this.mainStatusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.projectDetailsTabs.SuspendLayout();
            this.detailsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // instructionContext
            // 
            this.instructionContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createInstructionButton});
            this.instructionContext.Name = "instructionContext";
            this.instructionContext.Size = new System.Drawing.Size(212, 26);
            // 
            // createInstructionButton
            // 
            this.createInstructionButton.Name = "createInstructionButton";
            this.createInstructionButton.Size = new System.Drawing.Size(211, 22);
            this.createInstructionButton.Text = "Create a new instruction...";
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.projectMenu,
            this.toolsMenu,
            this.helpMenu});
            this.mainToolbar.Location = new System.Drawing.Point(0, 0);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(883, 25);
            this.mainToolbar.TabIndex = 0;
            this.mainToolbar.Text = "toolStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveProjectToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3});
            this.fileMenu.Image = ((System.Drawing.Image)(resources.GetObject("fileMenu.Image")));
            this.fileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(38, 22);
            this.fileMenu.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.instructionToolStripMenuItem});
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.newProjectToolStripMenuItem.Text = "New...";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openProjectToolStripMenuItem.Text = "Open...";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveProjectToolStripMenuItem.Text = "Save...";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editMenu.Image = ((System.Drawing.Image)(resources.GetObject("editMenu.Image")));
            this.editMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(40, 22);
            this.editMenu.Text = "Edit";
            // 
            // viewMenu
            // 
            this.viewMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewMenu.Image = ((System.Drawing.Image)(resources.GetObject("viewMenu.Image")));
            this.viewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(45, 22);
            this.viewMenu.Text = "View";
            // 
            // projectMenu
            // 
            this.projectMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.projectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectDirectoryToolStripMenuItem,
            this.applyToolStripMenuItem,
            this.toolStripSeparator4,
            this.projectSettingsToolStripMenuItem});
            this.projectMenu.Image = ((System.Drawing.Image)(resources.GetObject("projectMenu.Image")));
            this.projectMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.projectMenu.Name = "projectMenu";
            this.projectMenu.Size = new System.Drawing.Size(57, 22);
            this.projectMenu.Text = "Project";
            // 
            // openProjectDirectoryToolStripMenuItem
            // 
            this.openProjectDirectoryToolStripMenuItem.Name = "openProjectDirectoryToolStripMenuItem";
            this.openProjectDirectoryToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openProjectDirectoryToolStripMenuItem.Text = "Open project directory";
            this.openProjectDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openProjectDirectoryToolStripMenuItem_Click);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToInstallationToolStripMenuItem,
            this.removeFromInstallationToolStripMenuItem});
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.applyToolStripMenuItem.Text = "Apply...";
            // 
            // installToInstallationToolStripMenuItem
            // 
            this.installToInstallationToolStripMenuItem.Name = "installToInstallationToolStripMenuItem";
            this.installToInstallationToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.installToInstallationToolStripMenuItem.Text = "Install to installation";
            // 
            // removeFromInstallationToolStripMenuItem
            // 
            this.removeFromInstallationToolStripMenuItem.Name = "removeFromInstallationToolStripMenuItem";
            this.removeFromInstallationToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.removeFromInstallationToolStripMenuItem.Text = "Remove from installation";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // projectSettingsToolStripMenuItem
            // 
            this.projectSettingsToolStripMenuItem.Name = "projectSettingsToolStripMenuItem";
            this.projectSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.projectSettingsToolStripMenuItem.Text = "Project settings...";
            this.projectSettingsToolStripMenuItem.Click += new System.EventHandler(this.projectSettingsToolStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolsMenu.Image")));
            this.toolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(49, 22);
            this.toolsMenu.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLog,
            this.toolStripSeparator1,
            this.forumTopicToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpMenu.Image = ((System.Drawing.Image)(resources.GetObject("helpMenu.Image")));
            this.helpMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(45, 22);
            this.helpMenu.Text = "Help";
            // 
            // showLog
            // 
            this.showLog.Name = "showLog";
            this.showLog.Size = new System.Drawing.Size(143, 22);
            this.showLog.Text = "Show the log";
            this.showLog.Click += new System.EventHandler(this.showLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // forumTopicToolStripMenuItem
            // 
            this.forumTopicToolStripMenuItem.Name = "forumTopicToolStripMenuItem";
            this.forumTopicToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.forumTopicToolStripMenuItem.Text = "Forum topic";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainStatusbar
            // 
            this.mainStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.mainStatusbar.Location = new System.Drawing.Point(0, 522);
            this.mainStatusbar.Name = "mainStatusbar";
            this.mainStatusbar.Size = new System.Drawing.Size(883, 22);
            this.mainStatusbar.TabIndex = 1;
            this.mainStatusbar.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.projectOverview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.projectDetailsTabs);
            this.splitContainer1.Size = new System.Drawing.Size(883, 497);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 2;
            // 
            // projectOverview
            // 
            this.projectOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectOverview.ImageIndex = 0;
            this.projectOverview.ImageList = this.treeImages;
            this.projectOverview.Location = new System.Drawing.Point(0, 0);
            this.projectOverview.Name = "projectOverview";
            treeNode3.ContextMenuStrip = this.instructionContext;
            treeNode3.ImageKey = "instructions";
            treeNode3.Name = "instructionsNode";
            treeNode3.SelectedImageKey = "instructions";
            treeNode3.Text = "Instructions";
            treeNode4.ImageKey = "project";
            treeNode4.Name = "projectNode";
            treeNode4.SelectedImageKey = "project";
            treeNode4.Text = "Project";
            this.projectOverview.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.projectOverview.SelectedImageIndex = 0;
            this.projectOverview.ShowRootLines = false;
            this.projectOverview.Size = new System.Drawing.Size(294, 497);
            this.projectOverview.TabIndex = 0;
            // 
            // treeImages
            // 
            this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
            this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImages.Images.SetKeyName(0, "project");
            this.treeImages.Images.SetKeyName(1, "instructions");
            // 
            // projectDetailsTabs
            // 
            this.projectDetailsTabs.Controls.Add(this.detailsPane);
            this.projectDetailsTabs.Controls.Add(this.tabPage2);
            this.projectDetailsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectDetailsTabs.Location = new System.Drawing.Point(0, 0);
            this.projectDetailsTabs.Name = "projectDetailsTabs";
            this.projectDetailsTabs.SelectedIndex = 0;
            this.projectDetailsTabs.Size = new System.Drawing.Size(585, 497);
            this.projectDetailsTabs.TabIndex = 0;
            // 
            // detailsPane
            // 
            this.detailsPane.Controls.Add(this.genModID);
            this.detailsPane.Controls.Add(this.userName);
            this.detailsPane.Controls.Add(this.label5);
            this.detailsPane.Controls.Add(this.label4);
            this.detailsPane.Controls.Add(this.modID);
            this.detailsPane.Controls.Add(this.compatibleCustom);
            this.detailsPane.Controls.Add(this.compatibilityCustomEnabler);
            this.detailsPane.Controls.Add(this.compatible21);
            this.detailsPane.Controls.Add(this.compatible20);
            this.detailsPane.Controls.Add(this.projectVersion);
            this.detailsPane.Controls.Add(this.label3);
            this.detailsPane.Controls.Add(this.label2);
            this.detailsPane.Controls.Add(this.compatible11);
            this.detailsPane.Controls.Add(this.projectName);
            this.detailsPane.Controls.Add(this.label1);
            this.detailsPane.Location = new System.Drawing.Point(4, 22);
            this.detailsPane.Name = "detailsPane";
            this.detailsPane.Padding = new System.Windows.Forms.Padding(3);
            this.detailsPane.Size = new System.Drawing.Size(577, 471);
            this.detailsPane.TabIndex = 0;
            this.detailsPane.Text = "Details";
            this.detailsPane.UseVisualStyleBackColor = true;
            // 
            // genModID
            // 
            this.genModID.AutoSize = true;
            this.genModID.Checked = true;
            this.genModID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genModID.Location = new System.Drawing.Point(9, 142);
            this.genModID.Name = "genModID";
            this.genModID.Size = new System.Drawing.Size(133, 17);
            this.genModID.TabIndex = 14;
            this.genModID.Text = "Automatically generate";
            this.genModID.UseVisualStyleBackColor = true;
            this.genModID.CheckedChanged += new System.EventHandler(this.genModID_CheckedChanged);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(281, 116);
            this.userName.MaxLength = 30;
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(233, 20);
            this.userName.TabIndex = 13;
            this.userName.Validating += new System.ComponentModel.CancelEventHandler(this.userName_Validating);
            this.userName.Validated += new System.EventHandler(this.userName_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Your username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mod ID:";
            // 
            // modID
            // 
            this.modID.Location = new System.Drawing.Point(9, 116);
            this.modID.MaxLength = 32;
            this.modID.Name = "modID";
            this.modID.ReadOnly = true;
            this.modID.Size = new System.Drawing.Size(233, 20);
            this.modID.TabIndex = 10;
            // 
            // compatibleCustom
            // 
            this.compatibleCustom.Location = new System.Drawing.Point(218, 56);
            this.compatibleCustom.Name = "compatibleCustom";
            this.compatibleCustom.Size = new System.Drawing.Size(183, 20);
            this.compatibleCustom.TabIndex = 9;
            this.compatibleCustom.Visible = false;
            this.compatibleCustom.Validating += new System.ComponentModel.CancelEventHandler(this.genericTextBox_Validating);
            // 
            // compatibilityCustomEnabler
            // 
            this.compatibilityCustomEnabler.AutoSize = true;
            this.compatibilityCustomEnabler.Location = new System.Drawing.Point(151, 59);
            this.compatibilityCustomEnabler.Name = "compatibilityCustomEnabler";
            this.compatibilityCustomEnabler.Size = new System.Drawing.Size(61, 17);
            this.compatibilityCustomEnabler.TabIndex = 8;
            this.compatibilityCustomEnabler.Text = "Other...";
            this.compatibilityCustomEnabler.UseVisualStyleBackColor = true;
            this.compatibilityCustomEnabler.CheckedChanged += new System.EventHandler(this.compatibilityCustomEnabler_CheckedChanged);
            // 
            // compatible21
            // 
            this.compatible21.AutoSize = true;
            this.compatible21.Location = new System.Drawing.Point(104, 59);
            this.compatible21.Name = "compatible21";
            this.compatible21.Size = new System.Drawing.Size(41, 17);
            this.compatible21.TabIndex = 7;
            this.compatible21.Text = "2.1";
            this.compatible21.UseVisualStyleBackColor = true;
            // 
            // compatible20
            // 
            this.compatible20.AutoSize = true;
            this.compatible20.Location = new System.Drawing.Point(57, 59);
            this.compatible20.Name = "compatible20";
            this.compatible20.Size = new System.Drawing.Size(41, 17);
            this.compatible20.TabIndex = 6;
            this.compatible20.Text = "2.0";
            this.compatible20.UseVisualStyleBackColor = true;
            // 
            // projectVersion
            // 
            this.projectVersion.Location = new System.Drawing.Point(281, 20);
            this.projectVersion.Name = "projectVersion";
            this.projectVersion.Size = new System.Drawing.Size(233, 20);
            this.projectVersion.TabIndex = 5;
            this.projectVersion.Validating += new System.ComponentModel.CancelEventHandler(this.genericTextBox_Validating);
            this.projectVersion.Validated += new System.EventHandler(this.projectVersion_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mod version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Designed for SMF version:";
            // 
            // compatible11
            // 
            this.compatible11.AutoSize = true;
            this.compatible11.Location = new System.Drawing.Point(9, 59);
            this.compatible11.Name = "compatible11";
            this.compatible11.Size = new System.Drawing.Size(41, 17);
            this.compatible11.TabIndex = 2;
            this.compatible11.Text = "1.1";
            this.compatible11.UseVisualStyleBackColor = true;
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(9, 20);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(233, 20);
            this.projectName.TabIndex = 1;
            this.projectName.Validating += new System.ComponentModel.CancelEventHandler(this.genericTextBox_Validating);
            this.projectName.Validated += new System.EventHandler(this.projectName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // globalErrorProvider
            // 
            this.globalErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.globalErrorProvider.ContainerControl = this;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.projectToolStripMenuItem.Text = "Project";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // instructionToolStripMenuItem
            // 
            this.instructionToolStripMenuItem.Name = "instructionToolStripMenuItem";
            this.instructionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.instructionToolStripMenuItem.Text = "Instruction";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(177, 17);
            this.statusLabel.Text = "New project created in memory.";
            // 
            // fsWatcher
            // 
            this.fsWatcher.SynchronizingObject = this;
            this.fsWatcher.Changed += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
            this.fsWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fsWatcher_Deleted);
            this.fsWatcher.Renamed += new System.IO.RenamedEventHandler(this.fsWatcher_Renamed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(883, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainStatusbar);
            this.Controls.Add(this.mainToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "New Project - Mod Builder";
            this.instructionContext.ResumeLayout(false);
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.mainStatusbar.ResumeLayout(false);
            this.mainStatusbar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.projectDetailsTabs.ResumeLayout(false);
            this.detailsPane.ResumeLayout(false);
            this.detailsPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.ToolStripDropDownButton fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton editMenu;
        private System.Windows.Forms.ToolStripDropDownButton viewMenu;
        private System.Windows.Forms.ToolStripDropDownButton projectMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolsMenu;
        private System.Windows.Forms.ToolStripDropDownButton helpMenu;
        private System.Windows.Forms.StatusStrip mainStatusbar;
        private System.Windows.Forms.ToolStripMenuItem showLog;
        private System.Windows.Forms.ToolStripMenuItem openProjectDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem forumTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem projectSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installToInstallationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromInstallationToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView projectOverview;
        private System.Windows.Forms.ImageList treeImages;
        private System.Windows.Forms.TabControl projectDetailsTabs;
        private System.Windows.Forms.TabPage detailsPane;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.TextBox compatibleCustom;
        private System.Windows.Forms.CheckBox compatibilityCustomEnabler;
        private System.Windows.Forms.TextBox projectVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox compatible21;
        private System.Windows.Forms.CheckBox compatible20;
        private System.Windows.Forms.CheckBox compatible11;
        private System.Windows.Forms.ErrorProvider globalErrorProvider;
        private System.Windows.Forms.ContextMenuStrip instructionContext;
        private System.Windows.Forms.ToolStripMenuItem createInstructionButton;
        private System.Windows.Forms.CheckBox genModID;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox modID;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.IO.FileSystemWatcher fsWatcher;
    }
}

