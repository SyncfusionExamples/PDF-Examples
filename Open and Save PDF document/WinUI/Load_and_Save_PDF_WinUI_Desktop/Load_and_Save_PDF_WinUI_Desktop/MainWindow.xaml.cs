// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Syncfusion.Pdf.Parsing;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Load_and_Save_PDF_WinUI_Desktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            button.Content = "Clicked";
            //Open an existing PDF document.
            Assembly assembly = typeof(MainWindow).GetTypeInfo().Assembly;
            string basePath = "Load_and_Save_PDF_WinUI_Desktop.Assets.";
            Stream inputStream = assembly.GetManifestResourceStream(basePath + "Input.pdf");
            PdfLoadedDocument document = new PdfLoadedDocument(inputStream);
            //Get the first page from a document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

            //Add values to the list.
            List<object> data = new List<object>();
            Object row1 = new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" };
            Object row2 = new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" };
            Object row3 = new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);

            //Add list to IEnumerable.
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Apply built-in table style.
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);
            //Draw the grid to the page of PDF document.
            pdfGrid.Draw(graphics, new RectangleF(40, 400, page.Size.Width - 80, 0));

            //Give file path
            string filePath = "D://Result.pdf"; 
            //Create a FileStream to save the PDF document.
            using (FileStream outputStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF file.
                document.Save(outputStream);
            }
          
        }
    }
}
