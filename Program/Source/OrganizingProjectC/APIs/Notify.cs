using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModBuilder.APIs
{
    class Notify
    {
        // Needs refreshing and more functionality on a per type basis.
        public DialogResult information(string message, MessageBoxButtons buttontype)
        {
            DialogResult result = MessageBox.Show(message, "Information", buttontype, MessageBoxIcon.Information);

            return result;
        }

        public DialogResult question(string message, MessageBoxButtons buttontype)
        {
            DialogResult result = MessageBox.Show(message, "Question", buttontype, MessageBoxIcon.Question);

            return result;
        }

        public DialogResult error(string message, MessageBoxButtons buttontype)
        {
            DialogResult result = MessageBox.Show(message, "Error", buttontype, MessageBoxIcon.Error);

            return result;
        }

        public DialogResult warning(string message, MessageBoxButtons buttontype)
        {
            DialogResult result = MessageBox.Show(message, "Warning", buttontype, MessageBoxIcon.Warning);

            return result;
        }
    }
}
