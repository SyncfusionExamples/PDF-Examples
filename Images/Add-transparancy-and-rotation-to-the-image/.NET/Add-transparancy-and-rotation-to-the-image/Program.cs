// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create Document.
PdfDocument document = new PdfDocument();

//Add a new page.
PdfPage page = document.Pages.Add();

//Load a image as stream.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../logo.png"), FileMode.Open, FileAccess.Read);

//Load a bitmap.
PdfBitmap image = new PdfBitmap(imageStream);

//Save the current graphics state.
PdfGraphicsState state = page.Graphics.Save();

//Translate the coordinate system to the  required position.
page.Graphics.TranslateTransform(20, 100);

//Apply transparency.
page.Graphics.SetTransparency(0.5f);

//Rotate the coordinate system.
page.Graphics.RotateTransform(-45);

//Draw image.
image.Draw(page, 0, 100);

//Restore the graphics state.
page.Graphics.Restore(state);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);

