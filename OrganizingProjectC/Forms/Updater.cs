using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;


namespace ModBuilder.Forms
{
    public partial class Updater : Form
    {
        string mbver;
        string dlfilename;
        public Updater(string newmbver)
        {
            mbver = newmbver;
            InitializeComponent();
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            informationIcon.Image = SystemIcons.Information.ToBitmap();
            installedVer.Text = "Installed version: " + Properties.Settings.Default.mbVersion;
            availableVer.Text = "Available version: " + mbver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string clog = "https://raw.github.com/Yoshi2889/ModManager/master/Changelog.txt";
            string tclog = client.DownloadString(clog);
            changelog.Text = tclog;
            this.Height = 430;
            button1.Enabled = false;

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                updateButton.Enabled = false;
                remindButton.Enabled = false;
                progress.Visible = true;
                button1.Visible = false;

                WebClient client = new WebClient();
                // Start downloading! DLUpdateCompleted will take over once it's done.
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DLUpdateCompleted);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                dlfilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mod Builder\\Updates\\update_" + mbver.Replace(".", "-") + ".exe");
                client.DownloadFileAsync(new Uri("https://github.com/Yoshi2889/ModManager/blob/master/setup.exe?raw=true"), dlfilename);
            }
            catch
            {
                updateButton.Enabled = true;
                remindButton.Enabled = true;
                progress.Visible = false;
                button1.Visible = true;
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void DLUpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            System.Diagnostics.Process.Start(dlfilename);
            Application.Exit();
        }
    }
}
