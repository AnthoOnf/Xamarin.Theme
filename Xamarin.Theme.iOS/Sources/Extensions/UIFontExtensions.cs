using System;
using System.Collections.Generic;
using UIKit;
using Xamarin.Theme.Core;

namespace Xamarin.Theme.iOS.Sources.Extensions
{
    public static class UIFontExtensions
    {
        public static IDictionary<string, UIFont> FontCache = new Dictionary<string, UIFont>();

        public static UIFont ToNative(this XPlatFont @this)
        {
            Func<float> getSize = () => @this == null || @this.FontSize == null || !@this.FontSize.HasValue ? (float)UIFont.SystemFontSize : @this.FontSize.Value;
            Func<UIFont> getFont = () => @this == null || @this.FontName == null ? UIFont.SystemFontOfSize(getSize()) : GetFont(@this.FontName, getSize());

            return getFont();
        }

        public static UIFont GetFont(string name, float size)
        {
            var key = name + size.ToString();
            if (!FontCache.ContainsKey(key) || FontCache[key] == null)
                FontCache[key] = UIFont.FromName(name, size);
            return FontCache[key];
        }
    }
}
