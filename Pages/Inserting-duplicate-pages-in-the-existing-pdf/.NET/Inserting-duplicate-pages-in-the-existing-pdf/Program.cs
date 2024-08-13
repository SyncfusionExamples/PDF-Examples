 using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Gets the page 

PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Inserts the duplicate page in the beginning of the document. 

loadedDocument.Pages.Insert(0, loadedPage);



//Creating the stream object. 

MemoryStream stream = new MemoryStream();

//Save the document as stream. 

loadedDocument.Save(stream);

File.WriteAllBytes(Path.GetFullPath("Output/Output.pdf"), stream.ToArray());
//Close the document. 

loadedDocument.Close(true);
