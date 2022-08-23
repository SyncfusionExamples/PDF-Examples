// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create a Button.
PdfButtonField buttonField = new PdfButtonField(page, "Click");

//Set properties to the Button field.
buttonField.Bounds = new Syncfusion.Drawing.RectangleF(0, 100, 90, 20);
buttonField.Text = "Click";

//Add the form field to the document.
document.Form.Fields.Add(buttonField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
