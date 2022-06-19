using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace Formatter.Extensions;

public static class StyleDefinitionsPartExtension
{
    public static Styles GetOrCreateStyles(this StyleDefinitionsPart stylePart)
    {
        var styles = stylePart.Styles;

        if (styles == null)
        {
            styles = new Styles();
            styles.Save();
        }

        return styles;
    }
}

