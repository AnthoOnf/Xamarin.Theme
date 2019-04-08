using System;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace Xamarin.Theme.iOS.Sources.Extensions
{
    public static class UIViewExtensions
    {
        #region Corner Radius
        public static void ApplyCornerRadius(this UIView currentView, UIRectCorner radiusCorners, int radius = 5)
             => ApplyCornerRadius(currentView, radiusCorners, false);

        public static void CornerRadiusTop(this UIView currentView, bool remove = false, int radius = 5)
            => ApplyCornerRadius(currentView, UIRectCorner.TopLeft | UIRectCorner.TopRight, remove);

        public static void CornerRadiusBottom(this UIView currentView, bool remove = false, int radius = 5)
            => ApplyCornerRadius(currentView, UIRectCorner.BottomLeft | UIRectCorner.BottomRight, remove);

        public static void CornerRadiusLeftBottom(this UIView currentView, bool remove = false, int radius = 5)
             => ApplyCornerRadius(currentView, UIRectCorner.BottomLeft, remove);

        public static void CornerRadiusLeftTop(this UIView currentView, bool remove = false, int radius = 5)
             => ApplyCornerRadius(currentView, UIRectCorner.TopLeft, remove);

        public static void CornerRadiusRightBottom(this UIView currentView, bool remove = false, int radius = 5)
            => ApplyCornerRadius(currentView, UIRectCorner.BottomRight, remove);

        public static void CornerRadiusRightTop(this UIView currentView, bool remove = false, int radius = 5)
            => ApplyCornerRadius(currentView, UIRectCorner.TopRight, remove);

        public static void ApplyCornerRadius(UIView currentView, UIRectCorner radiusCorners, bool remove = false, int radius = 4)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                currentView.Layer.MaskedCorners = radiusCorners.ToCornerMask();
                currentView.Layer.CornerRadius = radius;
            }
            else
            {
                UIBezierPath maskPath = UIBezierPath.FromRoundedRect(currentView.Bounds, radiusCorners, remove ? new CGSize(0, 0) : new CGSize(radius, radius));
                CAShapeLayer maskLayer = new CAShapeLayer();
                maskLayer.Frame = currentView.Bounds;
                maskLayer.Path = maskPath.CGPath;
                currentView.Layer.Mask = maskLayer;
            }
        }

        public static CACornerMask ToCornerMask(this UIRectCorner corner)
        {
            CACornerMask mask = 0;

            if (corner.Has(UIRectCorner.AllCorners) || corner.Has(UIRectCorner.TopLeft))
                mask |= CACornerMask.MinXMinYCorner;
            if (corner.Has(UIRectCorner.AllCorners) || corner.Has(UIRectCorner.TopRight))
                mask |= CACornerMask.MaxXMinYCorner;
            if (corner.Has(UIRectCorner.AllCorners) || corner.Has(UIRectCorner.BottomLeft))
                mask |= CACornerMask.MinXMaxYCorner;
            if (corner.Has(UIRectCorner.AllCorners) || corner.Has(UIRectCorner.BottomRight))
                mask |= CACornerMask.MaxXMaxYCorner;

            return mask;
        }

        #endregion

        #region Border Radius
        public static void BorderCornerRadiusAll(this UIView currentView, UIColor color = null, int radius = 4)
            => ApplyBorder(currentView, UIRectCorner.AllCorners, radius, color);

        public static void BorderCornerRadiusTop(this UIView currentView, UIColor color = null, int radius = 4)
            => ApplyBorder(currentView, UIRectCorner.TopLeft | UIRectCorner.TopRight, radius, color);

        public static void BorderCornerRadiusBottom(this UIView currentView, UIColor color = null, int radius = 4)
            => ApplyBorder(currentView, UIRectCorner.BottomLeft | UIRectCorner.BottomRight, radius, color);

        public static void ApplyBorder(this UIView currentView, UIRectCorner radiusCorners, int radius = 0, UIColor color = null, float lineWidth = 1f)
        {
            var col = color == null ? UIColor.FromRGB(61, 71, 82).CGColor : color.CGColor;

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                currentView.Layer.MaskedCorners = radiusCorners.ToCornerMask();
                currentView.Layer.CornerRadius = radius;
                currentView.Layer.BorderWidth = lineWidth;
                currentView.Layer.BorderColor = col;
            }
            else
            {
                UIBezierPath maskPath = UIBezierPath.FromRoundedRect(currentView.Bounds, radiusCorners, new CGSize(radius, radius));
                ApplyBorder(maskPath, currentView, col, lineWidth);
            }
        }

        private static CAShapeLayer ApplyBorder(UIBezierPath maskPath, UIView view, CGColor color = null, float lineWidth = 2f)
        {
            const string name = "___borderlayer___";

            var borderLayer = new CAShapeLayer
            {
                Frame = view.Bounds,
                Path = maskPath.CGPath,
                LineWidth = lineWidth,
                StrokeColor = color ?? UIColor.FromRGB(61, 71, 82).CGColor,
                FillColor = UIColor.Clear.CGColor,
                Name = name
            };

            var maskLayer = new CAShapeLayer
            {
                Frame = view.Bounds,
                Path = maskPath.CGPath
            };
            borderLayer.Mask = maskLayer;

            if (view.Layer.Sublayers != null && view.Layer.Sublayers.Any(x => x.Name == name))
            {
                CALayer layer = view.Layer.Sublayers.FirstOrDefault(x => x.Name == name);
                view.Layer.ReplaceSublayer(layer, borderLayer);
            }
            else
            {
                view.Layer.AddSublayer(borderLayer);
            }

            return borderLayer;
        }
        #endregion
    }
}
