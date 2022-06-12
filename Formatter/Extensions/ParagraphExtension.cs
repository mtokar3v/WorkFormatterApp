using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Extensions
{
    public static class ParagraphExtension
    {
        public static Run GetOrCreateRun(this Paragraph p)
        {
            if (p.Elements<Run>().Count() == 0)
            {
                p.PrependChild(new Run());
            }

            return p.GetFirstChild<Run>()!;
        }

        public static ParagraphProperties GetOrCreateParagraphProperties(this Paragraph p)
        {
            if (p.Elements<ParagraphProperties>().Count() == 0)
            {
                p.PrependChild(new ParagraphProperties());
            }

            return p.ParagraphProperties!;
        }

        public static ParagraphStyleId GetOrCreateParagraphStyleId(this Paragraph p)
        {
            var pPr = p.GetOrCreateParagraphProperties();

            if(pPr.ParagraphStyleId == null)
            {
                pPr.ParagraphStyleId = new ParagraphStyleId();
            }

            return pPr.ParagraphStyleId;
        }
    }
}
