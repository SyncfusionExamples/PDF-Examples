﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page.
    PdfPage page = document.Pages.Add();

    //Create a Button field.
    PdfButtonField submitButton = new PdfButtonField(page, "Submit data");

    //Set the properties to the button field. 
    submitButton.Bounds = new RectangleF(100, 60, 50, 20);
    submitButton.ToolTip = "Submit";
    document.Form.Fields.Add(submitButton);

    // Create a submit action. It submit the data of the form fields to the mentioned URL.
    PdfSubmitAction submitAction = new PdfSubmitAction("http://www.syncfusionforms.com/Submit.aspx");
    submitAction.DataFormat = SubmitDataFormat.Html;
    submitButton.Actions.GotFocus = submitAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}