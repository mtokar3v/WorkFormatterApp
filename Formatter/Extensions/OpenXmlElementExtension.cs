using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Extensions
{
    public static class OpenXmlElementExtension
    {
        public static void AppendOrChangeSingleProperty<T>(this OpenXmlElement element, T property) where T: OpenXmlElement
        {
            if (property == null)
                throw new NullReferenceException(nameof(property));

            if (element.Elements<T>().Count() > 1)
                throw new Exception("The number of suitable propetry is more than expected");

            var oldProp = element.Elements<T>().FirstOrDefault();

            if (oldProp != null)
            {
                element.RemoveChild(oldProp);
            }

            element.Append(property);
        }
    }
}
