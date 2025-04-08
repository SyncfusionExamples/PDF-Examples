using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

namespace Create_PDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize the HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            BlinkConverterSettings settings = new BlinkConverterSettings();
            //Set enable form
            settings.EnableForm = true;
            //Assign Blink converter settings to HTML converter
            htmlConverter.ConverterSettings = settings;

            //Convert HTML to PDF
            PdfDocument document = htmlConverter.Convert(Path.GetFullPath("Data/Test.html"));
            document.Form.SetDefaultAppearance(false);
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                stream.Position = 0;
                document.Close(true);
                //Add signature field in PDF.
                AddSignature(stream);
            }

        }
        /// <summary>
        /// Adds signature field in PDF
        /// </summary>
        /// <param name="stream"></param>
        static void AddSignature(MemoryStream stream)
        {
            //Load the PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);
            //Get the loaded form.
            PdfLoadedForm loadedForm = loadedDocument.Form;

            List<PdfSignatureField> signatureFields = new List<PdfSignatureField>();

            for (int i = loadedForm.Fields.Count - 1; i >= 0; i--)
            {

                if (loadedForm.Fields[i] is PdfLoadedTextBoxField)
                {
                    //Get the loaded text box field and fill it.
                    PdfLoadedTextBoxField loadedTextBoxField = loadedForm.Fields[i] as PdfLoadedTextBoxField;

                    if (loadedTextBoxField.Name.Contains("textarea"))
                    {
                        //Get bounds from an existing textbox field.
                        RectangleF bounds = loadedTextBoxField.Bounds;

                        //Get page.
                        PdfPageBase loadedPage = loadedTextBoxField.Page;

                        //Create PDF Signature field.
                        PdfSignatureField signatureField = new PdfSignatureField(loadedPage, loadedTextBoxField.Name.Trim());

                        //Set properties to the signature field.
                        signatureField.Bounds = bounds;

                        //Add the form field to the document.
                        signatureFields.Add(signatureField);

                        loadedForm.Fields.Remove(loadedTextBoxField);
                    }
                }
            }
            foreach (PdfSignatureField signature in signatureFields)
            {
                loadedForm.Fields.Add(signature);
            }
            //Save the document.
            using (FileStream outputStream1 = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                loadedDocument.Save(outputStream1);
            }
            loadedDocument.Close(true);
        }
    }
}