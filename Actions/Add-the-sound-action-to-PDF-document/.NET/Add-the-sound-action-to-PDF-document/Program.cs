using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Get stream from the sound file. 
    FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Startup.wav"), FileMode.Open, FileAccess.Read);

    //Create a sound action.
    PdfSoundAction soundAction = new PdfSoundAction(fileStream);
    soundAction.Sound.Bits = 16;
    soundAction.Sound.Channels = PdfSoundChannels.Stereo;
    soundAction.Sound.Encoding = PdfSoundEncoding.Signed;
    soundAction.Volume = 0.9f;

    //Set the sound action.
    document.Actions.AfterOpen = soundAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}