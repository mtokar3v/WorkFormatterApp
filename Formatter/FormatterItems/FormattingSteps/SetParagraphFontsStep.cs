using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
using Formatter.Utils;

namespace Formatter.FormatterItems.FormattingSteps;

public class SetParagraphFontsStep : BaseFormatterStep
{
    public SetParagraphFontsStep(Body body) : base(body) { }
    public override void Execute()
    {
        Action<Paragraph> formatParagraph = (p) =>
        {
            var paragraphStyleId = p.GetOrCreateParagraphStyleId();

            if (TextElementHelper.IsHeader(p.InnerText))
            {
                paragraphStyleId.Val = Constants.Style.HeaderTextStyleId;
            }
            else
            {
                paragraphStyleId.Val = Constants.Style.CommonBothTextStyleId;
            }
        };

        _body.Elements<Paragraph>()
            .ToList()
            .ForEach(p => formatParagraph(p));

        _body.Elements<Table>()
            .ToList()
            .ForEach(t => t.Elements<TableRow>()
            .ToList()
            .ForEach(tr => tr.Elements<TableCell>()
            .ToList()
            .ForEach(tc => tc.Elements<Paragraph>()
            .ToList()
            .ForEach(p => formatParagraph(p)))));
    }
}
