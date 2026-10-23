using System;
using System.IO;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace CreateHierarchicalHeadingStructure;

class Program
{
    static void Main(string[] args)
    {
        // Define the output PDF file name in current working directory and base directory
        string outputPath = Path.GetFullPath("TaggedPdf.pdf");

        Console.WriteLine("Creating Accessible Tagged PDF with Hierarchical Heading Structure...");

        // Create a new PDF document
        using (PdfDocument document = new PdfDocument())
        {
            // Set document title and metadata for accessibility (WCAG / PDF/UA compliance)
            document.DocumentInformation.Title = "Accessible Tagged PDF with Hierarchical Headings";
            document.ViewerPreferences.DisplayTitle = true;

            // Add a new page to the document
            PdfPage page = document.Pages.Add();
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat { Layout = PdfLayoutType.Paginate };

            // Define standard fonts for headings and body content
            PdfFont h1Font = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
            PdfFont h2Font = new PdfStandardFont(PdfFontFamily.Helvetica, 15, PdfFontStyle.Bold);
            PdfFont h3Font = new PdfStandardFont(PdfFontFamily.Helvetica, 13, PdfFontStyle.Bold);
            PdfFont h4Font = new PdfStandardFont(PdfFontFamily.Helvetica, 11, PdfFontStyle.Bold);
            PdfFont h5Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
            PdfFont bodyFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);

            // Define brushes for styling
            PdfBrush headingBrush = new PdfSolidBrush(new PdfColor(24, 43, 73));
            PdfBrush bodyBrush = new PdfSolidBrush(new PdfColor(60, 60, 60));

            float yPos = 20;
            float pageWidth = page.Graphics.ClientSize.Width;

            // ====================================================================================
            // 1. H1 (Main Heading)
            // ------------------------------------------------------------------------------------
            // In the PDF logical structure tree (StructTreeRoot), H1 is a top-level heading.
            // Leaving Parent as null attaches this structure element directly under the Document root.
            // ====================================================================================
            PdfStructureElement h1Tag = new PdfStructureElement(PdfTagType.HeadingLevel1)
            {
                Title = "Main Heading (H1)"
            };

            PdfTextElement h1Element = new PdfTextElement("H1: Document Accessibility and Semantic Structure Guide", h1Font, headingBrush)
            {
                PdfTag = h1Tag
            };
            PdfLayoutResult result = h1Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 6;

            // Sample content under H1 (introductory paragraph at root level)
            PdfStructureElement h1ContentTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Introductory Content under H1"
            };

            PdfTextElement h1ContentElement = new PdfTextElement(
                "Accessible Tagged PDF documents ensure that all users, including those using assistive technologies " +
                "like screen readers, can easily navigate, interpret, and understand digital publications. " +
                "Semantic heading tags establish a navigational outline that facilitates sequential and hierarchical exploration.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = h1ContentTag
            };
            result = h1ContentElement.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 16;

            // ====================================================================================
            // 2. H2 (Section Heading)
            // ------------------------------------------------------------------------------------
            // H2 serves as the primary section header.
            // In this hierarchy, H2 acts as the parent container tag for subsections H3, H4, and H5.
            // ====================================================================================
            PdfStructureElement h2Tag = new PdfStructureElement(PdfTagType.HeadingLevel2)
            {
                Title = "Section Heading (H2)"
            };

            PdfTextElement h2Element = new PdfTextElement("H2: Core Accessibility Guidelines and Standards", h2Font, headingBrush)
            {
                PdfTag = h2Tag
            };
            result = h2Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 6;

