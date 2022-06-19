using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Factory
{
    public abstract class BaseParagraphStyleFactory
    {
        protected readonly Style style;
        protected readonly ParagraphProperties pPr;

        public BaseParagraphStyleFactory(string styleId, string styleName)
        {
            pPr = new ParagraphProperties();

            style = new Style
            {
                Type = StyleValues.Paragraph,
                StyleId = styleId,
                CustomStyle = true,
                Default = false,
                StyleName = new StyleName { Val = styleName },
                StyleRunProperties = new StyleRunProperties
                {
                    VerticalTextAlignment = new VerticalTextAlignment() { Val = VerticalPositionValues.Baseline },
                    RunFonts = new RunFonts()
                    {
                        Ascii = Constants.Font.DefaultFont,
                        HighAnsi = Constants.Font.DefaultFont,
                        ComplexScript = Constants.Font.DefaultFont
                    }
                }
            };
        }

        public abstract Style Create();
    }
}
