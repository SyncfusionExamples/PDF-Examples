using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page.
    PdfPage page = document.Pages.Add();

    //Load a image as stream.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/logo.png"), FileMode.Open, FileAccess.Read);

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

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

