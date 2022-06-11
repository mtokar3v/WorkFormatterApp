using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Factory
{
    public abstract class ParagraphStyleFactory
    {
        protected readonly string _styleId;
        protected readonly string _styleName;

        public ParagraphStyleFactory(string styleId, string styleName)
        {
            _styleId = styleId;
            _styleName = styleName;
        }

        public abstract Style Create();
    }
}
