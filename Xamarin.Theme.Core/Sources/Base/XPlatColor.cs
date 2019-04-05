using System;
namespace Xamarin.Theme.Core
{
    public class XPlatColor
    {
        public int Red { get; private set; }

        public int Green { get; private set; }

        public int Blue { get; private set; }

        public float Alpha { get; private set; }

        public XPlatColor(XPlatColor color)
            : this(color.Red, color.Green, color.Blue, color.Alpha)
        { }

        public XPlatColor(int red, int green, int blue, int alpha0to100 = 100)
            : this(red, green, blue, alpha0to100 / 100.0f)
        { }

        public XPlatColor(int red, int green, int blue, byte alphaHex)
            : this(red, green, blue, alphaHex / 255.0f)
        { }

        public XPlatColor(byte red, byte green, byte blue, byte alphaHex)
            : this((int)red, (int)green, (int)blue, alphaHex / 255.0f)
        { }

        public XPlatColor(float red0to1, float green0to1, float blue0to1, float alpha0to1)
            : this((int)(red0to1 * 255f), (int)(green0to1 * 255f), (int)(blue0to1 * 255f), alpha0to1)
        { }

        public XPlatColor(int red, int green, int blue, float alpha0to1)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha0to1;
        }
    }
}
