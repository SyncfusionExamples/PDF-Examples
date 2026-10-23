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
            document.DocumentInformation.Title = "Accessible Tagged PDF with Multiple Hierarchical Sections";
            document.ViewerPreferences.DisplayTitle = true;

            // Add a new page to the document
            PdfPage page = document.Pages.Add();
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat { Layout = PdfLayoutType.Paginate };

            // Define standard fonts for headings and body content
            PdfFont h1Font = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
            PdfFont h2Font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            PdfFont h3Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            PdfFont h4Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10.5f, PdfFontStyle.Bold);
            PdfFont bodyFont = new PdfStandardFont(PdfFontFamily.Helvetica, 9.5f, PdfFontStyle.Regular);

            // Define brushes for styling
            PdfBrush headingBrush = new PdfSolidBrush(new PdfColor(24, 43, 73));
            PdfBrush bodyBrush = new PdfSolidBrush(new PdfColor(60, 60, 60));

            float yPos = 20;
            float pageWidth = page.Graphics.ClientSize.Width;

            // ====================================================================================
            // Document Tag Hierarchy Overview:
            //
            // H1 (Main Heading)
            //   H2 (Section 1)
            //     Paragraph
            //     H3 (Subsection 1.1)
            //       Paragraph
            //     H3 (Subsection 1.2)
            //       Paragraph
            //       H4 (Deep Subsection 1.2.1)
            //         Paragraph
            //   H2 (Section 2)
            //     Paragraph
            //     H3 (Subsection 2.1)
            //       Paragraph
            //     H3 (Subsection 2.2)
            //       Paragraph
            //       H4 (Deep Subsection 2.2.1)
            //         Paragraph
            // ====================================================================================

            // ------------------------------------------------------------------------------------
            // H1 (Main Heading)
            // In the PDF logical structure tree (StructTreeRoot), H1 is a top-level heading.
            // Leaving Parent unassigned attaches this element directly under Document root.
            // ------------------------------------------------------------------------------------
            PdfStructureElement h1Tag = new PdfStructureElement(PdfTagType.HeadingLevel1)
            {
                Title = "Main Heading (H1)"
            };

            PdfTextElement h1Element = new PdfTextElement("H1: Document Accessibility and Semantic Heading Architecture", h1Font, headingBrush)
            {
                PdfTag = h1Tag
            };
            PdfLayoutResult result = h1Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 12;

            // ====================================================================================
            // SECTION 1 (H2)
            // ====================================================================================

            // H2 Section 1: Attached directly under Document root (or top-level section)
            PdfStructureElement h2Section1Tag = new PdfStructureElement(PdfTagType.HeadingLevel2)
            {
                Title = "Section 1 Heading (H2)"
            };

            PdfTextElement h2Section1Element = new PdfTextElement("H2: Section 1 - Core Web Accessibility Principles", h2Font, headingBrush)
            {
                PdfTag = h2Section1Tag
            };
            result = h2Section1Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Section 1 (H2) - Parent set to h2Section1Tag
            PdfStructureElement pSection1Tag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Section 1 (H2)",
                Parent = h2Section1Tag // Parent-child relationship: H2 (Section 1) -> Paragraph
            };

            PdfTextElement pSection1Element = new PdfTextElement(
                "Accessible digital documents rely on semantic structure to convey visual hierarchy and reading order to assistive technologies.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSection1Tag
            };
            result = pSection1Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 8;

            // Subsection 1.1 (H3) - Parent set to h2Section1Tag
            PdfStructureElement h3Sec1Sub1Tag = new PdfStructureElement(PdfTagType.HeadingLevel3)
            {
                Title = "Subsection 1.1 Heading (H3)",
                Parent = h2Section1Tag // Parent-child relationship: H2 (Section 1) -> H3 (Subsection 1.1)
            };

            PdfTextElement h3Sec1Sub1Element = new PdfTextElement("H3: Subsection 1.1 - Perceivable Information Structure", h3Font, headingBrush)
            {
                PdfTag = h3Sec1Sub1Tag
            };
            result = h3Sec1Sub1Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Subsection 1.1 (H3) - Parent set to h3Sec1Sub1Tag
            PdfStructureElement pSec1Sub1Tag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Subsection 1.1 (H3)",
                Parent = h3Sec1Sub1Tag // Parent-child relationship: H3 (Subsection 1.1) -> Paragraph
            };

            PdfTextElement pSec1Sub1Element = new PdfTextElement(
                "Users must be able to comprehend presented information through text alternatives and structured outlines.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSec1Sub1Tag
            };
            result = pSec1Sub1Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 8;

            // Subsection 1.2 (H3) - Parent set to h2Section1Tag
            PdfStructureElement h3Sec1Sub2Tag = new PdfStructureElement(PdfTagType.HeadingLevel3)
            {
                Title = "Subsection 1.2 Heading (H3)",
                Parent = h2Section1Tag // Parent-child relationship: H2 (Section 1) -> H3 (Subsection 1.2)
            };

            PdfTextElement h3Sec1Sub2Element = new PdfTextElement("H3: Subsection 1.2 - Operable Navigation Architecture", h3Font, headingBrush)
            {
                PdfTag = h3Sec1Sub2Tag
            };
            result = h3Sec1Sub2Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Subsection 1.2 (H3) - Parent set to h3Sec1Sub2Tag
            PdfStructureElement pSec1Sub2Tag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Subsection 1.2 (H3)",
                Parent = h3Sec1Sub2Tag // Parent-child relationship: H3 (Subsection 1.2) -> Paragraph
            };

            PdfTextElement pSec1Sub2Element = new PdfTextElement(
                "Heading outlines allow keyboard and screen-reader users to jump efficiently across document sections.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSec1Sub2Tag
            };
            result = pSec1Sub2Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 8;

            // Deep Subsection 1.2.1 (H4) - Parent set to h3Sec1Sub2Tag
            PdfStructureElement h4Sec1Sub2DeepTag = new PdfStructureElement(PdfTagType.HeadingLevel4)
            {
                Title = "Deep Subsection 1.2.1 Heading (H4)",
                Parent = h3Sec1Sub2Tag // Parent-child relationship: H3 (Subsection 1.2) -> H4 (Deep Subsection)
            };

            PdfTextElement h4Sec1Sub2DeepElement = new PdfTextElement("H4: Deep Subsection 1.2.1 - Skip Navigation Keys", h4Font, headingBrush)
            {
                PdfTag = h4Sec1Sub2DeepTag
            };
            result = h4Sec1Sub2DeepElement.Draw(page, new RectangleF(30, yPos, pageWidth - 30, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Deep Subsection 1.2.1 (H4) - Parent set to h4Sec1Sub2DeepTag
            PdfStructureElement pSec1Sub2DeepTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Deep Subsection 1.2.1 (H4)",
                Parent = h4Sec1Sub2DeepTag // Parent-child relationship: H4 (Deep Subsection) -> Paragraph
            };

            PdfTextElement pSec1Sub2DeepElement = new PdfTextElement(
                "Assistive tools use H4 structures for granular in-page skipping without losing broader section context.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSec1Sub2DeepTag
            };
            result = pSec1Sub2DeepElement.Draw(page, new RectangleF(30, yPos, pageWidth - 30, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 14;

            // ====================================================================================
            // SECTION 2 (H2)
            // ====================================================================================

            // H2 Section 2: Second section heading attached at document root
            PdfStructureElement h2Section2Tag = new PdfStructureElement(PdfTagType.HeadingLevel2)
            {
                Title = "Section 2 Heading (H2)"
            };

            PdfTextElement h2Section2Element = new PdfTextElement("H2: Section 2 - PDF/UA Tagging and Validation", h2Font, headingBrush)
            {
                PdfTag = h2Section2Tag
            };
            result = h2Section2Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Section 2 (H2) - Parent set to h2Section2Tag
            PdfStructureElement pSection2Tag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Section 2 (H2)",
                Parent = h2Section2Tag // Parent-child relationship: H2 (Section 2) -> Paragraph
            };

            PdfTextElement pSection2Element = new PdfTextElement(
                "PDF/UA-1 mandates marked content dictionaries and logical structure trees to guarantee accessible parsing.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSection2Tag
            };
            result = pSection2Element.Draw(page, new RectangleF(0, yPos, pageWidth, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 8;

            // Subsection 2.1 (H3) - Parent set to h2Section2Tag
            PdfStructureElement h3Sec2Sub1Tag = new PdfStructureElement(PdfTagType.HeadingLevel3)
            {
                Title = "Subsection 2.1 Heading (H3)",
                Parent = h2Section2Tag // Parent-child relationship: H2 (Section 2) -> H3 (Subsection 2.1)
            };

            PdfTextElement h3Sec2Sub1Element = new PdfTextElement("H3: Subsection 2.1 - Logical Structure Tree Construction", h3Font, headingBrush)
            {
                PdfTag = h3Sec2Sub1Tag
            };
            result = h3Sec2Sub1Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Subsection 2.1 (H3) - Parent set to h3Sec2Sub1Tag
            PdfStructureElement pSec2Sub1Tag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Subsection 2.1 (H3)",
                Parent = h3Sec2Sub1Tag // Parent-child relationship: H3 (Subsection 2.1) -> Paragraph
            };

            PdfTextElement pSec2Sub1Element = new PdfTextElement(
                "The StructTreeRoot references tagged elements, preserving parent-child relations across pages.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSec2Sub1Tag
            };
            result = pSec2Sub1Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 8;

            // Subsection 2.2 (H3) - Parent set to h2Section2Tag
            PdfStructureElement h3Sec2Sub2Tag = new PdfStructureElement(PdfTagType.HeadingLevel3)
            {
                Title = "Subsection 2.2 Heading (H3)",
                Parent = h2Section2Tag // Parent-child relationship: H2 (Section 2) -> H3 (Subsection 2.2)
            };

            PdfTextElement h3Sec2Sub2Element = new PdfTextElement("H3: Subsection 2.2 - Compliance Checkers and Verification", h3Font, headingBrush)
            {
                PdfTag = h3Sec2Sub2Tag
            };
            result = h3Sec2Sub2Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Subsection 2.2 (H3) - Parent set to h3Sec2Sub2Tag
            PdfStructureElement pSec2Sub2Tag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Subsection 2.2 (H3)",
                Parent = h3Sec2Sub2Tag // Parent-child relationship: H3 (Subsection 2.2) -> Paragraph
            };

            PdfTextElement pSec2Sub2Element = new PdfTextElement(
                "Accessibility engines verify that heading depths do not skip levels and remain properly enclosed in parent containers.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSec2Sub2Tag
            };
            result = pSec2Sub2Element.Draw(page, new RectangleF(15, yPos, pageWidth - 15, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 8;

            // Deep Subsection 2.2.1 (H4) - Parent set to h3Sec2Sub2Tag
            PdfStructureElement h4Sec2Sub2DeepTag = new PdfStructureElement(PdfTagType.HeadingLevel4)
            {
                Title = "Deep Subsection 2.2.1 Heading (H4)",
                Parent = h3Sec2Sub2Tag // Parent-child relationship: H3 (Subsection 2.2) -> H4 (Deep Subsection)
            };

            PdfTextElement h4Sec2Sub2DeepElement = new PdfTextElement("H4: Deep Subsection 2.2.1 - Automated Validation Checkers", h4Font, headingBrush)
            {
                PdfTag = h4Sec2Sub2DeepTag
            };
            result = h4Sec2Sub2DeepElement.Draw(page, new RectangleF(30, yPos, pageWidth - 30, 50), layoutFormat);
            yPos = result.Bounds.Bottom + 4;

            // Paragraph under Deep Subsection 2.2.1 (H4) - Parent set to h4Sec2Sub2DeepTag
            PdfStructureElement pSec2Sub2DeepTag = new PdfStructureElement(PdfTagType.Paragraph)
            {
                Title = "Paragraph under Deep Subsection 2.2.1 (H4)",
                Parent = h4Sec2Sub2DeepTag // Parent-child relationship: H4 (Deep Subsection) -> Paragraph
            };

            PdfTextElement pSec2Sub2DeepElement = new PdfTextElement(
                "Automated accessibility tools inspect each node in StructTreeRoot to validate tag order and nesting hierarchy.",
                bodyFont,
                bodyBrush
            )
            {
                PdfTag = pSec2Sub2DeepTag
            };
            result = pSec2Sub2DeepElement.Draw(page, new RectangleF(30, yPos, pageWidth - 30, 50), layoutFormat);

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
