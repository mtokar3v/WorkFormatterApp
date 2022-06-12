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
            "Табл.",
            "Table"
        };

        public TableFormatter(Body body) : base(body) { }

        //Need to add title when table going to the next page
        public override void Execute()
        {
            //Need to skip first page (or not)
            var tables = _body.Elements<Table>().ToList(); 

            foreach (var table in tables)
            {
                var tableHeader = GetPreviousNonEmptyParagraphInParagraphSubsequence(table);

                if (IsHeader(tableHeader?.InnerText))
                {
                    if (!IsCorrectHeaderSpelling(tableHeader?.InnerText))
                    {
                        CorrectHeaderSpelling(tableHeader!, tables.IndexOf(table) + 1);
                    }
                }
                else
                {
                    AddTableHeader(table, tables.IndexOf(table) + 1);
                }
            }
        }

        private void AddTableHeader(OpenXmlElement table, int tableNumber)
        {
            var tableHeaderText = $"Таблица {tableNumber} - Название";

            var tableHeaderParagraph = new ParagraphBuilder(tableHeaderText)
                .WithStyle(Constants.Style.MainTextStyleId)
                .Build();

            _body.InsertBefore(tableHeaderParagraph, table);
        }

        private void CorrectHeaderSpelling(Paragraph p, int tableNumber)
        {
            var text = p.InnerText;
            if (string.IsNullOrEmpty(text))
                return;

            var pattern = @$"[^({string.Join('|', _tableHeaders)})][а-яёА-ЯЁ0-9 ,.;()\[\]]+[^.;,]";
            var matches = Regex.Matches(text, pattern);

            var (tableName, isCorrect) = matches.Count() switch 
            {
                var c when c == 1 || c == 2 => (matches.ElementAt(c - 1).Value, true),
                _ => ("Название", false)
            };

            var tableHeaderText = $"Таблица {tableNumber} - {tableName}";
            p.GetFirstChild<Run>()!.GetFirstChild<Text>()!.Text = tableHeaderText;

            if(!isCorrect)
            {
                p.GetOrCreateParagraphStyleId().Val = Constants.Style.DanderTextStyleId;
            }
        }

        private bool IsCorrectHeaderSpelling(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            var pattern = @"Таблица\s\d+\s-\s\w+[^.;,]";
            return Regex.IsMatch(text, pattern);
        }

        private bool IsHeader(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text
                .Split()
                .ToList()
                .Any(s => _tableHeaders.Contains(s, StringComparer.OrdinalIgnoreCase));
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
