using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModBuilder.Classes
{
    class PackageWorker
    {
        public static void bootstrapLoad(string dir)
        {
            // Show a loadProject dialog.
            loadProject lp = new loadProject();
            lp.Show();

            // Load the project.
            bool stat = lp.openProjDir(dir);

            // Check the status.
            if (stat == false)
                MessageBox.Show("An error occured while loading the project.", "Loading project", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Close the loadProject dialog.
            lp.Close();
        }
    }
}
