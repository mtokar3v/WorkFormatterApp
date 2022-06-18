using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;
using Formatter.Utils;

namespace Formatter.Factories
{
    internal class CommonHeaderParagraphStyleFactory : BaseParagraphStyleFactory
    {
        public CommonHeaderParagraphStyleFactory() : base(Constants.Style.HeaderTextStyleId, Constants.Style.HeaderTextStyleName)
        {
        }

        public override Style Create()
        {
            style.StyleRunProperties!.Append(new FontSize() { Val = NotationConverter.ToHpsMeasureFontSize(Constants.Font.HeaderTextFontSize) });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DefaultFontColor });
            style.StyleRunProperties!.Append(new Bold());

            return style;
        }
    }
}
