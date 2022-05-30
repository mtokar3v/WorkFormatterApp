using NPOI.XWPF.UserModel;

namespace Formatter
{
    public static class BodyElementExtensions
    {
        public static string? GetParagraphText(this IBodyElement element)
        {
            if (element == null)
                return null;

            return element
                .Body?
                .Paragraphs?
                .ElementAtOrDefault(0)?
                .Runs?
                .ElementAtOrDefault(0)?
                .Text ?? null;
        }

        public static IBodyElement? GetFirstPreviousNonEmptyParagraph(this IList<IBodyElement> bodyElements, int index)
        {
            if (bodyElements == null)
                return null;

            return bodyElements
                .Take(index + 1)
                .Reverse()
                .FirstOrDefault(e => !string.IsNullOrEmpty(e.GetParagraphText()));
        }
    }
}
