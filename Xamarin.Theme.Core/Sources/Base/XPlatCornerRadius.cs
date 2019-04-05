using System;
namespace Xamarin.Theme.Core
{
    public class XPlatCornerRadius : IXPlatCornerRadius
    {
        #region Properties
        public bool AllCorner => !BottomLeft && !BottomRight && !TopLeft && !TopRight;

        public bool BottomLeft { get; private set; }

        public bool BottomRight { get; private set; }

        public bool TopLeft { get; private set; }

        public bool TopRight { get; private set; }

        public int Radius { get; private set; }
        #endregion

        public XPlatCornerRadius(XPlatCornerRadius cornerRadius)
            : this(cornerRadius.Radius, cornerRadius.BottomLeft, cornerRadius.BottomRight, cornerRadius.TopLeft, cornerRadius.TopRight)
        { }

        public XPlatCornerRadius(bool allCorners, int radius = 5)
            : this(radius, allCorners, allCorners, allCorners, allCorners)
        {
        }

        public XPlatCornerRadius(int radius = 4, bool bottomLeft = false, bool bottomRight = false, bool topLeft = false, bool topRight = false)
        {
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
            TopLeft = topLeft;
            TopRight = topRight;
            Radius = radius;
        }
    }
}
