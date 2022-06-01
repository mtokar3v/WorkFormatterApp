using Formatter;
using Formatter.Builders;
using Formatter.Extensions;
using Formatter.FormatItems;
using NPOI.XWPF.UserModel;

namespace WorkFormatter.Program
{
    public class Program
    {
        public static void Main()
        {
            var path = Path.Combine(Constants.NeedRemoveToConfig.PathToTestFile, "simpleTable.docx");
            var file = File.OpenRead(path);

            var testNumber = new DirectoryInfo(Constants.NeedRemoveToConfig.PathToTestFile).GetFiles().Length - 1;

            var pathForEditedFile = Path.Combine(Constants.NeedRemoveToConfig.PathToTestFile, $"TableTesting_{testNumber}_{Guid.NewGuid()}.docx");
            using var fs = new FileStream(pathForEditedFile, FileMode.CreateNew, FileAccess.Write);

            var document = new XWPFDocument(file);

            var formattingTasks = new List<BaseFormatter>
            {
                new TableFormatter(document)
            };

            foreach (var task in formattingTasks)
            {
                task.ExecuteFormatting();
            }

            document.Write(fs);
        }
    }
}