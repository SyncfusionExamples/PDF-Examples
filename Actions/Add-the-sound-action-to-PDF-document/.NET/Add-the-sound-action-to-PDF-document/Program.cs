// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Get stream from the sound file. 
FileStream fileStream = new FileStream(Path.GetFullPath("../../../Startup.wav"), FileMode.Open, FileAccess.Read);

//Create a sound action.
PdfSoundAction soundAction = new PdfSoundAction(fileStream);
soundAction.Sound.Bits = 16;
soundAction.Sound.Channels = PdfSoundChannels.Stereo;
soundAction.Sound.Encoding = PdfSoundEncoding.Signed;
soundAction.Volume = 0.9f;

//Set the sound action.
document.Actions.AfterOpen = soundAction;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
