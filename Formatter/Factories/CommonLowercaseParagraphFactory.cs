using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;

namespace Formatter.Factories
{
    public class CommonLowercaseParagraphFactory : ParagraphStyleFactory
    {
        public CommonLowercaseParagraphFactory() : base(Constants.Style.MainTextStyleId, Constants.Style.MainTextStyleName)
        {
        }

        public override Style Create()
        {
            //Need to add text position : justify , line and paragraph spacing 
            return new Style
            {
                Type = StyleValues.Paragraph,
                StyleId = _styleId,
                CustomStyle = true,
                Default = false,
                StyleName = new StyleName { Val = _styleName },
                StyleRunProperties = new StyleRunProperties()
                {
                    FontSize = new FontSize() { Val = ( 2 * Constants.Font.MainTextFontSize).ToString() },
                    RunFonts = new RunFonts() { Ascii = Constants.Font.DefaultFont },
                    Color = new Color() { Val = Constants.Font.DefaultFontColor },
                    Position = new Position() { }
                }
            };
        }
    }
}
