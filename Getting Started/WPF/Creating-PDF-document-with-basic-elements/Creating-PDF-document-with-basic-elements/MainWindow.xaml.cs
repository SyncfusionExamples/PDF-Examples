using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Creating_PDF_document_with_basic_elements
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string shipName, address, shipCity, shipCountry;
        float total = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePDF(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
            document.PageSettings.Margins.All = 50;

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Create a text element with the text and font.
            PdfTextElement element = new PdfTextElement("Northwind Traders\n67, rue des Cinquante Otages,\nElgin,\nUnites States.");
            element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));

            //Draw the image to PDF page with specified size.  
            PdfImage img = new PdfBitmap("../../Data/logo.jpg");
            graphics.DrawImage(img, new RectangleF(graphics.ClientSize.Width - 200, result.Bounds.Y, 190, 45));
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(0, result.Bounds.Bottom + 40, graphics.ClientSize.Width, 30));

            //Create a text element with the text and font.
            element = new PdfTextElement("INVOICE", subHeadingFont);
            element.Brush = PdfBrushes.White;
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 48));
            string currentDate = "DATE " + DateTime.Now.ToString("MM/dd/yyyy");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y));

            //Create a text element and draw it to PDF page.
            element = new PdfTextElement("BILL TO ", new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, result.Bounds.Bottom + 3), new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3));

            //Get products list to create invoice 
            IEnumerable<CustOrders> products = Orders.GetProducts();

            List<CustOrders> list = new List<CustOrders>();
            foreach (CustOrders cust in products)
            {
                list.Add(cust);
            }
            var reducedList = list.Select(f => new { f.ProductID, f.ProductName, f.Quantity, f.UnitPrice, f.Discount, f.Price }).ToList();

            //Get the shipping address details. 
            IEnumerable<ShipDetails> shipDetails = Orders.GetShipDetails();
            GetShipDetails(shipDetails);

            //Create a text element and draw it to PDF page.
            element = new PdfTextElement(shipName, new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
            element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 5, graphics.ClientSize.Width / 2, 100));

            //Create a text element and draw it to PDF page.
            element = new PdfTextElement(string.Format("{0}, {1}, {2}", address, shipCity, shipCountry), new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
            element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 3, graphics.ClientSize.Width / 2, 100));

            //Create a PDF grid with product details.
            PdfGrid grid = new PdfGrid();
            grid.DataSource = reducedList;

            //Initialize PdfGridCellStyle and set border color.
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));

            //Initialize PdfGridCellStyle and set header style.
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

            PdfGridRow header = grid.Headers[0];
            for (int i = 0; i < header.Cells.Count; i++)
            {
                if (i == 0 || i == 1)
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                else
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }
            header.ApplyStyle(headerStyle);

            foreach (PdfGridRow row in grid.Rows)
            {
                row.ApplyStyle(cellStyle);
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    //Create and customize the string formats
                    PdfGridCell cell = row.Cells[i];
                    if (i == 1)
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    else if (i == 0)
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                    else
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

                    if (i > 2)
                    {
                        float val = float.MinValue;
                        float.TryParse(cell.Value.ToString(), out val);
                        cell.Value = '$' + val.ToString("0.00");
                    }
                }
            }

            grid.Columns[0].Width = 100;
            grid.Columns[1].Width = 200;

            //Set properties to paginate the grid.
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;

            //Draw grid to the page of PDF document.
            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);
            float pos = 0.0f;
            for (int i = 0; i < grid.Columns.Count - 1; i++)
                pos += grid.Columns[i].Width;

            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f);

            GetTotalPrice(products);

            gridResult.Page.Graphics.DrawString("Total Due", font, new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(new PointF(pos, gridResult.Bounds.Bottom + 20), new SizeF(grid.Columns[3].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));
            gridResult.Page.Graphics.DrawString("Thank you for your business!", new PdfStandardFont(PdfFontFamily.TimesRoman, 12), new PdfSolidBrush(new PdfColor(89, 89, 93)), new PointF(pos - 55, gridResult.Bounds.Bottom + 60));
            pos += grid.Columns[4].Width;
            gridResult.Page.Graphics.DrawString('$' + string.Format("{0:N2}", total), font, new PdfSolidBrush(new PdfColor(131, 130, 136)), new RectangleF(new PointF(pos, gridResult.Bounds.Bottom + 20), new SizeF(grid.Columns[4].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));

            //Save the PDF document. 
            document.Save("InvoicePDF.pdf");

            //Close the document. 
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer.
            Process.Start("InvoicePDF.pdf");
        }

        #region Helper Methods
        public void GetTotalPrice(IEnumerable<CustOrders> orders)
        {
            foreach (CustOrders s in orders)
            {
                total += s.Price;
            }
        }

        public void GetShipDetails(IEnumerable<ShipDetails> details)
        {
            foreach (ShipDetails s in details)
            {
                shipCity = s.ShipCity;
                shipCountry = s.ShipCountry;
                shipName = s.ShipName;
                address = s.ShipAddress;
            }
        }
        #endregion
    }

    #region Helper Classes
    internal sealed class Orders
    {
        public static IEnumerable<CustOrders> GetProducts()
        {
            Stream xmlStream = new FileStream("../../Data/Products.xml", FileMode.Open, FileAccess.Read);

            using (StreamReader reader = new StreamReader(xmlStream, true))
            {
                string data = reader.ReadToEnd();

                data = data.Replace("xmlns=\"http://www.tempuri.org/DataSet1.xsd\"", "");

                return XElement.Parse(data)
                     .Elements()
                     .Select(c => new CustOrders
                     {
                         ProductID = c.Element("ProductID").Value,
                         ProductName = c.Element("ProductName").Value,
                         Quantity = c.Element("Quantity").Value,
                         UnitPrice = c.Element("UnitPrice").Value,
                         Discount = c.Element("Discount").Value,
                         Price = (float)(Convert.ToDouble(c.Element("Quantity").Value) * Convert.ToDouble(c.Element("UnitPrice").Value)),
                         OrderID = c.Element("OrderID").Value,
                     });
            }
        }

        public static IEnumerable<ShipDetails> GetShipDetails()
        {
            Stream xmlStream = new FileStream("../../Data/Products.xml", FileMode.Open, FileAccess.Read);

            using (StreamReader reader = new StreamReader(xmlStream, true))
            {
                string data = reader.ReadToEnd();


                data = data.Replace("xmlns=\"http://www.tempuri.org/DataSet1.xsd\"", "");

                return XElement.Parse(data)
                    .Elements()
                    .Select(c => new ShipDetails
                    {
                        ShipName = c.Element("ShipName").Value,
                        ShipAddress = c.Element("ShipAddress").Value,
                        ShipCity = c.Element("ShipCity").Value,
                        ShipCountry = c.Element("ShipCountry").Value,
                    });
            }
        }
    }
    public class CustOrders
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public float Price { get; set; }
        public string OrderID { get; set; }

    }
    public class ShipDetails
    {
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
    #endregion
}