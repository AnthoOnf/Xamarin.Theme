using System;
namespace Xamarin.Theme.Core
{
    public interface IXPlatButtonStyle
    {
        XPlatColor BackgroundColor { get; }

        XPlatCornerRadius CornerRadius { get; }

        XPlatColor BorderColor { get; }
    }
}
