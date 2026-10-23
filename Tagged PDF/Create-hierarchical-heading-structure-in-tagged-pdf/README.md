# Create Hierarchical Heading Structure in Tagged PDF

This example demonstrates how to create an accessible **Tagged PDF document** with a hierarchical heading structure (`H1` to `H5`) where `H3`, `H4`, and `H5` are nested under `H2` in the document structure tree using the **Syncfusion PDF Library**.

## Key Features

- **Document Structure Tree**: Implements a standard PDF StructTreeRoot with semantic accessibility tags.
- **Hierarchical Heading Nesting**: Establishes parent-child relationships using `PdfStructureElement.Parent` to nest `H3`, `H4`, and `H5` under `H2`.
- **Sample Content**: Adds descriptive paragraph content (`PdfTagType.Paragraph`) under each heading.
- **Accessibility Compliance**: Enables `document.ViewerPreferences.DisplayTitle = true` and standard tagged PDF structures conforming to PDF accessibility guidelines (WCAG / PDF/UA).

## Establishing Parent-Child Relationships

In Syncfusion PDF Library:
1. When a `PdfStructureElement` is created without setting `Parent`, it attaches directly under the document root.
2. Setting `subHeadingTag.Parent = parentHeadingTag;` before saving assigns the element as a child node of `parentHeadingTag` in the PDF StructTreeRoot.
3. Content paragraphs under headings can similarly have their `Parent` property assigned to group content logically within its section.

```csharp
// Top-level heading
PdfStructureElement h2Tag = new PdfStructureElement(PdfTagType.HeadingLevel2);

// Subsections nested under H2
PdfStructureElement h3Tag = new PdfStructureElement(PdfTagType.HeadingLevel3);
h3Tag.Parent = h2Tag; // Sets H2 as the parent of H3

PdfStructureElement h4Tag = new PdfStructureElement(PdfTagType.HeadingLevel4);
h4Tag.Parent = h2Tag; // Sets H2 as the parent of H4

PdfStructureElement h5Tag = new PdfStructureElement(PdfTagType.HeadingLevel5);
h5Tag.Parent = h2Tag; // Sets H2 as the parent of H5
```

## Documentation Reference

For more details on working with Tagged PDFs in Syncfusion, see the [Syncfusion Working with Tagged PDF Documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-tagged-pdf).
