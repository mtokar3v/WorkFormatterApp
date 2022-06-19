using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
namespace Formatter.FormatterItems.FormattingSteps;

public class SetFooterStep : BaseFormatterStep
{
    public SetFooterStep(Body body) : base(body)
    {
    }

    public override void Execute()
    {
        var sectionProperties = _body.GetOrCreateSectionProperties();

        var pPr = new ParagraphProperties();
        pPr.Append(new ParagraphStyleId() { Val = Constants.Style.CommonCenterTextStyleId });

        var p = new Paragraph();
        p.Append(pPr);
        p.Append(new Run(new SimpleField() { Instruction = "PAGE" }));

        var footer = new Footer(p);

        sectionProperties.AppendOrChangeSingleProperty(footer);
    }
}

