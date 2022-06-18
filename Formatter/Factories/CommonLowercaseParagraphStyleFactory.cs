using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;
using Formatter.Utils;

namespace Formatter.Factories
{
    public class CommonLowercaseParagraphStyleFactory : BaseParagraphStyleFactory
    {
        public CommonLowercaseParagraphStyleFactory() : base(Constants.Style.CommonTextStyleId, Constants.Style.CommonTextStyleName)
        {
        }

        public override Style Create()
        {
            //Need to add text position : justify , line and paragraph spacing 
            style.StyleRunProperties!.Append(new FontSize() { Val = NotationConverter.ToHpsMeasureFontSize(Constants.Font.MainTextFontSize) });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DefaultFontColor });

            return style;
        }
    }
}
