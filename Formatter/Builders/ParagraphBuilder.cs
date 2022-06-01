using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;

namespace Formatter.Builders
{
    public class ParagraphBuilder
    {
        private readonly XWPFParagraph _paragraph;

        public ParagraphBuilder(XWPFDocument document)
        {
            var ct_p = new CT_P();
            _paragraph = new XWPFParagraph(ct_p, document);
        }

        public XWPFParagraph Build() => _paragraph;

        public ParagraphBuilder WithCommonTextSettings(string text)
        {
            WithDefaultSettings(text);

            var tmpRun = _paragraph.GetRun();
            tmpRun.FontSize = Constants.Font.TextFontSize;

            return this;
        }

        public ParagraphBuilder WithHeaderTextSettings(string text)
        {
            WithDefaultSettings(text);

            var tmpRun = _paragraph.GetRun();
            tmpRun.FontSize = Constants.Font.HeaderFontSize;

            return this;
        }

        public ParagraphBuilder WithDangerFontColor()
        {
            var tmpRun = _paragraph.GetRun();
            tmpRun.SetColor(Constants.Font.DangerFontColor);

            return this;
        }

        private ParagraphBuilder WithDefaultSettings(string text)
        {
            _paragraph.Alignment = ParagraphAlignment.LEFT;

            var tmpRun = _paragraph.GetRun();
            tmpRun.SetText(text);
            tmpRun.FontSize = Constants.Font.HeaderFontSize;
            tmpRun.SetColor(Constants.Font.FontColor);
            tmpRun.FontFamily = Constants.Font.DefaultFont;

            return this;
        }
    }
}
