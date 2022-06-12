﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Formatter;
using Formatter.Builders;
using Formatter.Extensions;
using Formatter.Factories;
using Formatter.FormatterItems;
using System.Text.RegularExpressions;

namespace WorkFormatter.Program
{
    public class Program
    {
        public static void Main()
        {
            var path = Path.Combine(Constants.NeedRemoveToConfig.PathToTestFile, $"simpleTable2.docx");
            var testNumber = new DirectoryInfo(Constants.NeedRemoveToConfig.PathToTestFile).GetFiles().Length - 1;
            var pathForEditedFile = Path.Combine(Constants.NeedRemoveToConfig.PathToTestFile, $"TableTesting_{testNumber}_{Guid.NewGuid()}.docx");

            using var mainDocument = WordprocessingDocument.Open(path, true);
            using var document = WordprocessingDocument.Create(pathForEditedFile, WordprocessingDocumentType.Document);
            mainDocument.CopyTo(document);

            var styleDefinitionsPart = document.GetOrCreateStyleDefinitionsPart();
            var styles = styleDefinitionsPart.GetOrCreateStyles();
            styles.Append(new CommonLowercaseParagraphStyleFactory().Create());
            styles.Append(new DangerParagraphStyleFactory().Create());

            var tf = new TableFormatter(document!.MainDocumentPart!.Document.Body!);
            tf.Execute();
        }
    }
} 