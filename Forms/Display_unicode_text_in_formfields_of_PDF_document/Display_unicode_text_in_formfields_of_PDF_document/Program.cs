using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display_unicode_text_in_formfields_of_PDF_document
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Use the system installed font
            PdfFont font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 14), true);

            //Read the unicode text from the text file.
            StreamReader reader = new StreamReader(@"../../Data/Input.txt", Encoding.UTF8);
            string text = reader.ReadToEnd();
            reader.Close();

            // Create the new PDF text box field.
            PdfTextBoxField textField = new PdfTextBoxField(page, "textBox");
            // Set bounds.
            textField.Bounds = new RectangleF(10, 10, 200, 30);

            textField.Text = text;
            // Set font.
            textField.Font = font;
            // Add the field to the form collection.
            document.Form.Fields.Add(textField);


            //Save the document.
            document.Save("../../Data/Output.pdf");

            //Close the document.
            document.Close(true);
        }
    }
}
