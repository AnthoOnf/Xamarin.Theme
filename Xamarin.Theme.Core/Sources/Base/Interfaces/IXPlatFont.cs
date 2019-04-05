using System;
namespace Xamarin.Theme.Core
{
    public interface IXPlatFont
    {
        string FontName { get; }

        string FontStyle { get; }

        float? FontSize { get; }
    }
}
