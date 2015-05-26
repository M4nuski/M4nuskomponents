using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashButton
{
    public partial class FlashButton2 : Control

    {
        public EventHandler OnFlashEnd;

        private bool flashing;
        private int fadeTime, fadeMax;
        private Color startColor;
        private int[] fadeColor;
        private Timer flashTimer = new Timer();

        private const int fadeResolution = 10;

        public FlashButton2()
        {
            InitializeComponent();
            flashTimer.Interval = fadeResolution;
            flashTimer.Tick += flashTimertick;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            flashButton.Refresh();
        }

        public void Flash(Color color, int FadeTime)
        {
            CancelFlash();
            flashTimer.Start();
            fadeColor = new int[] {color.A, color.R, color.G, color.B};
            startColor = BackColor;
            BackColor = color;
            fadeTime = FadeTime;
            fadeMax = fadeTime;
        }

        public void CancelFlash()
        {
            if (flashing)
            {
                fadeTime = 0;
                flashing = false;
                flashTimer.Stop();
                BackColor = startColor;
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
                BackColor = Color.FromArgb(fadeColor[0] * fadeTime / fadeMax, fadeColor[1] * fadeTime / fadeMax,
                    fadeColor[2]*fadeTime/fadeMax, fadeColor[3]*fadeTime/fadeMax);
                Refresh();
            }
        }


    }
}
