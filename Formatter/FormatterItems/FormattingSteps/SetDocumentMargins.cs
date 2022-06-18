using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
using Formatter.Utils;

namespace Formatter.FormatterItems.FormattingSteps;

public class SetDocumentMargins : BaseFormatter
{
    public SetDocumentMargins(Body body) : base(body) { }

    public override void Execute()
    {
        var sectionProperties = _body.GetOrCreateSectionProperties();

        sectionProperties.Elements<PageMargin>().ToList()
           .ForEach(p =>
           {
               p.Left = NotationConverter.ToUInt32Value(Constants.Margin.Left);
               p.Right = NotationConverter.ToUInt32Value(Constants.Margin.Right);
               p.Top = NotationConverter.ToInt32Value(Constants.Margin.Top);
               p.Bottom = NotationConverter.ToInt32Value(Constants.Margin.Bottom);
               p.Footer = NotationConverter.ToUInt32Value(0);
               p.Header = NotationConverter.ToUInt32Value(0);
               p.Gutter = NotationConverter.ToUInt32Value(0);
           });
    }
}

