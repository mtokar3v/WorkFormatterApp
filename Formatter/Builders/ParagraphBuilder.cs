using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;

namespace Formatter.Builders
{
    public class ParagraphBuilder
    {
        private readonly Paragraph _paragraph;

        public ParagraphBuilder(string text)
        {
            _paragraph = new Paragraph(new Run(new Text(text)));
        }

        public Paragraph Build() => _paragraph;

        public ParagraphBuilder WithStyle(string styleId)
        {
            _paragraph.GetOrCreateParagraphStyleId().Val = styleId;

            return this;
        }
    }
}
