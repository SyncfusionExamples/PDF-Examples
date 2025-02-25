﻿// See https://aka.ms/new-console-template for more information
 
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the conformance level of the loaded document. 
PdfConformanceLevel conformance = loadedDocument.Conformance;

Console.WriteLine("Conformance level :" + conformance);

//Close the document.
loadedDocument.Close(true);
