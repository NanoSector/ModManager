using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Mod_Builder.Classes
{
    public class Log
    {
        // The actual log buffer.
        List<string> logBuffer = new List<string>();

        // The log dialog if we have one.
        Forms.LogForm logform;

        /**
         * <summary>Log some data to the log.</summary>
         * <param name="data">The data to log.</param>
         * <param name="level">The level to log it at.</param>
         */
        public bool log(string data, string level = "INFO")
        {
            string message = DateTime.Now.ToString() + " [" + level + "] " + data;
            this.logBuffer.Add(message);

            if (this.logform is Forms.LogForm && this.logform.Visible)
                this.logform.updateContents(message);

            return true;
        }

        /**
         * <summary>Shows or hides the log dialog.</summary>
         */
        public void toggleLogDialog()
        {
            if (this.logform is Forms.LogForm)
            {
                this.logform.Close();
                this.logform = null;
            }
            else
            {
                this.logform = new Forms.LogForm();
                this.logform.refreshContents(this.logBuffer);
                this.logform.Show();
            }
        }
    }
}
