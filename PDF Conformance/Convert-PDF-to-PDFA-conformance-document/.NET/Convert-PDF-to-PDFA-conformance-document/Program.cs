// See https://aka.ms/new-console-template for more information

using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from the PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Sample level font event handling
loadedDocument.SubstituteFont += LoadedDocument_SubstituteFont;

void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
{
    //Get the font name.
    string fontName = args.FontName.Split(',')[0];

    //Get the font style. 
    PdfFontStyle fontStyle = args.FontStyle;
    SKFontStyle sKFontStyle = SKFontStyle.Normal;

    if (fontStyle != PdfFontStyle.Regular)
    {
        if (fontStyle == PdfFontStyle.Bold)
        {
            sKFontStyle = SKFontStyle.Bold;
        }
        else if (fontStyle == PdfFontStyle.Italic)
        {
            sKFontStyle = SKFontStyle.Italic;
        }
        else if (fontStyle == (PdfFontStyle.Italic | PdfFontStyle.Bold))
        {
            sKFontStyle = SKFontStyle.BoldItalic;
        }
    }

    SKTypeface typeface = SKTypeface.FromFamilyName(fontName, sKFontStyle);
    SKStreamAsset typeFaceStream = typeface.OpenStream();
    MemoryStream memoryStream = null;

    if (typeFaceStream != null && typeFaceStream.Length > 0)
    {
        //Create a fontData from the type face stream.
        byte[] fontData = new byte[typeFaceStream.Length - 1];
        typeFaceStream.Read(fontData, typeFaceStream.Length);
        typeFaceStream.Dispose();
        //Create a new memory stream from the font data.
        memoryStream = new MemoryStream(fontData);
    }

    //Set the font stream to the event args.
    args.FontStream = memoryStream;
}

//Convert the loaded document to PDF/A document
loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
