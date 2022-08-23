// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create a Radio button.
PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "employeesRadioList");

//Add the radio button into form.
document.Form.Fields.Add(employeesRadioList);

//Create radio button items.
PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("1-9");
radioButtonItem1.Bounds = new Syncfusion.Drawing.RectangleF(100, 140, 20, 20);
PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("10-49");
radioButtonItem2.Bounds = new Syncfusion.Drawing.RectangleF(100, 170, 20, 20);

//Add the items to radio button group.
employeesRadioList.Items.Add(radioButtonItem1);
employeesRadioList.Items.Add(radioButtonItem2);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
