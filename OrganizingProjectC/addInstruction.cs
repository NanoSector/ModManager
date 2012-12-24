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

namespace OrganizingProjectC
{
    public partial class addInstruction : Form
    {
        private string wD;
        private SQLiteConnection co;

        // <summary>
        // Loads and sets up the environment.
        // </summary>
        public addInstruction(string workingDirectory, SQLiteConnection conn, int editing)
        {
            // Start the form.
            InitializeComponent();

            // Set the working directory.
            wD = workingDirectory;

            // And set the SQLite connection.
            co = conn;

            // Are we editing anything?
            if (editing != 0)
            {
                // Yes we are... Set up the query.
                string sql = "SELECT before, after, type FROM instructions WHERE id = " + editing;

                // Execute it.
                SQLiteCommand command = new SQLiteCommand(sql, co);
                SQLiteDataReader reader = command.ExecuteReader();

                // And read and insert the data.
                while (reader.Read())
                {
                    before.Text = (string) reader["before"];
                    after.Text = (string) reader["after"];
                    
                    // Gather and set the method.
                    switch ((string) reader["type"])
                    {
                        case "add_before":
                            method.SelectedItem = "Add before";
                            break;

                        case "add_after":
                            method.SelectedItem = "Add after";
                            break;

                        default:
                            method.SelectedItem = "Replace";
                            break;
                    }
                }
            }
        }

        // <summary>
        // Handles the saving and checking of the values entered in the form.
        // </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            string type;
            
            // Try to get the method type.
            switch (method.SelectedItem.ToString())
            {
                case "Add before":
                    type = "add_before";
                    break;

                case "Add after":
                    type = "add_after";
                    break;

                default:
                    type = "replace";
                    break;
            }

            // Insert the row.
            string sql = "INSERT INTO instructions(before, after, type) VALUES(\"" + before.Text + "\", \"" + after.Text + "\", \"" + type + "\")";

            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, co);

            Close();
        }
    }
}
