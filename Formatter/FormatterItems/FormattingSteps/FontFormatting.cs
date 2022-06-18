using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
using Formatter.Utils;

namespace Formatter.FormatterItems.FormattingSteps;

public class FontFormatting : BaseFormatter
{
    public FontFormatting(Body body) : base(body) { }
    public override void Execute()
    {
        Action<Paragraph> formatParagraph = (p) =>
        {
            var paragraphStyleId = p.GetOrCreateParagraphStyleId();

            if (TextTypeChecker.IsHeader(p.InnerText))
            {
                paragraphStyleId.Val = Constants.Style.HeaderTextStyleId;
            }
            else
            {
                paragraphStyleId.Val = Constants.Style.CommonTextStyleId;
            }
        };

        _body.Elements<Paragraph>()
            .ToList()
            .ForEach(p => formatParagraph(p));

        //Need to add table text handing
    }
}
