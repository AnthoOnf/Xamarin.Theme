
# Xamarin.Theme

An easy way to implement style cross platform.

Minimum requirement:

![iOSVersion](https://img.shields.io/badge/iOS-11-green.svg)


## Install



## Usage

****Define your fonts file****

1. First you have to import your favorite fonts to your __iOS/Android__ project.

    See here : https://www.c-sharpcorner.com/blogs/xamarin-ios-custom-fonts

2. Create a new file in your __CORE PROJECT__.

3. Create a property to define the fontname that you will use

```csharp
public class TFonts
{
    private string _fontName => "Avenir";
}
```

4. Then implement an enum that correspond to the different style of your font.

    For example, the ___Avenir___ font has different style like *Book, Black, Heavy...*  (for this you have to import the different font style in your app, see the first step)

```csharp
public class TFonts
{
    private enum FontStyles
    {
        Book,
        Black,
        Heavy,
        //And all others styles you want
    }
}
```

5. Then implement the method where you will get the font name to create the font style.

```csharp
public class TFonts
{
    private XPlatFont GetFont(FontStyles style, int size)
    {
        string styleName = Enum.GetName(typeof(FontStyles), style);
        string fullFontName = GetFontName(styleName);

        return new XPlatFont(fullFontName, (float)size);
    }

    private string GetFontName(string styleName)
    {
        return $"{_fontName}-{styleName}";
    }
}
```

6. Now define the different style of your font like that :

```csharp
public class TFonts
{
    public XPlatFont Avenir_Book_16 => GetFont(FontStyles.Book, 16);

    public XPlatFont Avenir_Heavy_16 => GetFont(FontStyles.Heavy, 16);

    public XPlatFont Avenir_Black_33 => GetFont(FontStyles.Black, 33);
}
```


****Define your colors file****

Create a new file where you will define your colors in your __CORE PROJECT__.

This color will be use in others style like label, button, textfield etc...

```csharp
public class TColors
{
    public XPlatColor Black => new XPlatColor(0, 0, 0);
    
    public XPlatColor White => new XPlatColor(255, 255, 255);
    
    public XPlatColor Clear => new XPlatColor(0, 0, 0, 0);
}
```

****Define your label style file****

Create a new file where you will define your labelstyle in your __CORE PROJECT__.
The label style will be use to stylize UILabel or to create ButtonStyle.

```csharp
public class TLabelStyle
{
    private readonly TFonts _tFonts;

    private readonly TColors _tColors;

    public WStyles(TFonts tfonts, TColors tcolors)
    {
        _tFonts = wfonts;
        _tColors = wcolors;
    }

    public XPLatLabelStyle Title_For_Button => new XPlatLabelStyle(_tColors.Black, _tFonts.Avenir_Book_16);
}
```

****Create your CornerRadius file****

You can define all the corner radius style you need.

So create a new static class.
````csharp
public static class TCornerRadius
{
    public static XPlatCornerRadius AllCorner => new XPlatCornerRadius(5, true, true, true, true);

    public static XPlatCornerRadius BottomCorner => new XPlatCornerRadius(bottomLeft: true, bottomRight: true);
    
    //etc...
}
````

****Define your theme file****

Here you will define all your style that you will use in your app.
You have to create all the other file describe in the previous step.

```csharp
public class TTheme
{
    private readonly TStyles _styles;

    private readonly TColors _colors;

    public TTheme(TStyles styles, TColors colors)
    {
        _styles = styles;
        _colors = colors;
    }
    
    public XPlatButtonStyle Button_Style_One => new XPlatButtonStyle(_styles.Title_For_Button, _colors.White, WCornerRadius.AllCorner);
}
```

## Settings

****XPlatColor****

You can create an XPlatoColor with different way :

From RGBA

````csharp
/// <summary>
/// Initializes a new instance of the XPlatColor class.
/// </summary>
/// <param name="red">Red value must be between 0 and 255</param>
/// <param name="green">Green value must be between 0 and 255</param>
/// <param name="blue">Blue value must be between 0 and 255</param>
/// <param name="alpha0to100">Alpha0to100 value must be between 0 and 100</param>
new XPlatColor(int red, int green, int blue, int alpha0to100 = 100);

/// <summary>
/// Initializes a new instance of the XPlatColor class.
/// </summary>
/// <param name="red">Red value must be between 0 and 255</param>
/// <param name="green">Green value must be between 0 and 255</param>
/// <param name="blue">Blue value must be between 0 and 255</param>
/// <param name="alphaHex">AlphaHex value must be a hexadecimal</param>
new XPlatColor(int red, int green, int blue, byte alphaHex)

/// <summary>
/// Initializes a new instance of the XPlatColor class.
/// </summary>
/// <param name="red">Red value must be a hexadecimal</param>
/// <param name="green">Green value must be a hexadecimal</param>
/// <param name="blue">Blue value must be a hexadecimal</param>
/// <param name="alphaHex">AlphaHex value must be a hexadecimal</param>
new XPlatColor(byte red, byte green, byte blue, byte alphaHex)

/// <summary>
/// Initializes a new instance of the XPlatColor class.
/// </summary>
/// <param name="red0to1">Red value must be between 0 and 1</param>
/// <param name="green0to1">Green value must be between 0 and 1</param>
/// <param name="blue0to1">Blue value must be between 0 and 1</param>
/// <param name="alpha0to1">Alpha value must be between 0 and 1</param>
new XPlatColor(float red0to1, float green0to1, float blue0to1, float alpha0to1)
````
