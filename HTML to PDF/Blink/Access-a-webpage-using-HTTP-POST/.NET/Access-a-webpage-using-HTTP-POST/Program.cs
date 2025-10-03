﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings. 
BlinkConverterSettings settings = new BlinkConverterSettings();
//Add HTTP post parameters to HttpPostFields.
settings.HttpPostFields.Add("firstName", "Andrew");
settings.HttpPostFields.Add("lastName", "Fuller");

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = settings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.example.com");

//Save the PDF document 
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);
