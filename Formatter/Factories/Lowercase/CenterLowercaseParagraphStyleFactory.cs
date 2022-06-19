using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Extensions;
namespace Formatter.Factories.Lowercase;

public class CenterLowercaseParagraphStyleFactory : LowercaseParagraphStyleFactory
{
    public CenterLowercaseParagraphStyleFactory() : base(Constants.Style.CommonCenterTextStyleId, Constants.Style.CommonCenterTextStyleName)
    {
    }

    public override Style Create()
    {
        var style = base.Create();

        pPr.AppendOrChangeSingleProperty(new Justification() { Val = JustificationValues.Center });
        style.AppendOrChangeSingleProperty(pPr);

        return style;
    }
}

