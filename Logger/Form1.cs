using System;
using System.Windows.Forms;

namespace Logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logger.AddLine(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logger.AddText(textBox2.Text);
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Clear();
        }
    }
}
