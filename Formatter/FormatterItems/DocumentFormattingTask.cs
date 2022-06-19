using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.FormatterItems.Enums;
using Formatter.FormatterItems.FormattingSteps;

namespace Formatter.FormatterItems;
public class DocumentFormattingTask
{
    private readonly Body _body;
    private readonly List<BaseFormatterStep> _formattingSteps = new List<BaseFormatterStep>();
    public DocumentFormattingTask(Body body)
    {
        _body = body;
    }

    public FormattingTaskStatus Execute()
    {
        SetFormattingSteps();

        try
        {
            _formattingSteps.ForEach(s => s.Execute());

            return FormattingTaskStatus.Success;
        }
        catch(Exception ex)
        {
            //To do: Logging
            Console.WriteLine(ex.Message + '\n' + ex.StackTrace);
            return FormattingTaskStatus.Fail;
        }
    }

    private void SetFormattingSteps()
    {
        //  Preparation
        _formattingSteps.Add(new DeleteEmptyParagraphsStep(_body));

        //  No matter the order 
        _formattingSteps.Add(new SetDocumentMarginsStep(_body));
        _formattingSteps.Add(new SetFooterStep(_body));

        //  General haning
        _formattingSteps.Add(new FormatTableHeadersStep(_body));

        //  After all handing
        _formattingSteps.Add(new SetParagraphFontsStep(_body));
    }
}
