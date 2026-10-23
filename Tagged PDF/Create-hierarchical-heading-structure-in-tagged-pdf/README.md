# Create Hierarchical Heading Structure in Tagged PDF

This example demonstrates how to create an accessible **Tagged PDF document** with multiple hierarchical sections (`H1` to `H4` with nested paragraphs) using the **Syncfusion PDF Library**.

## Heading & Paragraph Hierarchy

The document structure tree implements the following accessible hierarchy:

```text
H1 (Main Heading)
  H2 (Section 1)
    Paragraph
    H3 (Subsection 1.1)
      Paragraph
    H3 (Subsection 1.2)
      Paragraph
      H4 (Deep Subsection 1.2.1)
        Paragraph
  H2 (Section 2)
    Paragraph
    H3 (Subsection 2.1)
      Paragraph
    H3 (Subsection 2.2)
      Paragraph
      H4 (Deep Subsection 2.2.1)
        Paragraph
```

## Key Features

- **Document Structure Tree**: Implements a standard PDF StructTreeRoot with semantic accessibility tags.
- **Hierarchical Heading & Content Nesting**: Establishes parent-child relationships using `PdfStructureElement.Parent` to nest subsections and paragraphs under their corresponding parent tags.
- **Sample Content**: Adds descriptive paragraph content (`PdfTagType.Paragraph`) nested under each heading level.
- **Accessibility Compliance**: Enables `document.ViewerPreferences.DisplayTitle = true` and standard tagged PDF structures conforming to PDF accessibility guidelines (WCAG / PDF/UA).

## Establishing Parent-Child Relationships

In Syncfusion PDF Library:
1. When a `PdfStructureElement` is created without setting `Parent`, it attaches directly under the document root (e.g. `H1` and top-level `H2` sections).
2. Setting `childElement.Parent = parentElement;` before saving assigns the element as a child node in the PDF StructTreeRoot:
   - Setting `h2Paragraph.Parent = h2Tag;` nests the paragraph under `H2`.
   - Setting `h3Tag.Parent = h2Tag;` nests `H3` under `H2`.
   - Setting `h3Paragraph.Parent = h3Tag;` nests the paragraph under `H3`.
   - Setting `h4Tag.Parent = h3Tag;` nests `H4` under `H3`.
   - Setting `h4Paragraph.Parent = h4Tag;` nests the paragraph under `H4`.

```csharp
// Section 1 Heading (H2)
PdfStructureElement h2Section1Tag = new PdfStructureElement(PdfTagType.HeadingLevel2);

// Paragraph under H2
PdfStructureElement pSection1Tag = new PdfStructureElement(PdfTagType.Paragraph)
{
    Parent = h2Section1Tag // Parent: H2
};

// Subsection 1.1 (H3)
PdfStructureElement h3Sec1Sub1Tag = new PdfStructureElement(PdfTagType.HeadingLevel3)
{
    Parent = h2Section1Tag // Parent: H2
};

// Paragraph under H3
PdfStructureElement pSec1Sub1Tag = new PdfStructureElement(PdfTagType.Paragraph)
{
    Parent = h3Sec1Sub1Tag // Parent: H3
};

// Deep Subsection 1.2.1 (H4)
PdfStructureElement h4Sec1Sub2DeepTag = new PdfStructureElement(PdfTagType.HeadingLevel4)
{
    Parent = h3Sec1Sub2Tag // Parent: H3
};

// Paragraph under H4
PdfStructureElement pSec1Sub2DeepTag = new PdfStructureElement(PdfTagType.Paragraph)
{
    Parent = h4Sec1Sub2DeepTag // Parent: H4
};
```

## Documentation Reference

For more details on working with Tagged PDFs in Syncfusion, see the [Syncfusion Working with Tagged PDF Documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-tagged-pdf).
