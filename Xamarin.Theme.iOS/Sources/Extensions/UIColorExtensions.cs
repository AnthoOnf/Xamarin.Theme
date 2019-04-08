using System;
using CoreGraphics;
using UIKit;
using Xamarin.Theme.Core;

namespace Xamarin.Theme.iOS.Sources.Extensions
{
    public static class UIColorExtensions
    {
        public static CGColor ToCGColor(this XPlatColor color)
        {
            if (color == null)
                return new CGColor(0, 0, 0, 0);
            return new CGColor(color.Red, color.Green, color.Blue, (int)(color.Alpha * 255));
        }

        public static UIColor ToNative(this XPlatColor color)
        {
            if (color == null)
                return UIColor.Clear;
            return UIColor.FromRGBA(color.Red, color.Green, color.Blue, (int)(color.Alpha * 255));
        }
    }
}
