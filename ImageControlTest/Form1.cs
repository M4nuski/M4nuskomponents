using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageControl1.SourceImage = new Bitmap(openFileDialog1.FileName);
                    imageControl1.Focus();
                }
                catch (Exception ex)
                {
                    Text = ex.Message;
                }
            }
        }
    }
}
