using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ModBuilder.APIs;
using System.Net;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Security.Cryptography;

namespace ModBuilder.Forms
{
    public partial class Options : Form
    {
        Notify message = new Notify();
        string dl11f;
        string dl20f;
        public Options()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(smfPath.Text) && !Directory.Exists(smfPath.Text))
            {
                message.warning("The path to the SMF files you entered is invalid. Please check that it exists and try again.");
                tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void browseSmfPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = false;
            fb.Description = "Select the directory where the environment exists...";
            fb.ShowDialog();

            string s = fb.SelectedPath;
            if (Directory.Exists(s))
            {
                smfPath.Text = s;

                if (File.Exists(s + "/index.php"))
                {
                    string contents = File.ReadAllText(s + "/index.php");

                    Match match = Regex.Match(contents, @"'SMF ([^']*)'");
                    if (match.Success)
                        dsmfver.Text = match.Groups[1].Value;
                    else
                        dsmfver.Text = "(unknown)";
                }
                else
                    dsmfver.Text = "(unknown)";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string l20ver = client.DownloadString("http://www.simplemachines.org/smf/current-version.js?version=2.0");
            string l11ver = client.DownloadString("http://www.simplemachines.org/smf/current-version.js");

            twover.Text = l20ver.Replace("window.smfVersion = \"SMF ", "").Replace("\";", "");
            onever.Text = l11ver.Replace("window.smfVersion = \"SMF ", "").Replace("\";", "");

            dl20.Enabled = true;
            dl11.Enabled = true;

            button4.Enabled = false;
        }

        private void dl20_Click(object sender, EventArgs e)
        {
            // Create a new save dialog.
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = "zip";
            sf.AddExtension = true;
            sf.FileName = "smf_" + twover.Text.Replace(".", "-") + "_install.zip";
            sf.Filter = "Zip files|*.zip";
            sf.CheckFileExists = false;
            sf.CheckPathExists = true;

            // Show the dialog.
            DialogResult sfres = sf.ShowDialog();

            // Quit if we did something wrong-err, weird.
            if (sfres == DialogResult.Cancel || string.IsNullOrEmpty(sf.FileName))
                return;

            // Mess with some controls.
            dl20.Enabled = false;
            dl20.Text = "Downloading...";

            // Start downloading! DLUpdateCompleted will take over once it's done.
            WebClient client = new WebClient();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(dl20Completed);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(dl20ProgressChanged);
            client.DownloadFileAsync(new Uri("http://mirror.ord.simplemachines.org/index.php/smf_" + twover.Text.Replace(".", "-") + "_install.zip"), @sf.FileName);
            dl20f = sf.FileName;
        }
        private void dl20Completed(object sender, AsyncCompletedEventArgs e)
        {
            dl20.Text = "Download complete!";
            DialogResult a = message.question("Download complete! Do you want to set up the debugging environment now?", MessageBoxButtons.YesNo);

            if (a == DialogResult.Yes)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select the directory where the environment should be created...";
                fb.ShowDialog();

                string s = fb.SelectedPath;
                if (Directory.Exists(s))
                {
                    smfPath.Text = s;

                    // Start extracting the downloaded archive.
                    using (ZipFile zip1 = ZipFile.Read(dl20f))
                    {
                        // here, we extract every entry, but we could extract conditionally
                        // based on entry name, size, date, checkbox status, etc.  
                        foreach (ZipEntry en in zip1)
                        {
                            en.Extract(s, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }

                    string contents = File.ReadAllText(s + "/index.php");

                    Match match = Regex.Match(contents, @"'SMF ([^']*)'");
                    if (match.Success)
                        dsmfver.Text = match.Groups[1].Value;

                    dl20.Text = "Environment is set!";
                    dl11.Enabled = false;
                }
            }
        }
        private void dl20ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dl20.Text = "Downloading... " + e.ProgressPercentage + "%";
        }

        private void dl11_Click(object sender, EventArgs e)
        {
            // Create a new save dialog.
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = "zip";
            sf.AddExtension = true;
            sf.FileName = "smf_" + onever.Text.Replace(".", "-") + "_install.zip";
            sf.Filter = "Zip files|*.zip";
            sf.CheckFileExists = false;
            sf.CheckPathExists = true;

            // Show the dialog.
            DialogResult sfres = sf.ShowDialog();

            // Quit if we did something wrong-err, weird.
            if (sfres == DialogResult.Cancel || string.IsNullOrEmpty(sf.FileName))
                return;

            // Mess with some controls.
            dl11.Enabled = false;
            dl11.Text = "Downloading...";

            // Start downloading! DLUpdateCompleted will take over once it's done.
            WebClient client = new WebClient();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(dl11Completed);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(dl11ProgressChanged);
            client.DownloadFileAsync(new Uri("http://mirror.ord.simplemachines.org/index.php/smf_" + onever.Text.Replace(".", "-") + "_install.zip"), @sf.FileName);
            dl11f = sf.FileName;
        }
        private void dl11Completed(object sender, AsyncCompletedEventArgs e)
        {
            dl11.Text = "Download complete!";
            DialogResult a = message.question("Download complete! Do you want to set up the debugging environment now?", MessageBoxButtons.YesNo);

            if (a == DialogResult.Yes)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select the directory where the environment should be created...";
                fb.ShowDialog();

                string s = fb.SelectedPath;
                if (Directory.Exists(s))
                {
                    smfPath.Text = s;

                    // Start extracting the downloaded archive.
                    using (ZipFile zip1 = ZipFile.Read(dl11f))
                    {
                        // here, we extract every entry, but we could extract conditionally
                        // based on entry name, size, date, checkbox status, etc.  
                        foreach (ZipEntry en in zip1)
                        {
                            en.Extract(s, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }

                    string contents = File.ReadAllText(s + "/index.php");

                    Match match = Regex.Match(contents, @"'SMF ([^']*)'");
                    if (match.Success)
                        dsmfver.Text = match.Groups[1].Value;

                    dl11.Text = "Environment is set!";
                    dl20.Enabled = false;
                }
            }
        }
        private void dl11ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dl11.Text = "Downloading... " + e.ProgressPercentage + "%";
        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.smfPath) && Directory.Exists(Properties.Settings.Default.smfPath) && File.Exists(Properties.Settings.Default.smfPath + "/index.php"))
            {
                string contents = File.ReadAllText(Properties.Settings.Default.smfPath + "/index.php");
                
                Match match = Regex.Match(contents, @"'SMF ([^']*)'");
                if (match.Success)
                    dsmfver.Text = match.Groups[1].Value;
            }
        }

        private void testSmOrgDetails_Click(object sender, EventArgs e)
        {
            // Create hashed strings
            string base64username = System.Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(smOrgUsername.Text));
            
            // Now create a hash.
            string toencode = smOrgUsername.Text.ToLower() + smOrgPassword.Text;


            SHA1 hash = SHA1CryptoServiceProvider.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(toencode);
            byte[] result = hash.ComputeHash(Combine(hash.ComputeHash(buffer), Encoding.UTF8.GetBytes("w$--IN5~2a")));

            
            /*using (SHA1 shaM = new SHA1Managed())
            {
                result = shaM.ComputeHash(Encoding.UTF8.GetBytes(shaM.ComputeHash(buffer) + "w$--IN5~2a"));
            }*/

            idUsername.Text = "web_user=" + base64username + "&check&web_pass=" + BitConverter.ToString(result).Replace("-", "");
        }
        private byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
    }
}
