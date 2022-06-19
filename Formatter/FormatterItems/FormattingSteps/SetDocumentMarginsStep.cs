using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
using Formatter.Utils;
namespace Formatter.FormatterItems.FormattingSteps;

public class SetDocumentMarginsStep : BaseFormatterStep
{
    public SetDocumentMarginsStep(Body body) : base(body) { }

    public override void Execute()
    {
        var sectionProperties = _body.GetOrCreateSectionProperties();

        var pageMargin = new PageMargin()
        {
            Left = NotationConverter.ToUInt32Value(Constants.Margin.Left),
            Right = NotationConverter.ToUInt32Value(Constants.Margin.Right),
            Top = NotationConverter.ToInt32Value(Constants.Margin.Top),
            Bottom = NotationConverter.ToInt32Value(Constants.Margin.Bottom),
            Footer = NotationConverter.ToUInt32Value(0),
            Header = NotationConverter.ToUInt32Value(0),
            Gutter = NotationConverter.ToUInt32Value(0)
        };

        sectionProperties.AppendOrChangeSingleProperty(pageMargin);
    }
}

