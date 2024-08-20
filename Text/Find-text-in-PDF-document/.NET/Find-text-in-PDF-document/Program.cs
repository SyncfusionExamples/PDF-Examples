// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using static System.Net.Mime.MediaTypeNames;

string matchText = string.Empty;
//Load an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Returns page number and rectangle positions of the text maches. 
Dictionary<int, List<Syncfusion.Drawing.RectangleF>> matchRects = new Dictionary<int, List<Syncfusion.Drawing.RectangleF>>();
loadedDocument.FindText("document", out matchRects);

for (int i = 0; i < loadedDocument.Pages.Count; i++)
{
    List<Syncfusion.Drawing.RectangleF> rectCoords = matchRects[i];
    matchText = "First Occurrence: X:" + rectCoords[0].X + "; Y:" + rectCoords[0].Y + "; Width:" + rectCoords[0].Width + "; Height:" + rectCoords[0].Height + Environment.NewLine +
                      "Second Occurrence: X:" + rectCoords[1].X + "; Y:" + rectCoords[1].Y + "; Width:" + rectCoords[1].Width + "; Height:" + rectCoords[1].Height + Environment.NewLine +
                      "Third Occurrence: X:" + rectCoords[2].X + "; Y:" + rectCoords[2].Y + "; Width:" + rectCoords[2].Width + "; Height:" + rectCoords[2].Height + Environment.NewLine +
                      "Fourth Occurrence: X:" + rectCoords[3].X + "; Y:" + rectCoords[3].Y + "; Width:" + rectCoords[3].Width + "; Height:" + rectCoords[3].Height + Environment.NewLine;
}

//Close the document.
loadedDocument.Close(true);

Console.WriteLine(matchText);
Console.ReadLine();
