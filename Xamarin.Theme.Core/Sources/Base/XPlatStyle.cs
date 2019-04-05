using System;
namespace Xamarin.Theme.Core
{
    public class XPlatStyle : IXPlatStyle
    {
        public XPlatColor Color { get; private set; } = null;

        public XPlatStyle() { }

        public XPlatStyle(XPlatStyle style)
            : this(style?.Color)
        { }

        public XPlatStyle(XPlatColor color)
        {
            Color = color;
        }
    }
}
