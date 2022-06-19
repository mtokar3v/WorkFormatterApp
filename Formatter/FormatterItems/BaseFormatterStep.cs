using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.FormatterItems
{
    public abstract class BaseFormatterStep
    {
        protected readonly Body _body;

        public BaseFormatterStep(Body body)
        {
            _body = body;
        }

        public abstract void Execute();
    }
}
