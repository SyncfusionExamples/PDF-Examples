using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Pdf.Security;

class Program
{
    static void Main(string[] args)
    {
        // Initialize HTML to PDF converter and load HTML
        HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
        string htmlFilePath = Path.GetFullPath(@"Data/Input.html");
        PdfDocument document = htmlConverter.Convert(htmlFilePath);

        // Save the PDF to a memory stream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            document.Save(memoryStream);
            document.Close(true);

            // Load back the PDF for further processing
            memoryStream.Position = 0;
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(memoryStream);

            // This will collect (pageIndex, word) for each form field
            List<(int pageIdx, TextWord word)> fieldData = new List<(int pageIdx, TextWord word)>();

            // Pass 1: Locate each placeholder and add a redaction on its bound
            for (int i = 0; i < loadedDocument.Pages.Count; i++)
            {
                PdfLoadedPage page = loadedDocument.Pages[i] as PdfLoadedPage;
                page.ExtractText(out TextLineCollection lines);
                if (lines == null) continue;
                foreach (TextLine line in lines.TextLine)
                {
                    foreach (TextWord word in line.WordCollection)
                    {
                        if (word == null) continue;
                        if (word.Text == "{{name}}" ||
                            word.Text == "{{date}}" ||
                            word.Text == "{{signature}}")
                        {
                            page.AddRedaction(new PdfRedaction(word.Bounds));
                            fieldData.Add((i, word));
                        }
                    }
                }
            }
            loadedDocument.Redact();

            // Pass 2: Add form fields exactly over the bounds
            foreach (var (pageIdx, word) in fieldData)
            {
                PdfPageBase page = loadedDocument.Pages[pageIdx];

                if (word.Text == "{{name}}")
                {
                    PdfTextBoxField textBox = new PdfTextBoxField(page, "FirstName")
                    {
                        Bounds = word.Bounds,
                        ToolTip = "First Name",
                        Text = "John"
                    };
                    loadedDocument.Form.Fields.Add(textBox);
                }
                else if (word.Text == "{{date}}")
                {
                    PdfTextBoxField dateField = new PdfTextBoxField(page, "DateField")
                    {
                        Bounds = word.Bounds
                    };
                    dateField.Actions.KeyPressed = new PdfJavaScriptAction("AFDate_KeystrokeEx(\"m/d/yy\")");
                    dateField.Actions.Format = new PdfJavaScriptAction("AFDate_FormatEx(\"m/d/yy\")");
                    loadedDocument.Form.Fields.Add(dateField);
                }
                else if (word.Text == "{{signature}}")
                {
                    PdfSignatureField sigField = new PdfSignatureField(page, "SignatureField")
                    {
                        Bounds = word.Bounds,
                        Signature = new PdfSignature()
                    };
                    // Optionally draw a signature image in the field area
                    FileStream imageStream = new FileStream(Path.GetFullPath("Data/signature.png"), FileMode.Open, FileAccess.Read);
                    PdfBitmap image = new PdfBitmap(imageStream);
                    (page as PdfLoadedPage).Graphics.DrawImage(image, word.Bounds);
                    imageStream.Dispose();

                    // Optional: add digital certificate
                    using (FileStream certStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read))
                    {
                        sigField.Signature.Certificate = new PdfCertificate(certStream, "syncfusion");
                        sigField.Signature.Reason = "I am author of this document";
                    }
                    loadedDocument.Form.Fields.Add(sigField);
                }
            }
            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                loadedDocument.Save(outputFileStream);
            }

            //Close the document.
            loadedDocument.Close(true);
        }
    }
}