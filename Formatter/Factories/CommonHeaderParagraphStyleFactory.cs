using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;

namespace Formatter.Factories
{
    internal class CommonHeaderParagraphStyleFactory : BaseParagraphStyleFactory
    {
        public CommonHeaderParagraphStyleFactory() : base(Constants.Style.HeaderTextStyleId, Constants.Style.HeaderTextStyleName)
        {
        }

        public override Style Create()
        {
            style.StyleRunProperties!.Append(new FontSize() { Val = (2 * Constants.Font.HeaderTextFontSize).ToString() });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DefaultFontColor });
            style.StyleRunProperties!.Append(new Bold());

            return style;
        }
    }
}
