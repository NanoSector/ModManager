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
            this.browseInputPackageDirectory = new System.Windows.Forms.Button();
            this.packageInputPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.packageInfoXMLPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.outputDirectory.Location = new System.Drawing.Point(138, 25);
            this.outputDirectory.Name = "outputDirectory";
            this.outputDirectory.ReadOnly = true;
            this.outputDirectory.Size = new System.Drawing.Size(488, 20);
            this.outputDirectory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 28);
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
            this.groupBox1.Size = new System.Drawing.Size(725, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project";
            // 
            // browseOutputDirectory
            // 
            this.browseOutputDirectory.Location = new System.Drawing.Point(632, 23);
            this.browseOutputDirectory.Name = "browseOutputDirectory";
            this.browseOutputDirectory.Size = new System.Drawing.Size(75, 23);
            this.browseOutputDirectory.TabIndex = 3;
            this.browseOutputDirectory.Text = "Browse";
            this.browseOutputDirectory.UseVisualStyleBackColor = true;
            this.browseOutputDirectory.Click += new System.EventHandler(this.browseOutputDirectory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.packageInfoXMLPath);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.packageInputPath);
            this.groupBox2.Controls.Add(this.browseInputPackageDirectory);
            this.groupBox2.Location = new System.Drawing.Point(15, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 282);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Package";
            // 
            // browseInputPackageDirectory
            // 
            this.browseInputPackageDirectory.Location = new System.Drawing.Point(632, 19);
            this.browseInputPackageDirectory.Name = "browseInputPackageDirectory";
            this.browseInputPackageDirectory.Size = new System.Drawing.Size(75, 23);
            this.browseInputPackageDirectory.TabIndex = 0;
            this.browseInputPackageDirectory.Text = "Browse";
            this.browseInputPackageDirectory.UseVisualStyleBackColor = true;
            // 
            // packageInputPath
            // 
            this.packageInputPath.Location = new System.Drawing.Point(138, 19);
            this.packageInputPath.Name = "packageInputPath";
            this.packageInputPath.ReadOnly = true;
            this.packageInputPath.Size = new System.Drawing.Size(488, 20);
            this.packageInputPath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Package directory:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(683, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mod Manager will try to autodetect the package files when you select a directory." +
    " In case it fails to do so correctly, select the correct files below.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "package-info.xml:";
            // 
            // packageInfoXMLPath
            // 
            this.packageInfoXMLPath.Location = new System.Drawing.Point(138, 91);
            this.packageInfoXMLPath.Name = "packageInfoXMLPath";
            this.packageInfoXMLPath.ReadOnly = true;
            this.packageInfoXMLPath.Size = new System.Drawing.Size(488, 20);
            this.packageInfoXMLPath.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // convertProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "convertProject";
            this.Text = "Convert a Package";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button button1;
    }
}