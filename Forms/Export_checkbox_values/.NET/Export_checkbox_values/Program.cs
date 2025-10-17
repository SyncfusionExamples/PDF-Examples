using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page to the PDF document. 
    PdfPage page = document.Pages.Add();

    //Create the form. 
    PdfForm form = document.Form;

    //Enable the field auto naming.  
    form.FieldAutoNaming = false;

    //Set default appearance as false. 
    document.Form.SetDefaultAppearance(false);

    // Create First checkbox field 
    PdfCheckBoxField checkBoxField1 = new PdfCheckBoxField(page, "CheckBox");
    checkBoxField1.Bounds = new RectangleF(10, 150, 50, 20);
    checkBoxField1.BorderColor = Color.Red;
    checkBoxField1.BorderWidth = 3;
    checkBoxField1.BackColor = Color.Yellow;

    //Set the Export value 
    checkBoxField1.ExportValue = "Value";
    checkBoxField1.Checked = true;

    // Add to form 
    form.Fields.Add(checkBoxField1);

    // Create Second checkbox field 
    PdfCheckBoxField checkBoxField2 = new PdfCheckBoxField(page, "CheckBox");
    checkBoxField2.Bounds = new RectangleF(10, 250, 50, 20);
    checkBoxField2.BorderColor = Color.Green;
    checkBoxField2.BorderWidth = 2;
    checkBoxField2.BackColor = Color.YellowGreen;

    // Add to form 
    form.Fields.Add(checkBoxField2);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}