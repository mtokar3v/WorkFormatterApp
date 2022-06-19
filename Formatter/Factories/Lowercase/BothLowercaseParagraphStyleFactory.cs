using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
namespace Formatter.Factories.Lowercase;

public class BothLowercaseParagraphStyleFactory : LowercaseParagraphStyleFactory
{
    public BothLowercaseParagraphStyleFactory() : base(Constants.Style.CommonBothTextStyleId, Constants.Style.CommonBothTextStyleName)
    {
    }

    public override Style Create()
    {
        var style = base.Create();

        pPr.AppendOrChangeSingleProperty(new Justification() { Val = JustificationValues.Both });
        style.AppendOrChangeSingleProperty(pPr);

        return style;
    }
}

