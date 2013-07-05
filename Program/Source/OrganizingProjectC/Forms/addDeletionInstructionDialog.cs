using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ModBuilder.Forms
{
    public partial class addDeletionInstructionDialog : Form
    {
        string workingDirectory;
        modEditor me;
        SQLiteConnection conn;
        int editing;
        public addDeletionInstructionDialog(string workingDirectory, modEditor me, SQLiteConnection conn, int editing)
        {
            InitializeComponent();
            this.workingDirectory = workingDirectory;
            this.me = me;
            this.conn = conn;
            this.editing = editing;

            if (editing != 0)
            {
                string sql = "SELECT file_name, type FROM files_delete WHERE id = " + editing + " LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    char[] chars = { '/' };
                    string[] pieces = reader["file_name"].ToString().Split(chars, 2);
                    if (pieces.Length == 1)
                        fileName.Text = pieces[0];
                    else if (pieces.Length == 2)
                    {
                        filePrefix.SelectedItem = pieces[0];
                        fileName.Text = pieces[1];
                    }

                    whatIs_Dir.Checked = reader["type"].ToString() == "dir";
                    whatIs_File.Checked = reader["type"].ToString() == "file";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName.Text) || string.IsNullOrEmpty(filePrefix.SelectedItem.ToString()))
            {
                MessageBox.Show("You did not fill in all fields; all fields are required.", "Adding instruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (whatIs_Dir.Checked == false && whatIs_File.Checked == false)
            {
                MessageBox.Show("Please select the type of the item you want to delete before continuing.", "Adding instruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql;
            if (editing == 0)
                sql = "INSERT INTO files_delete(id, file_name, type) VALUES(null, @fileName, @type)";
            else
                sql = "UPDATE files_delete SET file_name = @fileName, type = @type WHERE id = @editing";

            string type = "";
            if (whatIs_Dir.Checked == true)
                type = "dir";
            else
                type = "file";


            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.Parameters.AddWithValue("@fileName", filePrefix.SelectedItem + "/" + fileName.Text);
            command.Parameters.AddWithValue("@editing", editing);
            command.Parameters.AddWithValue("@type", type);

            command.ExecuteNonQuery();

            me.refreshExtractionTree();

            Close();
        }
    }
}
