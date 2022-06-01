using NPOI.XWPF.UserModel;

namespace Formatter.Extensions
{
    public static class DocumentExtensions
    {
        public static void InsertParagraph(this XWPFDocument document, XWPFParagraph paragraph, int insertElementIndex)
        {
            if (paragraph == null) throw new NullReferenceException(nameof(paragraph));

            if(insertElementIndex < 0)
            {
                var newParagraph = document.CreateParagraph();
                newParagraph = paragraph;
                return;
            }

            var followingParagraphs = document.Paragraphs
                .Skip(insertElementIndex)
                .ToList();

            var paragraphNumber = followingParagraphs.Count();
            var paragraphPosition = document.Paragraphs.IndexOf(followingParagraphs.First());
            for (var i = 0; i < paragraphNumber; i++)
            {
                var p = followingParagraphs.ElementAt(i);

                if (i == paragraphNumber - 1)
                {
                    var newParagraph = document.CreateParagraph();
                    newParagraph = p;
                    break;
                }

                document.SetParagraph(p, ++paragraphPosition);
            }

            var occupiedElement = document.BodyElements.ElementAtOrDefault(insertElementIndex);

            switch(occupiedElement?.ElementType)
            {
                case BodyElementType.PARAGRAPH:
                    {
                        var currentParagraphPosition = document.GetParagraphPos(insertElementIndex);
                        document.SetParagraph(paragraph, currentParagraphPosition);
                        break;
                    }
                case BodyElementType.TABLE:
                    {
                        //  <summary>
                        //  Will be working incorrect when tables will go in a row
                        //  </summary>
                        var p = document.BodyElements.GetFirstPreviousParagraph(insertElementIndex);
                        var index = document.BodyElements.IndexOf(p);
                        document.InsertParagraph(paragraph, index);
                        break;
                    }
                case null:
                    {
                        document.InsertParagraph(paragraph, -1);
                        break;
                    }
                default: throw new IndexOutOfRangeException(nameof(occupiedElement.ElementType));
            }
        }
    }
}
