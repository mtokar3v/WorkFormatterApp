using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.FormatterItems
{
    public abstract class BaseFormatter
    {
        protected readonly Body _body;

        public BaseFormatter(Body body)
        {
            _body = body;
        }

        public abstract void Execute();
    }
}
