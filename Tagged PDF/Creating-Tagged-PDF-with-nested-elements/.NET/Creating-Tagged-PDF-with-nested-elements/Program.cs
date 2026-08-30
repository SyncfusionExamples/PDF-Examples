using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace Creating_Tagged_PDF_with_nested_elements {
    internal class Program {
        static void Main(string[] args) {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2V1hhQlJAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Vd0BiXX9ccXRQRGBa");

            //Creates new PDF document. 
            using (PdfDocument document = new PdfDocument()) {
                //Set the document title.
                document.DocumentInformation.Title = "Tagged Pdf Document";
                //Creates new page.
                PdfPage page = document.Pages.Add();
                //Initialize the structure element with tag type paragraph.
                PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Paragraph);
                //Represents the text that is exact replacement for PdfTextElement.
                structureElement.ActualText = "Simple paragraph element";
                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean nec lectus ac sem faucibus imperdiet. Sed ut erat ac magna ullamcorper hendrerit. Cras pellentesque libero semper, gravida magna sed, luctus leo. Fusce lectus odio, laoreet nec ullamcorper ut, molestie eu elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aliquam lacinia sit amet elit ac consectetur. Donec cursus condimentum ligula, vitae volutpat sem tristique eget. Nulla in consectetur massa. Vestibulum vitae lobortis ante. Nulla ullamcorper pellentesque justo rhoncus accumsan. Mauris ornare eu odio non lacinia. Aliquam massa leo, rhoncus ac iaculis eget, tempus et magna. Sed non consectetur elit.";
                //Initialize the PDF text element.
                PdfTextElement element = new PdfTextElement(text);
                //Adding tag to the text element.
                element.PdfTag = structureElement;
                //Creates font for the text element.
                element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                //Create brush for the text element. 
                element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));

                //Initialize the structure element with tag type quotation.
                PdfStructureElement quoteChildElement = new PdfStructureElement(PdfTagType.Quotation);
                quoteChildElement.Parent = structureElement;
                string text1 = "This is the nested text.";
                //Initialize the PDF text element.
                PdfTextElement element1 = new PdfTextElement(text1);
                element1.PdfTag = quoteChildElement;
                //Creates font for the text element.
                element1.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                //Create brush for the text element. 
                element1.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                element1.Draw(page, new RectangleF(0, 100, result.Bounds.Width, result.Bounds.Height));

                //Initialize the structure element with tag type span.
                PdfStructureElement spanChildElement = new PdfStructureElement(PdfTagType.Span);
                spanChildElement.Parent = structureElement;
                string text2 = " Appended Text.";
                //Initialize the PDF text element.
                PdfTextElement element2 = new PdfTextElement(text2);
                element2.PdfTag = spanChildElement;
                //Creates font for the text element.
                element2.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                //Create brush for the text element. 
                element2.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                //Draws text element. 
                element2.Draw(page, new RectangleF(0, 140, result.Bounds.Width, result.Bounds.Height));

                //Create file stream.
                using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                    //Save the PDF document to file stream.
                    document.Save(outputFileStream);
                }
            }
        }
    }
}