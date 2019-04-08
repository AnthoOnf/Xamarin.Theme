using CoreAnimation;
using UIKit;
using Xamarin.Theme.Core;

namespace Xamarin.Theme.iOS.Sources.Extensions
{
    public static class XPlatStyleExtensions
    {
        #region FONT
        public static void ApplyFont(this UILabel @this, string font, float? size = null)
        {
            if (@this == null || font == null)
                return;
            @this.ApplyFont(new XPlatFont(font, size));
        }

        public static void ApplyFont(this UILabel @this, XPlatFont font)
        {
            if (@this == null || font == null)
                return;
            @this.Font = font.ToNative();
        }

        public static void ApplyFont(this UIButton @this, string font, float? size = null)
        {
            if (@this == null || font == null)
                return;
            @this.ApplyFont(new XPlatFont(font, size));
        }

        public static void ApplyFont(this UIButton @this, XPlatFont font)
        {
            if (@this == null || font == null)
                return;
            @this.Font = font.ToNative();
        }

        public static void ApplyFont(this UIStringAttributes @this, XPlatFont font)
        {
            if (@this == null || font == null)
                return;
            @this.Font = font.ToNative();
        }

        public static void ApplyFont(this UIStringAttributes @this, string font, float? size = null)
        {
            if (@this == null || font == null)
                return;
            @this.ApplyFont(new XPlatFont(font, size));
        }
        #endregion

        #region COLOR
        public static void ApplyBackgroundColor(this UIView @this, XPlatColor color)
        {
            if (@this == null || color == null)
                return;
            @this.BackgroundColor = color.ToNative();
        }

        public static void ApplyBackgroundColor(this UIButton @this, XPlatColor color)
        {
            if (@this == null || color == null)
                return;
            @this.BackgroundColor = color.ToNative();
        }
        #endregion

        #region TEXTALIGN
        public static void ApplyTextAlign(this UILabel @this, XPlatTextAlignType textAlign)
        {
            if (@this == null)
                return;

            switch (textAlign)
            {
                case XPlatTextAlignType.Left:
                    @this.TextAlignment = UITextAlignment.Left;
                    break;
                case XPlatTextAlignType.Right:
                    @this.TextAlignment = UITextAlignment.Right;
                    break;
                case XPlatTextAlignType.Center:
                    @this.TextAlignment = UITextAlignment.Center;
                    break;
                default:
                    @this.TextAlignment = UITextAlignment.Left;
                    break;
            }
        }

        public static void ApplyTextAlign(this UIButton @this, XPlatTextAlignType textAlign)
        {
            if (@this == null)
                return;

            switch (textAlign)
            {
                case XPlatTextAlignType.Left:
                    @this.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                    break;
                case XPlatTextAlignType.Right:
                    @this.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
                    break;
                case XPlatTextAlignType.Center:
                    @this.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                    break;
                default:
                    @this.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                    break;
            }
        }
        #endregion

        #region TEXTCOLOR
        public static void ApplyTextColor(this UILabel @this, XPlatColor color)
        {
            if (@this == null || color == null)
                return;
            @this.TextColor = color.ToNative();
        }

        public static void ApplyTextColor(this UIButton @this, XPlatColor color)
        {
            if (@this == null || color == null)
                return;
            @this.SetTitleColor(color.ToNative(), UIControlState.Normal);
        }
        #endregion

        #region CORNER RADIUS
        public static void ApplyAllCornerRadius(this CALayer @this, XPlatCornerRadius cornerRadius)
        {
            if (@this == null || cornerRadius == null)
                return;

            //if (cornerRadius.AllCorner)
            @this.CornerRadius = cornerRadius.Radius;
        }

        public static void ApplyCornerRadius(this UIView @this, XPlatCornerRadius cornerRadius)
        {
            if (@this == null || cornerRadius == null)
                return;

            @this.ApplyCornerRadius(GetRectCorners(cornerRadius), cornerRadius.Radius);
        }

        public static void ApplyCornerRadius(this UIButton @this, XPlatCornerRadius cornerRadius)
        {
            if (@this == null || cornerRadius == null)
                return;

            @this.ApplyCornerRadius(GetRectCorners(cornerRadius), cornerRadius.Radius);
        }

        static UIRectCorner GetRectCorners(XPlatCornerRadius cornerRadius)
        {
            long cornersFlags = 0;

            if (cornerRadius.BottomLeft)
                cornersFlags |= (long)UIRectCorner.BottomLeft;
            if (cornerRadius.BottomRight)
                cornersFlags |= (long)UIRectCorner.BottomRight;
            if (cornerRadius.TopLeft)
                cornersFlags |= (long)UIRectCorner.TopLeft;
            if (cornerRadius.TopRight)
                cornersFlags |= (long)UIRectCorner.TopRight;

            if (cornersFlags <= 0 || cornerRadius.AllCorner)
                cornersFlags = (long)UIRectCorner.AllCorners;

            return (UIRectCorner)cornersFlags;
        }
        #endregion

        #region BORDER COLOR
        public static void ApplyBorderColor(this UIView @this, XPlatColor color, int size = 1, XPlatCornerRadius cornerRadius = null)
        {
            if (@this == null || color == null)
                return;

            if (cornerRadius == null)
                cornerRadius = new XPlatCornerRadius(5);

            @this.ApplyBorder(GetRectCorners(cornerRadius), cornerRadius?.Radius ?? 0, color.ToNative(), (float)size);
        }
        #endregion

        #region STYLE
        public static void ApplyStyle(this UIView @this, XPlatViewStyle style)
        {
            if (@this == null || style == null)
                return;

            @this.ApplyBackgroundColor(style.BackgroundColor);
            @this.ApplyCornerRadius(style.CornerRadius);
            @this.ApplyBorderColor(style.BorderColor, cornerRadius: style.CornerRadius);
        }

        public static void ApplyStyle(this UILabel @this, XPlatLabelStyle style)
        {
            if (@this == null || style == null)
                return;

            @this.ApplyFont(style.Font);
            @this.ApplyTextColor(style.Color);
            @this.ApplyTextAlign(style.TextAlign);
        }

        public static void ApplyStyle(this UIButton @this, XPlatLabelStyle style)
        {
            if (@this == null || style == null)
                return;

            @this.ApplyFont(style.Font);
            @this.ApplyTextColor(style.Color);
            @this.ApplyTextAlign(style.TextAlign);

        }

        public static void ApplyStyle(this
                                      UIButton
                                      @this, XPlatButtonStyle buttonStyle)
        {
            if (@this == null || buttonStyle == null)
                return;

            @this.ApplyStyle((XPlatLabelStyle)buttonStyle);

            @this.ApplyBackgroundColor(buttonStyle.BackgroundColor);
            //@this.ApplyBackgroundImage(buttonStyle.BackgroundImage);
            @this.ApplyCornerRadius(buttonStyle.CornerRadius);
            @this.ApplyBorderColor(buttonStyle.BorderColor, cornerRadius: buttonStyle.CornerRadius);
        }
        #endregion
    }
}
