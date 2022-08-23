// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create list box.
PdfListBoxField listBoxField = new PdfListBoxField(page, "list1");

//Set the properties.
listBoxField.Bounds = new Syncfusion.Drawing.RectangleF(100, 60, 100, 50);

//Add the items to the list box.
listBoxField.Items.Add(new PdfListFieldItem("English", "English"));
listBoxField.Items.Add(new PdfListFieldItem("French", "French"));
listBoxField.Items.Add(new PdfListFieldItem("German", "German"));

//Select the item.
listBoxField.SelectedIndex = 0;

//Set the multi select option.
listBoxField.MultiSelect = true;

//Add the list box into PDF document
document.Form.Fields.Add(listBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
