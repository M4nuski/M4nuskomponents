# M4nuskomponents
Collection of custom controls and components
Including test/demo apps

# Logger
Textbox rigged to allow direct use as logger. 
Internal string builder, automatic count/date/time stamping of line with ToString format editable in designer.

# ImageControl
PictureBox with built-in controls to be used with "usual" UX mouse controls for zooming and panning inside image.

# ControlFlasher
Component for simple UI feedback. Call the component with default (designer-time) or on-the-fly values to flash/fade the background color of any Control-class component.

i.e. :
```
private void ColorSelectButton_Click(object sender, EventArgs e)
{
    if (colorDialog1.ShowDialog() == DialogResult.OK)
    {
        controlFlasher1.Flash(ColorSelectButton, Color.GreenYellow, 350);
		theColor = colorDialog1.Color;
    }
    else
    {
        controlFlasher1.Flash(ColorSelectButton, Color.Red, 550);
    }
}
```
		