using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;
using System.IO;

namespace BlazorPDFGettingStarted
{
    public class PdfService
    {

        public static MemoryStream FillPdfForm(Stream inputFileStream)
        {
            try
            {
                PdfLoadedDocument document = new PdfLoadedDocument(inputFileStream);
                PdfLoadedForm form = document.Form;

                PdfLoadedFormFieldCollection fields = form.Fields;

                for(int i = 0; i< fields.Count; i++)
                {
                    if (fields[i] is PdfLoadedTextBoxField)
                    {
                        PdfLoadedTextBoxField textBoxField = fields[i] as PdfLoadedTextBoxField;
                        switch (textBoxField.Name)
                        {
                            case "txtFirst":
                                textBoxField.Text = "Johnson";
                                break;
                            case "txtLast":
                                textBoxField.Text = "Smith";
                                break;
                            case "txtPhone":
                                textBoxField.Text = "9192356837";
                                break;
                            case "txtEmail":
                                textBoxField.Text = "myname@mycompany.com";
                                break;
                            case "txtAck":
                                textBoxField.Text = "7/28/2023";
                                break;
                        }
                        
                    }
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    document.Save(stream);
                    //Closing the PDF document
                    document.Close(true);
                    return stream;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }

        public static MemoryStream FillPdfForm(byte[] inputBytes)
        {
            try
            {
                PdfLoadedDocument document = new PdfLoadedDocument(inputBytes);
                PdfLoadedForm form = document.Form;

                PdfLoadedFormFieldCollection fields = form.Fields;

                for (int i = 0; i < fields.Count; i++)
                {
                    if (fields[i] is PdfLoadedTextBoxField)
                    {
                        PdfLoadedTextBoxField textBoxField = fields[i] as PdfLoadedTextBoxField;
                        switch (textBoxField.Name)
                        {
                            case "txtFirst":
                                textBoxField.Text = "Johnson";
                                break;
                            case "txtLast":
                                textBoxField.Text = "Smith";
                                break;
                            case "txtPhone":
                                textBoxField.Text = "9192356837";
                                break;
                            case "txtEmail":
                                textBoxField.Text = "myname@mycompany.com";
                                break;
                            case "txtAck":
                                textBoxField.Text = "7/28/2023";
                                break;
                        }

                    }
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    document.Save(stream);
                    //Closing the PDF document
                    document.Close(true);
                    return stream;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
