using Formatter.FormatterItems.Enums;
using Universal.Common.Formats.Afm;

namespace Formatter.Utils;
public static class PageItemDetailsHelper
{
    private static readonly string resourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    private static AdobeFontMetrics _timeNewRomanBoldAfm = AdobeFontMetrics.FromFile(Path.Combine(resourcePath, @"Resources/Times-New-Roman-Bold.afm"));
    private static AdobeFontMetrics _timeNewRomanRegularAfm = AdobeFontMetrics.FromFile(Path.Combine(resourcePath, "Resources/Times-New-Roman-Regular.afm"));

    public static int GetSymbolWidth(char symbol, int fontSize, FontName fontName)
        => fontName switch
        {
            FontName.TimesNewRomanBold => decimal.ToInt32(fn(symbol, _timeNewRomanBoldAfm) * fontSize),
            FontName.TimesNewRomanRegular => decimal.ToInt32(fn(symbol, _timeNewRomanRegularAfm) * fontSize),
            _ => throw new ArgumentOutOfRangeException(nameof(fontName))
        };


    private static Func<char, AdobeFontMetrics, decimal> fn = (c, afm) =>
    {
        if (afm == null) throw new ArgumentNullException(nameof(afm), $"AFM is null in {nameof(fn)}");
        if (afm.CharacterMetrics.Count == 0) throw new Exception("AFM does not have any value");

        var metric = AsciiHelper.IsExpandedAscii(c) ?
            afm.CharacterMetrics.First(m => m.Name == AsciiHelper.GetAsciiName(c)) :
            afm.CharacterMetrics.FirstOrDefault(m => m.Code == c) ??
            afm.CharacterMetrics.First(m => m.Code == '0'); // defauld value

        return metric.WidthX!.Value;
    };
}

