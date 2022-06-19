using DocumentFormat.OpenXml.Packaging;
namespace Formatter.Extensions;

public static class WordprocessingDocumentExtension
{
    public static void CopyTo(this WordprocessingDocument mainDocument, WordprocessingDocument resultDocument)
    {
        if (mainDocument == null) throw new ArgumentNullException(nameof(mainDocument));
        if (resultDocument == null) throw new ArgumentNullException(nameof(resultDocument));

        foreach (var part in mainDocument.Parts)
        {
            if (part == null)
                continue;

            resultDocument.AddPart(part.OpenXmlPart, part.RelationshipId);
        }
    }

    public static MainDocumentPart GetOrCreateMainDocumentPart(this WordprocessingDocument document)
    {
        if (document == null) throw new ArgumentNullException(nameof(document));

        if (document.MainDocumentPart == null)
        {
            document.AddMainDocumentPart();
        }

        return document.MainDocumentPart!;
    }

    public static StyleDefinitionsPart GetOrCreateStyleDefinitionsPart(this WordprocessingDocument document)
    {
        if (document == null) throw new ArgumentNullException(nameof(document));

        var mainPart = document.GetOrCreateMainDocumentPart();

        if (mainPart.StyleDefinitionsPart == null)
        {
            document.AddNewPart<StyleDefinitionsPart>();
        }

        return mainPart.StyleDefinitionsPart!;
    }
}

