using NPOI.XWPF.UserModel;

namespace Formatter
{
    public static class BodyElementExtensions
    {
        public static XWPFParagraph? GetFirstPreviousNonEmptyParagraph(this IList<IBodyElement> bodyElements, int index)
        {
            if (bodyElements != null)
            {

                while (index > 0)
                {
                    var paragraph = bodyElements.ElementAt(index) as XWPFParagraph;

                    if (paragraph?.IsEmpty == false)
                    {
                        return paragraph;
                    }

                    index--;
                }
            }

            return null;
        }

        public static XWPFParagraph? GetFirstPreviousParagraph(this IList<IBodyElement> bodyElements, int index)
        {
            if (bodyElements != null)
            {

                while (index > 0)
                {
                    var paragraph = bodyElements.ElementAt(index) as XWPFParagraph;

                    if (paragraph == null)
                    {
                        index--;
                        continue;
                    }

                    return paragraph;
                }
            }

            return null;
        }

        public static XWPFParagraph? GetFirstFollowingParagraph(this IList<IBodyElement> bodyElements, int index)
        {
            if (bodyElements != null)
            {

                while (index > bodyElements.Count)
                {
                    var paragraph = bodyElements.ElementAt(index) as XWPFParagraph;

                    if (paragraph == null)
                    {
                        index++;
                        continue;
                    }

                    return paragraph;
                }
            }

            return null;
        }

        public static XWPFRun GetRun(this XWPFParagraph paragraph)
        {
            return paragraph.Runs.Count == 0 ?
                paragraph.CreateRun() :
                paragraph.Runs.First();
        }
    }
}
