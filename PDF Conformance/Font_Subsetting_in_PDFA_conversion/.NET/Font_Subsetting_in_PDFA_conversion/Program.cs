using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Reflection.Metadata;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using SkiaSharp;

//Get stream from an existing PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

//Sample level font event handling  
loadedDocument.SubstituteFont += LoadedDocument_SubstituteFont;

//Create conformance options 
PdfConformanceOptions options = new PdfConformanceOptions();
//Set the conformance level 
options.ConformanceLevel = PdfConformanceLevel.Pdf_A1B;

//Embed fonts as subsets  
options.SubsetFonts = true;

// Convert to PDF/A conformance 
loadedDocument.ConvertToPDFA(options);

//Save the PDF document
loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
loadedDocument.Close(true);

static void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
{
    //get the font name 
    string fontName = args.FontName.Split(',')[0];

    //get the font style 
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
        //Create the fontData from the type face stream.	  
        byte[] fontData = new byte[typeFaceStream.Length];
        typeFaceStream.Read(fontData, typeFaceStream.Length);
        typeFaceStream.Dispose();

        //Create the new memory stream from the font data.	  
        memoryStream = new MemoryStream(fontData);
    }

    //set the font stream to the event args.	 
    args.FontStream = memoryStream;
}
