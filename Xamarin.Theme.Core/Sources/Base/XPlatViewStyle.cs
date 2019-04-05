using System;
namespace Xamarin.Theme.Core
{
    public class XPlatViewStyle : IXPlatViewStyle
    {
        public XPlatColor BackgroundColor { get; private set; }

        public XPlatCornerRadius CornerRadius { get; private set; }

        public XPlatColor BorderColor { get; private set; }

        public XPlatViewStyle(XPlatColor backgroundColor = null, XPlatCornerRadius cornerRadius = null, XPlatColor borderColor = null)
        {
            BackgroundColor = backgroundColor;
            CornerRadius = cornerRadius;
            BorderColor = borderColor;
        }
    }
}
