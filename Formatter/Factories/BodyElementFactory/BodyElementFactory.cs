using NPOI.XWPF.UserModel;

namespace Formatter
{
    public abstract class BodyElementFactory
    {
        protected readonly XWPFDocument _document;
        public BodyElementFactory(XWPFDocument document)
        {
            _document = document;
        }

        public abstract IBodyElement GetBody();
    }
}
