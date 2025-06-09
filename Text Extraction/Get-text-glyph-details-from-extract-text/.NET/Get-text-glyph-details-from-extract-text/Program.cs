using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;


//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
// Load the existing PDF document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
// Get the first page of the loaded PDF document
PdfPageBase page = loadedDocument.Pages[0];
TextLineCollection lineCollection = new TextLineCollection();

// Extract text from the first page
string extractedText = page.ExtractText(out lineCollection);
// Get a specific line from the collection
TextLine line = lineCollection.TextLine[0];
// Get the collection of words in the line
List<TextWord> textWordCollection = line.WordCollection;
// Get a word from the collection using an index
TextWord textWord = textWordCollection[0];
// Get Glyph details of the word
List<TextGlyph> textGlyphCollection = textWord.Glyphs;

// Get a character from the word
TextGlyph textGlyph = textGlyphCollection[0];
// Get bounds of the character
RectangleF glyphBounds = textGlyph.Bounds;
// Get font name of the character
string glyphFontName = textGlyph.FontName;
// Get font size of the character
float glyphFontSize = textGlyph.FontSize;
// Get font style of the character
FontStyle glyphFontStyle = textGlyph.FontStyle;
// Get the character in the word
char glyphText = textGlyph.Text;
// Get the color of the character
Color glyphColor = textGlyph.TextColor;
loadedDocument.Close();
