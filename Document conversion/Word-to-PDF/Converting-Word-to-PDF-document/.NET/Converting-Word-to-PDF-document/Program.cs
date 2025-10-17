﻿using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Open the file as Stream.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Template.docx"), FileMode.Open, FileAccess.Read);

//Loads file stream into Word document.
WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Automatic);

//Instantiation of DocIORenderer for Word to PDF conversion.
DocIORenderer render = new DocIORenderer();

//Converts Word document into PDF document.
PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

//Releases all resources used by the Word document and DocIO Renderer objects.
render.Dispose();
wordDocument.Dispose();

//Save the PDF document.
pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
pdfDocument.Close(true);