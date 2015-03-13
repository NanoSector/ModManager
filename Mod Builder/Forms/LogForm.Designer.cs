namespace Mod_Builder.Forms
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.copyClipboardButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lastItemLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.runningTasksLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.runningTasks = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(819, 454);
            this.textBox1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.copyClipboardButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(819, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton1.Text = "Save to file";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // copyClipboardButton
            // 
            this.copyClipboardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyClipboardButton.Image = ((System.Drawing.Image)(resources.GetObject("copyClipboardButton.Image")));
            this.copyClipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyClipboardButton.Name = "copyClipboardButton";
            this.copyClipboardButton.Size = new System.Drawing.Size(106, 22);
            this.copyClipboardButton.Text = "Copy to clipboard";
            this.copyClipboardButton.Click += new System.EventHandler(this.copyClipboardButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastItemLabel,
            this.lastItem,
            this.runningTasksLabel,
            this.runningTasks});
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(819, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lastItemLabel
            // 
            this.lastItemLabel.Name = "lastItemLabel";
            this.lastItemLabel.Size = new System.Drawing.Size(58, 17);
            this.lastItemLabel.Text = "Last item:";
            // 
            // lastItem
            // 
            this.lastItem.Name = "lastItem";
            this.lastItem.Size = new System.Drawing.Size(605, 17);
            this.lastItem.Spring = true;
            this.lastItem.Text = "(no items available)";
            this.lastItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // runningTasksLabel
            // 
            this.runningTasksLabel.Name = "runningTasksLabel";
            this.runningTasksLabel.Size = new System.Drawing.Size(84, 17);
            this.runningTasksLabel.Text = "Running tasks:";
            // 
            // runningTasks
            // 
            this.runningTasks.Name = "runningTasks";
            this.runningTasks.Size = new System.Drawing.Size(26, 20);
            this.runningTasks.Text = "0";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 501);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton copyClipboardButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lastItemLabel;
        private System.Windows.Forms.ToolStripStatusLabel lastItem;
        private System.Windows.Forms.ToolStripStatusLabel runningTasksLabel;
        private System.Windows.Forms.ToolStripDropDownButton runningTasks;
    }
}