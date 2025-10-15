using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create the form if the form does not exist in the loaded document.
    if (loadedDocument.Form == null)
        loadedDocument.CreateForm();

    //Load the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create a Radio button.
    PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(loadedPage, "employeesRadioList");

    //Add the radio button into loaded document.
    loadedDocument.Form.Fields.Add(employeesRadioList);

    //Create radio button items.
    PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("1-9");
    radioButtonItem1.Bounds = new Syncfusion.Drawing.RectangleF(100, 140, 20, 20);
    PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("10-49");
    radioButtonItem2.Bounds = new Syncfusion.Drawing.RectangleF(100, 170, 20, 20);

    //Add the items to radio button group.
    employeesRadioList.Items.Add(radioButtonItem1);
    employeesRadioList.Items.Add(radioButtonItem2);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
