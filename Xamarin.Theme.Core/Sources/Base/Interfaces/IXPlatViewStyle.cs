using System;
namespace Xamarin.Theme.Core
{
    public interface IXPlatViewStyle
    {
        XPlatColor BackgroundColor { get; }

        XPlatColor BorderColor { get; }

        XPlatCornerRadius CornerRadius { get; }
    }
}