            // Sample content under H2 - establishing parent-child relationship by assigning h2ContentTag.Parent = h2Tag
            PdfStructureElement h2ContentTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Content under H2",
                Parent = h2Tag // Parent-child relationship: H2 -> Paragraph
            };

            PdfTextElement h2ContentElement = new PdfTextElement(
                "This section outlines international accessibility standards (WCAG 2.1 and PDF/UA-1). " +
                "The subsections below (H3, H4, and H5) demonstrate how subsections are structurally nested " +
                "under this H2 section tag in the PDF document structure tree.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = h2ContentTag
            };
            result = h2ContentElement.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 14;

            // ====================================================================================
            // 3. H3 (Subsection Heading)
            // ------------------------------------------------------------------------------------
            // ESTABLISHING PARENT-CHILD RELATIONSHIP:
            // Setting h3Tag.Parent = h2Tag nests H3 as a direct child of H2 in the PDF structure tree.
            // Assistive technologies encounter H3 as a logical subsection within H2.
            // ====================================================================================
            PdfStructureElement h3Tag = new PdfStructureElement(PdfTagType.HeadingLevel3)
            {
                Title = "Subsection Heading (H3)",
                Parent = h2Tag // Parent-child relationship: H2 -> H3
            };

            PdfTextElement h3Element = new PdfTextElement("H3: Perceivable Digital Content and Structure", h3Font, headingBrush)
            {
                PdfTag = h3Tag
            };
            result = h3Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 6;

            // Sample content under H3 - nested under H3 structure element
            PdfStructureElement h3ContentTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Content under H3",
                Parent = h3Tag // Parent-child relationship: H3 -> Paragraph
            };

            PdfTextElement h3ContentElement = new PdfTextElement(
                "Digital content must provide text alternatives and clear heading semantics so that assistive " +
                "tools can convey visual hierarchy and meaningful reading sequences to end users.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = h3ContentTag
            };
            result = h3ContentElement.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 14;

            // ====================================================================================
            // 4. H4 (Subsection Heading)
            // ------------------------------------------------------------------------------------
            // ESTABLISHING PARENT-CHILD RELATIONSHIP:
            // Setting h4Tag.Parent = h2Tag nests H4 under H2 in the tag hierarchy.
            // This satisfies the requirement that H3, H4, and H5 are all nested under H2.
            // ====================================================================================
            PdfStructureElement h4Tag = new PdfStructureElement(PdfTagType.HeadingLevel4)
            {
                Title = "Subsection Heading (H4)",
                Parent = h2Tag // Parent-child relationship: H2 -> H4
            };

            PdfTextElement h4Element = new PdfTextElement("H4: Logical Tree Hierarchy and Element Ordering", h4Font, headingBrush)
            {
                PdfTag = h4Tag
            };
            result = h4Element.Draw(page, new RectangleF(30, yPos, pageWidth - 30, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 6;

            // Sample content under H4 - nested under H4 structure element
            PdfStructureElement h4ContentTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Content under H4",
                Parent = h4Tag // Parent-child relationship: H4 -> Paragraph
            };

            PdfTextElement h4ContentElement = new PdfTextElement(
                "In PDF tagging, the StructTreeRoot manages the tree of PdfStructureElement instances. " +
                "Explicitly assigning the Parent property ensures that subheadings and body paragraphs " +
                "are grouped logically under their intended parent sections.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = h4ContentTag
            };
            result = h4ContentElement.Draw(page, new RectangleF(30, yPos, pageWidth - 30, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 14;

            // ====================================================================================
            // 5. H5 (Subsection Heading)
            // ------------------------------------------------------------------------------------
            // ESTABLISHING PARENT-CHILD RELATIONSHIP:
            // Setting h5Tag.Parent = h2Tag nests H5 under H2 in the tag hierarchy.
            // Assistive devices and accessibility validators recognise H5 as nested under H2.
            // ====================================================================================
            PdfStructureElement h5Tag = new PdfStructureElement(PdfTagType.HeadingLevel5)
            {
                Title = "Subsection Heading (H5)",
                Parent = h2Tag // Parent-child relationship: H2 -> H5
            };

            PdfTextElement h5Element = new PdfTextElement("H5: Accessibility Validation and Compliance Verification", h5Font, headingBrush)
            {
                PdfTag = h5Tag
            };
            result = h5Element.Draw(page, new RectangleF(45, yPos, pageWidth - 45, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 6;

            // Sample content under H5 - nested under H5 structure element
            PdfStructureElement h5ContentTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Content under H5",
                Parent = h5Tag // Parent-child relationship: H5 -> Paragraph
            };

            PdfTextElement h5ContentElement = new PdfTextElement(
                "Automated checkers and screen readers verify the MarkInfo dictionary (/Marked true) " +
                "and traverse the structure tree to ensure valid parent-child relationships and semantic heading progression.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = h5ContentTag
            };
            result = h5ContentElement.Draw(page, new RectangleF(45, yPos, pageWidth - 45, 50), layoutFormat);

            // Save the generated Tagged PDF document
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                document.Save(fileStream);
            }

            Console.WriteLine($"Tagged PDF successfully generated and saved to: {outputPath}");
        }

        // Verify and display the document structure tree from the generated PDF
        Console.WriteLine("\n--- Validating Document Structure Tree ---");
        using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(outputPath))
        {
            PdfStructureElement rootElement = loadedDocument.StructureElement;
            if (rootElement != null)
            {
                PrintStructureTree(rootElement, 0);
            }
        }
    }

    /// <summary>
    /// Recursively prints the structure elements of the tagged PDF to verify heading hierarchy.
    /// </summary>
    private static void PrintStructureTree(PdfStructureElement element, int depth)
    {
        if (element == null) return;

        string indent = new string(' ', depth * 2);
        string textPreview = string.IsNullOrWhiteSpace(element.Text) ? "" : $" (Text: \"{element.Text.Trim()}\")";
        string titleInfo = string.IsNullOrWhiteSpace(element.Title) ? "" : $" [{element.Title}]";

        Console.WriteLine($"{indent}Tag: <{element.TagType}>{titleInfo}{textPreview}");

        if (element.ChildElements != null)
        {
            foreach (PdfStructureElement child in element.ChildElements)
            {
                PrintStructureTree(child, depth + 1);
            }
        }
    }
}
