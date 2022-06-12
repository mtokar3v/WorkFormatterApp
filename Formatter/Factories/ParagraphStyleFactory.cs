﻿using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Factory
{
    public abstract class ParagraphStyleFactory
    {
        protected readonly Style style;

        public ParagraphStyleFactory(string styleId, string styleName)
        {
            style = new Style
            {
                Type = StyleValues.Paragraph,
                StyleId = styleId,
                CustomStyle = true,
                Default = false,
                StyleName = new StyleName { Val = styleName },
                StyleRunProperties = new StyleRunProperties
                {
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
