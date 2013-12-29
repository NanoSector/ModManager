using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ModBuilder.Forms
{
    public partial class Options : Form
    {
        string dl11f;
        string dl20f;
        public Options()
        {
            InitializeComponent();
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

            string[] updates = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "update_*.exe");
            foreach (string file in updates)
            {
                comboBox1.Items.Add(file.Replace(AppDomain.CurrentDomain.BaseDirectory + "update_", "").Replace(".exe", "").Replace("-", "."));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(smfPath.Text) && !Directory.Exists(smfPath.Text))
            {
                MessageBox.Show("The path to the SMF files you entered is invalid. Please check that it exists and try again.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            DialogResult a = MessageBox.Show("Download complete! Do you want to set up the debugging environment now?", "Mod Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (a == DialogResult.Yes)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select the directory where the environment should be created...";
                fb.ShowDialog();

                string s = fb.SelectedPath;
                if (Directory.Exists(s))
                {
                    // Start extracting the downloaded archive.
                    ZipFile.ExtractToDirectory(dl20f, s);
                    
                    // Check if index.php is there...
                    if (!File.Exists(s + "/index.php") || !File.Exists(s + "/Settings.php"))
                    {
                        MessageBox.Show("Your environment package is corrupt, since it does not contain an index.php or Settings.php in the root. Please try again later or check http://simplemachines.org/ for up-to-date information.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string contents = File.ReadAllText(s + "/index.php");

                    Match match = Regex.Match(contents, @"'SMF ([^']*)'");
                    if (match.Success)
                    {
                        dsmfver.Text = match.Groups[1].Value;
                        smfPath.Text = s;
                        dl20.Text = "Environment is set!";
                        dl11.Enabled = false;
                    }
                    else
                        MessageBox.Show("index.php contains no SMF version or an illegal version number!", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult a = MessageBox.Show("Download complete! Do you want to set up the debugging environment now?", "Options", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (a == DialogResult.Yes)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select the directory where the environment should be created...";
                fb.ShowDialog();

                string s = fb.SelectedPath;
                if (Directory.Exists(s))
                {
                    // Start extracting the downloaded archive.
                    ZipFile.ExtractToDirectory(dl11f, s);

                    // Check if index.php is there...
                    if (!File.Exists(s + "/index.php") || !File.Exists(s + "/Settings.php"))
                    {
                        MessageBox.Show("Your environment package is corrupt, since it does not contain an index.php or Settings.php in the root. Please try again later or check http://simplemachines.org/ for up-to-date information.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Grab the contents of index.php.
                    string contents = File.ReadAllText(s + "/index.php");

                    // Mix and match.
                    Match match = Regex.Match(contents, @"'SMF ([^']*)'");
                    if (match.Success)
                    {
                        dsmfver.Text = match.Groups[1].Value;
                        smfPath.Text = s;
                        dl11.Text = "Environment is set!";
                        dl20.Enabled = false;
                    }
                    else
                        MessageBox.Show("index.php contains no SMF version or an illegal version number!", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dl11ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dl11.Text = "Downloading... " + e.ProgressPercentage + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] toDelete = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "update_*.exe");

            foreach (string file in toDelete)
            {
                File.Delete(file);
            }

            MessageBox.Show(toDelete.Length + " update executables have been deleted.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "update_" + comboBox1.SelectedItem.ToString().Replace(".", "-") + ".exe"))
                MessageBox.Show("The requested version has either been moved or deleted, or was not found.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DialogResult result = MessageBox.Show("This will start an installer to revert this version of Mod Builder to the selected version, and this version will be closed. Are you okay with this?", "Options", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "update_" + comboBox1.SelectedItem.ToString().Replace(".", "-") + ".exe");
                Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "php.exe files|php.exe";
            fd.CheckFileExists = true;
            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Try a test call on this instance.
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = fd.FileName;
                p.StartInfo.Arguments = " -v";
                p.Start();

                string output = p.StandardOutput.ReadLine();

                if (output.Substring(0, 3) != "PHP")
                {
                    MessageBox.Show("The PHP instance is either not correctly compiled or is no PHP instance. Please try again.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Match version = Regex.Match(output, @"PHP ([^']*) \(");
                if (version.Success)
                {
                    phpver.Text = version.Groups[1].Value;
                    phppath.Text = fd.FileName;
                }
                else
                    MessageBox.Show("The PHP instance is either not correctly compiled or is no PHP instance. Please try again.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
