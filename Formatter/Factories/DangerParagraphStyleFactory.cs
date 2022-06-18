using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;
using Formatter.Utils;

namespace Formatter.Factories
{
    internal class DangerParagraphStyleFactory : BaseParagraphStyleFactory
    {
        public DangerParagraphStyleFactory() : base(Constants.Style.DanderTextStyleId, Constants.Style.DangerTextStyleName) { }
        public override Style Create()
        {
            style.StyleRunProperties!.Append(new FontSize() { Val = NotationConverter.ToHpsMeasureFontSize(Constants.Font.MainTextFontSize) });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DangerFontColor });
            style.StyleRunProperties!.Append(new Italic());

            return style;
        }
    }
}
