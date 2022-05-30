using NPOI.XWPF.UserModel;

namespace Formatter.FormatItems
{
    internal abstract class BaseFormatter
    {
        protected int _changes = 0;

        protected readonly XWPFDocument _document;
        protected readonly IList<IBodyElement> _elements;
        public BaseFormatter(XWPFDocument document)
        {
            _document = document;
            _elements = document.BodyElements;
        }

        public abstract int ExecuteFormatting();
    }
}
