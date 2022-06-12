using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Extensions
{
    public static class OpenXmlElementsExtension
    {
        public static Paragraph? FirstNonEmptyParagraphInParagraphSubsequence(this IEnumerable<OpenXmlElement> elements)
        {
            Func<OpenXmlElement, bool> IsFirstPreviousElementNonEmptyParagraphOrAnotherElement = (OpenXmlElement element) => element switch
            {
                var e when e is Paragraph => !string.IsNullOrWhiteSpace(element.InnerText),
                _ => true
            };

            return elements.FirstOrDefault(e => IsFirstPreviousElementNonEmptyParagraphOrAnotherElement(e)) as Paragraph;
        }
    }
}
