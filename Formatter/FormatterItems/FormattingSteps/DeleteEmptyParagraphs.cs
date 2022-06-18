using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.FormatterItems.FormattingSteps
{
    public class DeleteEmptyParagraphs : BaseFormatter
    {
        public DeleteEmptyParagraphs(Body body) : base(body) { }

        public override void Execute() => _body.Elements<Paragraph>()
                .Where(p => string.IsNullOrWhiteSpace(p.InnerText))
                .ToList()
                .ForEach(p => _body.RemoveChild(p));
    }
}
