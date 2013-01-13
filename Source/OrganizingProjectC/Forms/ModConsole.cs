using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModBuilder.Forms
{
    public partial class ModConsole : Form
    {
        private modEditor me;

        DateTime starttime = new DateTime();
        public ModConsole()
        {
            InitializeComponent();
        }

        private void ModConsole_Load(object sender, EventArgs e)
        {

        }

        public void Attach(modEditor me)
        {
            this.me = me;
        }

        public void startMeasureTime()
        {
            starttime = DateTime.Now;
        }

        public void endMeasureTime()
        {
            System.Threading.Thread.Sleep(1000);
            DateTime elapsedTime = DateTime.Now;
            var measuredTime = (starttime - elapsedTime).TotalSeconds;
            Message("Took " + measuredTime + " seconds");
        }

        public void Message(string text)
        {
            modConsoleBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text);
        }
    }
}
