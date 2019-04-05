using System;
namespace Xamarin.Theme.Core
{
    public interface IXPlatLabelStyle : IXPlatStyle
    {
        XPlatFont Font { get; }

        XPlatTextAlignType TextAlign { get; }
    }
}
