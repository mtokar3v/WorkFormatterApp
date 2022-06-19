using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
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
            style.StyleRunProperties!.Append(new FontSize() { Val = NotationConverter.ToHpsMeasureFontSize(Constants.Font.MainTextFontSize) });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DefaultFontColor });

            pPr.AppendOrChangeSingleProperty(new Justification() { Val = JustificationValues.Both });
            style.AppendOrChangeSingleProperty(pPr);

            return style;
        }
    }
}
