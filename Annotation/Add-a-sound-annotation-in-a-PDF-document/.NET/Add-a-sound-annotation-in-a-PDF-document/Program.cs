﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Creates a new rectangle.
    RectangleF rectangle = new RectangleF(10, 40, 30, 30);

    //Creates a new sound annotation.
    FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Sound.wav"), FileMode.Open, FileAccess.Read);
    PdfSoundAnnotation soundAnnotation = new PdfSoundAnnotation(rectangle, inputStream);
    soundAnnotation.Sound.Encoding = PdfSoundEncoding.Signed;
    soundAnnotation.Sound.Channels = PdfSoundChannels.Stereo;
    soundAnnotation.Sound.Bits = 16;
    soundAnnotation.Color = new PdfColor(Color.Red);

    //Sets the pdf sound icon.
    soundAnnotation.Icon = PdfSoundIcon.Speaker;

    //Adds this annotation to a new page.
    page.Annotations.Add(soundAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

