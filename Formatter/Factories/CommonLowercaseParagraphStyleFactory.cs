using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;

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
            style.StyleRunProperties!.Append(new FontSize() { Val = (2 * Constants.Font.MainTextFontSize).ToString() });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DefaultFontColor });

            return style;
        }
    }
}
