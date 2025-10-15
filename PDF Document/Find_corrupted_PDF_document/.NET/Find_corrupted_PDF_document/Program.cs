using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Text;

//Create a new instance for the PDF analyzer.
PdfDocumentAnalyzer analyzer = new PdfDocumentAnalyzer(Path.GetFullPath(@"Data/Test.pdf");

//Get the syntax errors.
SyntaxAnalyzerResult result = analyzer.AnalyzeSyntax();

//Check whether the document is corrupted or not.
if (result.IsCorrupted)
{
    //Get syntax error details from results.error. 
    StringBuilder strBuilder = new StringBuilder();

    //Append the line with syntax error details. 
    strBuilder.AppendLine("The PDF document is corrupted.");
    int count = 1;
    foreach (PdfException exception in result.Errors)
    {
        strBuilder.AppendLine(count++.ToString() + ": " + exception.Message);
    }

    //Write the error detials in console window. 
    Console.WriteLine(strBuilder);
}
else
{
    Console.WriteLine("No Syntax error found in the provided PDF document");
}

analyzer.Close();
Console.ReadLine();
