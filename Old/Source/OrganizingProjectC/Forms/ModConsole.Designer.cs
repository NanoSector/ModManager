namespace ModBuilder.Forms
{
    partial class modConsole
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
            this.modConsoleBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // modConsoleBox
            // 
            this.modConsoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modConsoleBox.FormattingEnabled = true;
            this.modConsoleBox.Items.AddRange(new object[] {
            "Mod Console started"});
            this.modConsoleBox.Location = new System.Drawing.Point(0, 0);
            this.modConsoleBox.Name = "modConsoleBox";
            this.modConsoleBox.Size = new System.Drawing.Size(591, 211);
            this.modConsoleBox.TabIndex = 0;
            // 
            // modConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 211);
            this.ControlBox = false;
            this.Controls.Add(this.modConsoleBox);
            this.Name = "modConsole";
            this.Text = "Mod Editor Console";
            this.Load += new System.EventHandler(this.ModConsole_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox modConsoleBox;
    }
}