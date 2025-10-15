using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
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

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
