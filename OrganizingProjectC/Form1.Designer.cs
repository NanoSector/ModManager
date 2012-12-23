namespace OrganizingProjectC
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
            this.label1 = new System.Windows.Forms.Label();
            this.compileProjectButton = new System.Windows.Forms.Button();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.editProjectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
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
            // compileProjectButton
            // 
            this.compileProjectButton.Location = new System.Drawing.Point(15, 25);
            this.compileProjectButton.Name = "compileProjectButton";
            this.compileProjectButton.Size = new System.Drawing.Size(243, 23);
            this.compileProjectButton.TabIndex = 1;
            this.compileProjectButton.Text = "Compile a project";
            this.compileProjectButton.UseVisualStyleBackColor = true;
            this.compileProjectButton.Click += new System.EventHandler(this.compileProjectButton_Click);
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(15, 54);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(243, 23);
            this.createProjectButton.TabIndex = 2;
            this.createProjectButton.Text = "Create a new project";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // editProjectButton
            // 
            this.editProjectButton.Location = new System.Drawing.Point(15, 83);
            this.editProjectButton.Name = "editProjectButton";
            this.editProjectButton.Size = new System.Drawing.Size(243, 23);
            this.editProjectButton.TabIndex = 3;
            this.editProjectButton.Text = "Edit a project";
            this.editProjectButton.UseVisualStyleBackColor = true;
            this.editProjectButton.Click += new System.EventHandler(this.editProjectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "(c) 2012 - Rick \"Yoshi2889\" Kerkhof";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editProjectButton);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.compileProjectButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mod Manager Agent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button compileProjectButton;
        private System.Windows.Forms.Button createProjectButton;
        private System.Windows.Forms.Button editProjectButton;
        private System.Windows.Forms.Label label2;
    }
}

