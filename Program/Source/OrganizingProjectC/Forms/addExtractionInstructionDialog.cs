using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace ModBuilder.Forms
{
    public partial class addExtractionInstructionDialog : Form
    {
        string workingDirectory;
        modEditor me;
        SQLiteConnection conn;
        int editing;
        public addExtractionInstructionDialog(string workingDirectory, modEditor me, SQLiteConnection conn, int editing)
        {
            InitializeComponent();
            this.workingDirectory = workingDirectory;
            this.me = me;
            this.conn = conn;
            this.editing = editing;
            fileComboBox.Items.Clear();
            refreshComboboxList(workingDirectory + "\\Source");

            if (editing != 0)
            {
                string sql = "SELECT file_name, destination FROM files WHERE id = " + editing + " LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["destination"].ToString() != "$boarddir" && reader["destination"].ToString() != "$sourcedir" && reader["destination"].ToString() != "$themedir" && reader["destination"].ToString() != "$languagedir" && reader["destination"].ToString() != "$avatardir" && reader["destination"].ToString() != "$imagesdir")
                    {
                        char[] chars = { '/' };
                        string[] pieces = reader["destination"].ToString().Split(chars, 2);
                        filePrefix.SelectedItem = pieces[0];
                        fileName.Text = pieces[1];
                    }
                    else
                        filePrefix.SelectedItem = reader["destination"].ToString();

                    fileComboBox.SelectedItem = reader["file_name"];
                }
            }
        }

        public void refreshComboboxList(string dir)
        {

            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);

            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {

                string name = d.FullName.Replace(workingDirectory + "\\Source\\", "");
                fileComboBox.Items.Add(name);
                refreshComboboxList(d.FullName);
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                string name = f.FullName.Replace(workingDirectory + "\\Source\\", "");
                // create a new node
                fileComboBox.Items.Add(name);
            }
        }

        private void refreshComboBox_Click(object sender, EventArgs e)
        {
            fileComboBox.Items.Clear();
            refreshComboboxList(workingDirectory + "\\Source");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileComboBox.SelectedItem.ToString()) || string.IsNullOrEmpty(filePrefix.SelectedItem.ToString()))
            {
                MessageBox.Show("You did not fill in all fields; all fields are required.", "Saving instruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql;
            if (editing == 0)
            {
                sql = "INSERT INTO files(id, file_name, destination, type) VALUES(null, @fileName, @destination)";
            }
            else
            {
                sql = "UPDATE files SET file_name = @fileName, destination = @destination, type = @type WHERE id = @editing";
            }

            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, conn);

            command.Parameters.AddWithValue("@fileName", fileComboBox.SelectedItem);
            string ext = "";
            if (!string.IsNullOrEmpty(fileName.Text))
                ext = "/" + fileName.Text;
            command.Parameters.AddWithValue("@destination", filePrefix.SelectedItem + ext);
            command.Parameters.AddWithValue("@editing", editing);

            command.ExecuteNonQuery();

            me.refreshExtractionTree();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
