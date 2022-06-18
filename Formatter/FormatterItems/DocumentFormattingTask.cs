using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.FormatterItems.Enums;
using Formatter.FormatterItems.FormattingSteps;

namespace Formatter.FormatterItems;
public class DocumentFormattingTask
{
    private readonly Body _body;
    private readonly List<BaseFormatter> _formattingSteps = new List<BaseFormatter>();
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
        _formattingSteps.Add(new TableFormatter(_body));
        _formattingSteps.Add(new FontFormatting(_body));
    }
}
