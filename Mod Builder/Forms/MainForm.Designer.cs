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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.viewMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.projectMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.helpMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.logTest = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.mainStatusbar = new System.Windows.Forms.StatusStrip();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.projectMenu,
            this.toolsMenu,
            this.helpMenu,
            this.toolStripSeparator1,
            this.showLog,
            this.toolStripButton1,
            this.logTest,
            this.toolStripButton2});
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
            this.saveProjectToolStripMenuItem});
            this.fileMenu.Image = ((System.Drawing.Image)(resources.GetObject("fileMenu.Image")));
            this.fileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(38, 22);
            this.fileMenu.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newProjectToolStripMenuItem.Text = "New project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openProjectToolStripMenuItem.Text = "Open project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveProjectToolStripMenuItem.Text = "Save project";
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
            this.projectMenu.Image = ((System.Drawing.Image)(resources.GetObject("projectMenu.Image")));
            this.projectMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.projectMenu.Name = "projectMenu";
            this.projectMenu.Size = new System.Drawing.Size(57, 22);
            this.projectMenu.Text = "Project";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolsMenu.Image")));
            this.toolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(49, 22);
            this.toolsMenu.Text = "Tools";
            // 
            // helpMenu
            // 
            this.helpMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpMenu.Image = ((System.Drawing.Image)(resources.GetObject("helpMenu.Image")));
            this.helpMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(45, 22);
            this.helpMenu.Text = "Help";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // showLog
            // 
            this.showLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showLog.Image = ((System.Drawing.Image)(resources.GetObject("showLog.Image")));
            this.showLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showLog.Name = "showLog";
            this.showLog.Size = new System.Drawing.Size(80, 22);
            this.showLog.Text = "Show the log";
            this.showLog.Click += new System.EventHandler(this.showLog_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // logTest
            // 
            this.logTest.Name = "logTest";
            this.logTest.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "Log it!";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // mainStatusbar
            // 
            this.mainStatusbar.Location = new System.Drawing.Point(0, 522);
            this.mainStatusbar.Name = "mainStatusbar";
            this.mainStatusbar.Size = new System.Drawing.Size(883, 22);
            this.mainStatusbar.TabIndex = 1;
            this.mainStatusbar.Text = "statusStrip1";
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.DefaultExt = "mbproj";
            this.openProjectDialog.Filter = "Mod Builder Projects (*.mbproj)|*.mbproj";
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "mbproj";
            this.saveProjectDialog.Filter = "Mod Builder Projects (*.mbproj)|*.mbproj";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 544);
            this.Controls.Add(this.mainStatusbar);
            this.Controls.Add(this.mainToolbar);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.ToolStripButton showLog;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox logTest;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip mainStatusbar;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
    }
}

