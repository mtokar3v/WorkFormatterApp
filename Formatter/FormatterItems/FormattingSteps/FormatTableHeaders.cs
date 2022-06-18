using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Builders;
using Formatter.Extensions;
using Formatter.Utils;
using System.Text.RegularExpressions;

namespace Formatter.FormatterItems
{
    public class FormatTableHeaders : BaseFormatter
    {
        private int _tableTotalCount = 0;

        public FormatTableHeaders(Body body) : base(body) { }

        //Need to add title when table going to the next page
        public override void Execute()
        {
            //Need to skip first page (or not)
            var tables = _body.Elements<Table>().ToList(); 

            foreach (var table in tables)
            {
                _tableTotalCount++;
                var tableHeader = GetPreviousNonEmptyParagraphInParagraphSubsequence(table);

                if (TextTypeChecker.IsTableHeader(tableHeader?.InnerText))
                {
                    if (!IsCorrectHeaderSpelling(tableHeader?.InnerText))
                    {
                        CorrectHeaderSpelling(tableHeader!);
                    }
                }
                else
                {
                    AddTableHeader(table);
                }
            }
        }

        private void AddTableHeader(OpenXmlElement table)
        {
            var tableHeaderText = $"Таблица {_tableTotalCount} - Название";

            var tableHeaderParagraph = new ParagraphBuilder(tableHeaderText)
                .WithStyle(Constants.Style.CommonTextStyleId)
                .Build();

            _body.InsertBefore(tableHeaderParagraph, table);
        }

        private void CorrectHeaderSpelling(Paragraph p)
        {
            var text = p.InnerText;
            if (string.IsNullOrEmpty(text))
                return;

            var tableName = TextTypeChecker.GetTableName(text)
                                ?.ToLower()
                                .Trim(Constants.Text.SeparateSymbols)
                                .FirstCharToUpper();

            var tableHeaderText = $"Таблица {_tableTotalCount} - {tableName ?? "Название"}";

            p.RemoveAllChildren();
            p.GetOrCreateRun().GetOrCreateText().Text = tableHeaderText;

            if (tableName == null)
            {
                p.GetOrCreateParagraphStyleId().Val = Constants.Style.DanderTextStyleId;
            }
        }

        private bool IsCorrectHeaderSpelling(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            var pattern = @$"Таблица\s{_tableTotalCount}\s-\s\w+[^{string.Concat(Constants.Text.EndingSymbols)}]";
            return Regex.IsMatch(text, pattern);
        }

        private Paragraph? GetPreviousNonEmptyParagraphInParagraphSubsequence(OpenXmlElement element)
        {
            var curElementIndex = _body
                .Elements()
                .ToList()
                .IndexOf(element);

            return _body.Elements()
                .Take(curElementIndex)
                .Reverse()
                .FirstNonEmptyParagraphInParagraphSubsequence();
        }
    }
}
