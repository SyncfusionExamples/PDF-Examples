﻿using Syncfusion.Pdf;

//Generate the PDF document.
PdfDocument finalDoc = new PdfDocument();
FileStream stream1 = new FileStream(@"Data/File1.pdf", FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(@"Data/File2.pdf", FileMode.Open, FileAccess.Read);
// Creates a PDF stream for merging.
Stream[] streams = { stream1, stream2 };
// Merges PDFDocument.
PdfDocumentBase.Merge(finalDoc, streams);

//Save the PDF document
finalDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
finalDoc.Close(true);
