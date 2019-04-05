using System;
namespace Xamarin.Theme.Core
{
    public class XPlatLabelStyle : XPlatStyle, IXPlatLabelStyle
    {
        public XPlatFont Font { get; private set; } = null;

        public XPlatTextAlignType TextAlign { get; private set; } = XPlatTextAlignType.Default;

        public XPlatLabelStyle(XPlatStyle style, XPlatFont font = null, XPlatTextAlignType? textAlign = null)
            : base(style)
        {
            this.Font = font;

            if (textAlign.HasValue)
                this.TextAlign = textAlign.Value;
        }

        public XPlatLabelStyle(XPlatLabelStyle style, XPlatFont font = null, XPlatTextAlignType? textAlign = null)
            : this((XPlatStyle)style, font ?? style.Font, textAlign ?? style.TextAlign)
        {
        }

        public XPlatLabelStyle(XPlatColor color = null, XPlatFont font = null, XPlatTextAlignType textAlign = XPlatTextAlignType.Default)
            : base(color)
        {
            this.Font = font;
            this.TextAlign = textAlign;
        }
    }
}
