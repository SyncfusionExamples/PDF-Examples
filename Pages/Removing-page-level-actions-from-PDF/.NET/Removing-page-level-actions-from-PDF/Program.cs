using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document.
    PdfPage page1 = document.Pages.Add();
    // Create and add new JavaScript action to execute when the first page opens
    page1.Actions.OnOpen = new PdfJavaScriptAction("app.alert(\"Welcome! This page has just been opened.\");");
    // Create and add new URI action to execute when the first page closes
    page1.Actions.OnClose = new PdfUriAction("http://www.google.com");
    // Add second page to the document.
    PdfPage page2 = document.Pages.Add();
    // Create a sound action 
    PdfSoundAction soundAction = new PdfSoundAction(Path.GetFullPath(@"Data/Startup.wav"));
    soundAction.Sound.Bits = 16;
    soundAction.Sound.Channels = PdfSoundChannels.Stereo;
    soundAction.Sound.Encoding = PdfSoundEncoding.Signed;
    soundAction.Volume = 0.9f;
    // Set the so und action to execute when the second page opens
    page2.Actions.OnOpen = soundAction;
    // Create and add new Launch action to execute when the second page closes
    page2.Actions.OnClose = new PdfLaunchAction(Path.GetFullPath(@"Data/logo.png"));
    // Add third page to the document
    PdfPage page3 = document.Pages.Add();
    // Create and add new JavaScript action to execute when the third page opens
    PdfAction jsAction = new PdfJavaScriptAction("app.alert(\"Welcome! Third page has just been opened.\");");
    jsAction.Next = new PdfJavaScriptAction("app.alert(\"This is the second action.\");");
    jsAction.Next.Next = new PdfJavaScriptAction("app.alert(\"This is the third action.\");");
    page3.Actions.OnOpen = jsAction;
    // Removing the open action on first page
    page1.Actions.OnOpen = null;
    // Removing the close action on second page
    page2.Actions.OnClose = null;
    // Removing both actions on third page 
    page3.Actions.Clear(false);
    //Save the document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
    // Close the document
    document.Close(true);
}
