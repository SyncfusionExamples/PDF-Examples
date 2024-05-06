
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Pdf;
using System.Text.RegularExpressions;

//Create stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Get the first page from the document.
PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

TextLineCollection collection = new TextLineCollection();
//Extract text from first page.
string extractedText = page.ExtractText(out collection);

foreach (TextLine line in collection.TextLine)
{
    foreach (TextWord word in line.WordCollection)
    {
        //Define regular expression pattern to search for dates in the format MM/DD/YYYY
        string datePattern = @"\b\d{1,2}\/\d{1,2}\/\d{4}\b";
        //Search for dates
        MatchCollection dateMatches = Regex.Matches(word.Text, datePattern);
        //Add redaction if the match found
        foreach (Match dateMatch in dateMatches)
        {
            string textToFindAndRedact = dateMatch.Value;
            if (textToFindAndRedact == word.Text)
            {
                //Create a redaction object.
                PdfRedaction redaction = new PdfRedaction(word.Bounds, Syncfusion.Drawing.Color.Black);
                //Add a redaction object into the redaction collection of loaded page.
                page.AddRedaction(redaction);
            }
        }
    }
}

//Redact the contents from the PDF document.
document.Redact();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);