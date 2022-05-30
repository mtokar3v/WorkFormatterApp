using Formatter.Factories.BodyElementFactory;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using System.Xml;

namespace Formatter.FormatItems
{
    internal class TableFormatter : BaseFormatter
    {
        private int _tableCounter = 0;

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
                if (_elements.ElementAt(i).ElementType != BodyElementType.TABLE)
                    continue;

                var tableHeader = _elements
                    .GetFirstPreviousNonEmptyParagraph(i)?
                    .GetParagraphText();

                //TO DO: Remove empty fields above of Table

                if(string.IsNullOrEmpty(tableHeader))
                {
                    AddTableHeader(i);
                }

            }

            return _changes;
        }

        private void AddTableHeader(int tableIndex)
        {
            var tableHeaderText = $"Таблица {++_tableCounter} - Название";
            

            var tableHeaderParagraph = new ParagraphFactory(tableHeaderText, _document).GetBody();

            var tableHeaderIndex = tableIndex - 1 /*> 0 ? tableIndex - 1 : 0*/;
            _document.SetParagraph((XWPFParagraph)tableHeaderParagraph, tableHeaderIndex);
        }
    }
}
