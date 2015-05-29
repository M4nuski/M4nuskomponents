using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlasherTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            colorDialog1.Color = Color.Red;

            //flashButton51.FlashEnd += flashEnded;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void flashEnded(object sender, EventArgs e)
        {
            //flashButton51.Text = "FlashButton";
        }

        private static int safeTextParse(string s)
        {
            int result;
            try
            {
                result = Convert.ToInt32(s, 10);
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {

//flashButton51.Text = "Flashing!";
           // flashButton51.Flash(colorDialog1.Color, safeTextParse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
           controlFlasher1.CancelAllFlash();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            controlFlasher1.Flash(button4, Color.Blue, 200);
            controlFlasher1.Flash(menuStrip1.Items[0].GetCurrentParent());
            controlFlasher1.Flash(comboBox1, colorDialog1.Color, safeTextParse(textBox1.Text));
        }

        private void controlFlasher1_FlashEnd(object sender, EventArgs e)
        {
            Text = "end of flash for " + sender.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
