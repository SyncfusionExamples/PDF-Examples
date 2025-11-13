using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load an existing PDF file.
using (PdfLoadedDocument ldoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the existing signed signature field.
    PdfLoadedSignatureField loadedSignature = ldoc.Form.Fields[0] as PdfLoadedSignatureField;
    //Get the image streams.
    Stream[] imageStreams = loadedSignature.GetImages();
    for (int i = 0; i < imageStreams.Length; i++)
    {
        File.WriteAllBytes(Path.GetFullPath(@"Output/" + i.ToString() + ".jpg"), (imageStreams[i] as MemoryStream).ToArray());
    }
}