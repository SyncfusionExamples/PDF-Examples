using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument finalDocument = new PdfDocument();

//Get the stream from an existing PDF documents.
FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read);
//Creates a PDF stream for merging.
Stream[] streams = { stream1, stream2 };
//Merges PDF documents.
PdfDocumentBase.Merge(finalDocument, streams);

//Creates a certificate instance from PFX file with private key.
FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

//Creates a digital signature.
PdfSignature signature = new PdfSignature(finalDocument, finalDocument.Pages[0], pdfCert, "Signature");
//Sets an image for signature field.
FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.png"), FileMode.Open, FileAccess.Read);
//Sets an image for signature field.
PdfBitmap signatureImage = new PdfBitmap(imageStream);
//Sets signature information.
signature.Bounds = new RectangleF(new PointF(0, 0), new SizeF(100, 100));
signature.ContactInfo = "johndoe@owned.us";
signature.LocationInfo = "Honolulu, Hawaii";
signature.Reason = "I am author of this document.";

//Draw the image in signature appearance. 
signature.Appearance.Normal.Graphics.DrawImage(signatureImage, new RectangleF(0, 0, 100, 100));

//Save the PDF document
finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document
finalDocument.Close(true);

