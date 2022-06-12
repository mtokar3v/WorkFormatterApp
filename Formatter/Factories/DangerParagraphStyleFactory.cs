using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;

namespace Formatter.Factories
{
    internal class DangerParagraphStyleFactory : ParagraphStyleFactory
    {
        public DangerParagraphStyleFactory() : base(Constants.Style.DanderTextStyleId, Constants.Style.DangerTextStyleName) { }
        public override Style Create()
        {
            style.StyleRunProperties!.Append(new FontSize() { Val = (2 * Constants.Font.MainTextFontSize).ToString() });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DangerFontColor });
            style.StyleRunProperties!.Append(new Italic());

            return style;
        }
    }
}
