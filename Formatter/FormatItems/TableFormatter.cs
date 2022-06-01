using Formatter.Builders;
using Formatter.Extensions;
using NPOI.XWPF.UserModel;

namespace Formatter.FormatItems
{
    internal class TableFormatter : BaseFormatter
    {
        private int _totalTableCounter = 0;

        private readonly HashSet<string> _tableHeaders = new HashSet<string>
        {
            "Таблица",
            "Табл.",
            "Table"
        };

        public TableFormatter(XWPFDocument document) : base(document)
        {
        }

        public override int ExecuteFormatting()
        {
            for (var i = 0; i < _elements.Count; i++)
            {
                var table = _elements.ElementAt(i) as XWPFTable;

                if (table == null)
                    continue;

                var tableHeader = _elements
                    .GetFirstPreviousNonEmptyParagraph(i)?
                    .ParagraphText;

                //TO DO: Remove empty fields above of Table

                if (string.IsNullOrEmpty(tableHeader) || !IsHeader(tableHeader))
                {
                    AddTableHeader(table, i);
                }

            }

            return _changes;
        }

        private bool IsHeader(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text
                .Split()
                .ToList()
                .Any(s => _tableHeaders.Contains(s));
        }

        private void AddTableHeader(XWPFTable table, int elementIndex)
        {
            var tableHeaderText = $"Таблица {++_totalTableCounter} - Название";

            var tableHeaderParagraph = new ParagraphBuilder(_document)
                .WithCommonTextSettings(tableHeaderText)
                .WithDangerFontColor()
                .Build();
            //  <summary>
            //  Its better that was be, but insertParagraph works
            //  incorrect with mix of tables and paragraphs
            //  </summary>
            var tableHeaderIndex = elementIndex - 1 > 0 ? elementIndex - 1 : 0;
            _document.InsertParagraph(tableHeaderParagraph, tableHeaderIndex);
            _changes++;
        }
    }
}
