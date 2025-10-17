
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Pdf;
using System.Text.RegularExpressions;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page from the document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

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
    loadedDocument.Redact();

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}