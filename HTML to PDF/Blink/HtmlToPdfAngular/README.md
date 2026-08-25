# HTML to PDF Conversion Sample

This sample demonstrates how to convert HTML content to PDF in an Angular application using the Syncfusion .NET PDF Library with an ASP.NET Core Web API backend.

## Running the Sample

### Run the Backend Service

1. Open the **HtmlToPdfAPI** project.
2. Restore the NuGet packages.
3. Run the Web API project.

```bash
dotnet restore
dotnet run
```

### Run the Angular Application

1. Open the **HtmlToPdfAngular** project.
2. Install the required npm packages.

```bash
npm install
```

3. Start the Angular application.

```bash
npm start
```

or

```bash
ng serve
```

### Access the Application

Open the browser and navigate to:

```text
http://localhost:4200
```

Generate the PDF from the Angular application. The HTML content will be sent to the ASP.NET Core Web API, converted to PDF, and returned to the client for download or viewing.

## References

### Web API User Guide

https://help.syncfusion.com/document-processing/pdf/conversions/html-to-pdf/net/convert-html-to-pdf-in-web-api

### Knowledge Base Article

https://support.syncfusion.com/kb/article/10049/how-to-convert-html-to-pdf-using-web-api-in-net

### FT Page

https://www.syncfusion.com/document-sdk/net-pdf-library/html-to-pdf

