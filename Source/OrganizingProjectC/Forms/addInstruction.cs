using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ModBuilder
{
    public partial class addInstruction : Form
    {
        private string wD;
        private SQLiteConnection co;
        private modEditor me;
        int editing = 0;

        // <summary>
        // Loads and sets up the environment.
        // </summary>
        public addInstruction(string workingDirectory, SQLiteConnection conn, int editing, modEditor mode)
        {
            // Start the form.
            InitializeComponent();

            // Set the working directory.
            wD = workingDirectory;

            // And set the SQLite connection.
            co = conn;

            // ModEditor form
            me = mode;

            // Are we editing anything?
            if (editing != 0)
            {
                // Yes we are... Set up the query.
                string sql = "SELECT before, after, type, file, optional FROM instructions WHERE id = " + editing + " LIMIT 1";

                // Execute it.
                SQLiteCommand command = new SQLiteCommand(sql, co);
                SQLiteDataReader reader = command.ExecuteReader();

                // And read and insert the data.
                while (reader.Read())
                {
                    before.Text = (string) reader["before"];
                    after.Text = (string) reader["after"];

                    char[] chars = { '/' };
                    string[] pieces = reader["file"].ToString().Split(chars, 2);
                    filePrefix.SelectedItem = pieces[0];
                    fileEdited.Text = pieces[1];
                    
                    // Gather and set the method.
                    switch ((string) reader["type"])
                    {
                        case "add_before":
                            method.SelectedItem = "Add before";
                            break;

                        case "add_after":
                            method.SelectedItem = "Add after";
                            break;

                        case "end":
                            method.SelectedItem = "At the end of file";
                            break;

                        default:
                            method.SelectedItem = "Replace";
                            break;
                    }

                    // Check for an optional operation.
                    if (Convert.ToInt32(reader["optional"]) == 1)
                        optionalCheck.Checked = true;
                }
                this.editing = editing;
            }
        }

        // <summary>
        // Handles the saving and checking of the values entered in the form.
        // </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            string type;

            if ((string.IsNullOrEmpty(before.Text) && method.SelectedItem.ToString() != "At the end of file") || string.IsNullOrEmpty(after.Text) || string.IsNullOrEmpty(fileEdited.Text) || string.IsNullOrEmpty(method.SelectedItem.ToString()))
            {
                MessageBox.Show("Please check that you entered something in all the fields; they are all required.", "Check your content", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Try to get the method type.
            switch (method.SelectedItem.ToString())
            {
                case "Add before":
                    type = "add_before";
                    break;

                case "Add after":
                    type = "add_after";
                    break;

                case "At the end of file":
                    type = "end";
                    break;

                default:
                    type = "replace";
                    break;
            }

            int optional;
            switch (optionalCheck.Checked)
            {
                case true:
                    optional = 1;
                    break;

                default:
                    optional = 0;
                    break;
            }   

            // Insert the row, if we weren't editing. Else update the row.
            string sql;
            if (editing == 0)
            {
                sql = "INSERT INTO instructions(id, before, after, type, file, optional) VALUES(null, @beforeText, @afterText, @type, @fileEdited, @optional)";
            }
            else
            {
                sql = "UPDATE instructions SET before = @beforeText, after = @afterText, type = @type, file = @fileEdited, optional = @optional WHERE id = @editing";
            }

            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, co);
            command.Parameters.AddWithValue("@beforeText", before.Text);
            command.Parameters.AddWithValue("@afterText", after.Text);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@fileEdited", filePrefix.SelectedItem + "/" + fileEdited.Text);
            command.Parameters.AddWithValue("@optional", optional);
            command.Parameters.AddWithValue("@editing", editing);

            command.ExecuteNonQuery();

            me.refreshInstructionTree();

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (method.SelectedItem.ToString() == "At the end of file")
            {
                before.Text = "";
                before.Enabled = false;
            }
        }
    }
}
