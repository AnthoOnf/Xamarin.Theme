using System;
namespace Xamarin.Theme.Core
{
    public class XPlatButtonStyle : XPlatLabelStyle, IXPlatButtonStyle
    {
        public XPlatColor BackgroundColor { get; private set; }

        public XPlatCornerRadius CornerRadius { get; private set; }

        public XPlatColor BorderColor { get; private set; }

        public XPlatButtonStyle(XPlatLabelStyle labelStyle = null, XPlatColor backgroundColor = null, XPlatCornerRadius cornerRadius = null, XPlatColor borderColor = null)
            : this(labelStyle, cornerRadius, borderColor)
        {
            BackgroundColor = backgroundColor;
        }

        public XPlatButtonStyle(XPlatLabelStyle labelStyle = null, XPlatCornerRadius cornerRadius = null, XPlatColor borderColor = null)
            : base(labelStyle)
        {
            CornerRadius = cornerRadius;
            BorderColor = borderColor;
        }
    }
}
