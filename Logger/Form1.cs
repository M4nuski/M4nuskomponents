using System;
using System.Windows.Forms;

namespace LoggerTest
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
                logger1.AddLine(textBox1.Text);
                textBox1.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger1.Clear(true);
        }
    }
}
