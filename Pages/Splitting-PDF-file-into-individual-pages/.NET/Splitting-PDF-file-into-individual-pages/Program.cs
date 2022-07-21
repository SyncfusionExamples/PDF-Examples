// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

for (int i = 0; i < loadedDocument.PageCount; i++)
{

    //Creates a new document.
    PdfDocument document = new PdfDocument();

    //Imports the pages from the loaded document.
    document.ImportPage(loadedDocument, i);

    //Create a memory stream. 
    MemoryStream stream = new MemoryStream();

    //Save the document to stream.
    document.Save(stream);

    stream.Position = 0;

    //Close the documents.
    document.Close(true);
	loadedDocument.Close(true);

    //Create a file stream.
    FileStream fileStream = new FileStream("Output" + i + ".pdf", FileMode.Create, FileAccess.Write);

    byte[] bytes = stream.ToArray();

    //Write bytes to file.
    fileStream.Write(bytes, 0, (int)bytes.Length);

    //Dispose the streams.
    stream.Dispose();
    fileStream.Dispose();

}
