using System;
namespace Xamarin.Theme.Core
{
    public interface IXPlatCornerRadius
    {
        bool AllCorner { get; }

        bool BottomLeft { get; }

        bool BottomRight { get; }

        bool TopLeft { get; }

        bool TopRight { get; }

        int Radius { get; }
    }
}
