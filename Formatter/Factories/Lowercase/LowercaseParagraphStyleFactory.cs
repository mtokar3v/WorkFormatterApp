using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Factory;
using Formatter.Utils;

namespace Formatter.Factories.Lowercase
{
    public abstract class LowercaseParagraphStyleFactory : BaseParagraphStyleFactory
    {
        public LowercaseParagraphStyleFactory(string styleId, string styleName) : base(styleId, styleName)
        {
        }

        public override Style Create()
        {
            style.StyleRunProperties!.Append(new FontSize() { Val = NotationConverter.ToHpsMeasureFontSize(Constants.Font.MainTextFontSize) });
            style.StyleRunProperties!.Append(new Color() { Val = Constants.Font.DefaultFontColor });
            return style;
        }
    }
}
