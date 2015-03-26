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
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Clear(true);
        }
    }
}
