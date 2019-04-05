using System;
namespace Xamarin.Theme.Core
{
    public class XPlatFont : IXPlatFont
    {
        public string FontName { get; private set; }

        public string FontStyle { get; private set; }

        public float? FontSize { get; private set; }

        public XPlatFont(IXPlatFont font, float? fontSize = null)
            : this(font.FontName, fontSize ?? font.FontSize, font.FontStyle)
        { }

        public XPlatFont(string fontName, float? fontSize, string fontStyle = null)
        {
            FontName = fontName;
            FontSize = fontSize;
            FontStyle = fontStyle;
        }
    }
}
