using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FlasherTest
{
    public partial class ControlFlasher : Component
    {

        [Category("Action"), Description("Trigger after flash ended."), Browsable(true)]
        public event EventHandler FlashEnd;

        private int fadeResolution = 50;
        [Category("Behaviour"), Description("Internal timer interval resolution.")]
        public int FadeResolution
        {
            get { return fadeResolution; }
            set { fadeResolution = value; flashTimer.Interval = value; }
        }

        private int flashDuration = 750;
        [Category("Behaviour"), Description("Default fade duration of flash.")]
        public int DefaultFlashDuration { get { return flashDuration; } set { flashDuration = value; } }

        private Color defaultColor = Color.Red;
        [Category("Appearance"), Description("Default flash color.")]
        public Color DefaultColor { get { return defaultColor; } set { defaultColor = value; } }

        private class flashData
        {
            public bool flashing;
            public Control targetControl;
            public int currentFlashTime, maxFlashTime;
            public Color originalColor, flashColor;
        }

        private Timer flashTimer = new Timer();
        private List<flashData> targets = new List<flashData>();

        public ControlFlasher()
        {
            InitializeComponent();
            flashTimer.Interval = fadeResolution;
            flashTimer.Tick += flashTimertick;
            flashTimer.Start();
        }

        public ControlFlasher(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            flashTimer.Interval = fadeResolution;
            flashTimer.Tick += flashTimertick;
            flashTimer.Start();
        }

        private flashData FindOrCreate(Control control)
        {
            foreach (var t in targets)
            {
                if (t.targetControl == control) return t;
            }
            var newFlash = new flashData();
            targets.Add(newFlash);
            return newFlash;
        }

        public void Flash(Control TargetControl)
        {
            Flash(TargetControl, defaultColor, DefaultFlashDuration);
        }

        public void Flash(Control TargetControl, Color FlashColor, int FlashDuration)
        {
            if (TargetControl != null)
            {
                var t = FindOrCreate(TargetControl);
                if (!t.flashing)
                {
                    t.targetControl = TargetControl;
                    t.flashColor = FlashColor;
                    t.originalColor = t.targetControl.BackColor;
                    t.targetControl.BackColor = FlashColor;

                    t.currentFlashTime = FlashDuration;
                    t.maxFlashTime = FlashDuration;

                    t.flashing = true;
                }
                else
                {
                    t.flashColor = FlashColor;
                    t.currentFlashTime = FlashDuration;
                    t.maxFlashTime = FlashDuration;
                }
            }
        }

        private void cancel(flashData data)
        {
            data.flashing = false;
            data.targetControl.BackColor = data.originalColor;
            data.targetControl.Refresh();
            if (FlashEnd != null) FlashEnd(data.targetControl, new EventArgs());
        }

        public void CancelFlash(Control TargetControl)
        {
            foreach (var t in targets)
            {
                if (t.targetControl == TargetControl)
                {
                    cancel(t);
                }
            }
        }

        public void CancelAllFlash()
        {
            foreach (var t in targets)
            {
                cancel(t);
            }
        }

        private void flashTimertick(object sender, EventArgs e)
        {
            foreach (var t in targets)
            {
                t.currentFlashTime -= fadeResolution;
                if (t.currentFlashTime <= 0)
                {
                    cancel(t);
                }
                else
                {
                    t.targetControl.BackColor = Blend(t.flashColor, t.originalColor, (double)t.currentFlashTime / t.maxFlashTime);
                    t.targetControl.Refresh();
                }
            }


            targets.RemoveAll(t => t.flashing == false);
        }

        private static Color Blend(Color sartColor, Color endColor, double ratio)
        {
            var r = (byte)((sartColor.R * ratio) + endColor.R * (1 - ratio));
            var g = (byte)((sartColor.G * ratio) + endColor.G * (1 - ratio));
            var b = (byte)((sartColor.B * ratio) + endColor.B * (1 - ratio));

            return Color.FromArgb(r, g, b);
        }
    }
}
