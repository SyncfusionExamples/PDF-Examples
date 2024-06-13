using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;


//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
//Load the existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Get the first page of the loaded PDF document 
PdfPageBase page = loadedDocument.Pages[0];
TextLineCollection lineCollection = new TextLineCollection();
//Extract text from the first page 
string m_extractedText = page.ExtractText(out lineCollection);
//Gets specific line from the collection 
TextLine line = lineCollection.TextLine[0];
//Gets collection of the words in the line 
List<TextWord> textWordCollection = line.WordCollection;
//Gets word from the collection using index 
TextWord textWord = textWordCollection[0];
// Gets Glyph details of the word 
List<TextGlyph> textGlyphCollection = textWord.Glyphs;
//Gets character of the word 
TextGlyph textGlyph = textGlyphCollection[0];
//Gets bounds of the character 
RectangleF glyphBounds = textGlyph.Bounds;
//Gets font name of the character 
string GlyphFontName = textGlyph.FontName;
//Gets font size of the character 
float GlyphFontSize = textGlyph.FontSize;
//Gets font style of the character 
FontStyle GlyphFontStyle = textGlyph.FontStyle;
//Gets character in the word 
char GlyphText = textGlyph.Text;
//Gets the color of the character 
Color GlyphColor = textGlyph.TextColor;
//Close the document 
loadedDocument.Close(true);