using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlashButton
{
    public partial class FlashButtonControl : UserControl
    {
        public EventHandler OnFlashEnd;

        private bool flashing;
        private int fadeTime, fadeMax;
        private Color fadeColor, startColor;
        private Timer flashTimer = new Timer();

        private const int fadeResolution = 10;

        public FlashButtonControl()
        {
            InitializeComponent();
            flashTimer.Interval = fadeResolution;
            flashTimer.Tick += flashTimertick;
        }

        public void Flash(Color color, int fadetime)
        {
            CancelFlash();
            flashTimer.Start();
            fadeColor = color;
            startColor = button.BackColor;

            button.BackColor = color;
            fadeTime = fadetime;
            fadeMax = fadetime;
        }

        public void CancelFlash()
        {
            if (flashing)
            {
                fadeTime = 0;
                flashing = false;
                flashTimer.Stop();
                button.BackColor = startColor;
                if (OnFlashEnd != null) OnFlashEnd.Invoke(this, null);
            }
        }

        private void flashTimertick(object sender, EventArgs e)
        {
            fadeTime -= fadeResolution;
            if (fadeTime <= 0)
            {
                CancelFlash();
            }
            else
            {
                button.BackColor = Blend(fadeColor, startColor, (double)fadeTime/fadeMax);
                Refresh();
            }
        }

        public static Color Blend(Color sartColor, Color endColor, double ratio)
        {
            var a = (byte)((sartColor.A * ratio) + endColor.A * (1 - ratio));
            var r = (byte)((sartColor.R * ratio) + endColor.R * (1 - ratio));
            var g = (byte)((sartColor.G * ratio) + endColor.G * (1 - ratio));
            var b = (byte)((sartColor.B * ratio) + endColor.B * (1 - ratio));

            return Color.FromArgb(a, r, g, b);
        }
    }
}
