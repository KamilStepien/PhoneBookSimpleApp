
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebAPI.Models.EFModels;

namespace WebAPI.Models
{
    public class OpenXMLWordService : IWordService
    {
        public void AddTableWithContactToDocument(string filePath, IEnumerable<PhoneContact> phoneContacts)
        {
            using (var document = WordprocessingDocument.Open(filePath, true))
            {

                var doc = document.MainDocumentPart.Document;

                Table table = new Table();

                TableProperties props = new TableProperties(
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    }));

                table.AppendChild<TableProperties>(props);
                var tr = new TableRow();
                foreach (var property in typeof(PhoneContact).GetProperties())
                {
                    var tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(property.Name))));
                    tc.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    tr.Append(tc);
                }

                table.Append(tr);

                foreach (var elm in phoneContacts)
                {

                    tr = new TableRow();
                    foreach (var property in elm.GetType().GetProperties())
                    {
                        var tc = new TableCell();
                        tc.Append(new Paragraph(new Run(new Text(property.GetValue(elm).ToString()))));
                        tc.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                        tr.Append(tc);
                    }

                    table.Append(tr);
                }

                doc.Body.Append(table);
                doc.Save();
            }
        }

        public void CreateDocument(string filePath)
        {
            // Create a document by supplying the filepath. 
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                //Create the document structure and add some text.
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                Body body = mainPart.Document.AppendChild(new Body());
                //Paragraph para = body.AppendChild(new Paragraph());
                //Run run = para.AppendChild(new Run());
                //run.AppendChild(new Text("Create text in body - CreateWordprocessingDocument"));
            }


        }
    }
}
