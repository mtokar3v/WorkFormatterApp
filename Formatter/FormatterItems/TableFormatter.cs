using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Formatter.Builders;
using Formatter.Extensions;
using System.Text.RegularExpressions;

namespace Formatter.FormatterItems
{
    public class TableFormatter : BaseFormatter
    {
        private readonly HashSet<string> _tableHeaders = new HashSet<string>
        {
            "Таблица",
            "Табл",
            "Table"
        };
        private int _tableTotalCount = 0;

        public TableFormatter(Body body) : base(body) { }

        //Need to add title when table going to the next page
        public override void Execute()
        {
            //Need to skip first page (or not)
            var tables = _body.Elements<Table>().ToList(); 

            foreach (var table in tables)
            {
                _tableTotalCount++;
                var tableHeader = GetPreviousNonEmptyParagraphInParagraphSubsequence(table);

                if (IsHeader(tableHeader?.InnerText))
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
                .WithStyle(Constants.Style.MainTextStyleId)
                .Build();

            _body.InsertBefore(tableHeaderParagraph, table);
        }

        private void CorrectHeaderSpelling(Paragraph p)
        {
            var text = p.InnerText;
            if (string.IsNullOrEmpty(text))
                return;
            
            //To do: update regex to get tableName for effective
            var pattern = @$"[^{string.Join('|', _tableHeaders)}\s+\d+\s+][\w\W]+[^.;,]";
            var matches = Regex.Matches(text, pattern);

            var (tableName, isCorrect) = matches.Count() switch 
            {
                var c when c > 0 => (matches.ElementAt(c - 1).Value, true),
                _ => ("Название", false)
            };

            tableName = tableName
                .ToLower()
                .Trim(' ', '-', '—', '_', ':', ';', '.')
                .FirstCharToUpper();
            var tableHeaderText = $"Таблица {_tableTotalCount} - {tableName}";

            p.RemoveAllChildren();
            p.GetOrCreateRun().GetOrCreateText().Text = tableHeaderText;

            if(!isCorrect)
            {
                p.GetOrCreateParagraphStyleId().Val = Constants.Style.DanderTextStyleId;
            }
        }

        private bool IsCorrectHeaderSpelling(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            var pattern = @$"Таблица\s{_tableTotalCount}\s-\s\w+[^.;,]";
            return Regex.IsMatch(text, pattern);
        }

        private bool IsHeader(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            var pattern = string.Join('|', _tableHeaders);

            return text
                .Split()
                .ToList()
                .Any(s => Regex.Matches(s, pattern, RegexOptions.IgnoreCase).Count() != 0);
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
