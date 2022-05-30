using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;

namespace Formatter.Factories.BodyElementFactory
{
    internal class ParagraphFactory : Formatter.BodyElementFactory
    {
        private readonly string _text;

        public ParagraphFactory(string text, XWPFDocument document) : base(document)
        {
            _text = text;
        }

        public override IBodyElement GetBody()
        {
            var ct_p = new CT_P();
            var paragraph = new XWPFParagraph(ct_p, _document);
            paragraph.Alignment = ParagraphAlignment.LEFT;

            var tmpRun = paragraph.CreateRun();
            tmpRun.SetText(_text);
            tmpRun.FontSize = Constants.Font.TextFontSize;
            tmpRun.SetColor(Constants.Font.FontColor);

            return paragraph;
        }
    }
}
