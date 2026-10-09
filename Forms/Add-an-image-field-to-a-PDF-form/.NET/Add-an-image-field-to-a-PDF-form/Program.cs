
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create a Button.
PdfButtonField buttonField = new PdfButtonField(page, "Click");
//Set properties to the Button field.
buttonField.Bounds = new RectangleF(0, 150, 90, 20);
buttonField.Text = "Click";
PdfBitmap image = new PdfBitmap(new FileStream(@"../../../logo.png", FileMode.Open));
buttonField.Appearance.Normal.Graphics.DrawImage(image, 0, 0, 90, 20);
buttonField.Actions.MouseUp = new PdfJavaScriptAction("event.target.buttonImportIcon();");

//Add the form field to the document.
document.Form.Fields.Add(buttonField);
//Disable the default appearance of the form fields in the document.
document.Form.SetDefaultAppearance(false);

//Save the document.
document.Save("Output.pdf");
//Close the document.
document.Close(true);
