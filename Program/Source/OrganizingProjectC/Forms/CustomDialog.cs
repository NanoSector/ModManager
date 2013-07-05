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
    public partial class CustomDialog : Form
    {
        public CustomDialog(string text, string title = "Mod Builder", string ok = "OK", string cnl = "Cancel")
        {
            InitializeComponent();
            this.Text = title;
            okbtn.Text = ok;
            cnlbtn.Text = cnl;
            label1.Text = text;
        }

        private void CustomDialog_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SystemIcons.Question.ToBitmap();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void cnlbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }
    }
}
