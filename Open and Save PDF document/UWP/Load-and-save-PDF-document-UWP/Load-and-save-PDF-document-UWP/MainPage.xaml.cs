using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Syncfusion.Pdf.Graphics;
using System.Reflection.Metadata;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Load_and_save_PDF_document_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Load an existing PDF document.
            Stream docStream = typeof(MainPage).GetTypeInfo().Assembly.GetManifestResourceStream("Load_and_save_PDF_document_UWP.Assets.Input.pdf");
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
            //Load the page. 
            PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
            //Create graphics for the PDF page. 
            PdfGraphics graphics = loadedPage.Graphics;

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
            pdfGrid.Draw(graphics, new RectangleF(40, 400, loadedPage.Size.Width - 80, 0));

            //Create memory stream.
            MemoryStream ms = new MemoryStream();
            //Open the document in browser after saving it.
            loadedDocument.Save(ms);
            //Close the document.
            loadedDocument.Close(true);
            //Save the PDF document. 
            Save(ms, "Sample.pdf");
        }

        #region Helper Methods
        /// <summary>
        /// Save the stream to physical file and open the file for viewing. 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        public async void Save(Stream stream, string filename)
        {
            stream.Position = 0;

            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".pdf";
                savePicker.SuggestedFileName = "Sample";
                savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                stFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }
            if (stFile != null)
            {
                Windows.Storage.Streams.IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                Stream st = fileStream.AsStreamForWrite();
                st.SetLength(0);
                st.Write((stream as MemoryStream).ToArray(), 0, (int)stream.Length);
                st.Flush();
                st.Dispose();
                fileStream.Dispose();
                MessageDialog msgDialog = new MessageDialog("Do you want to view the Document?", "File created.");
                UICommand yesCmd = new UICommand("Yes");
                msgDialog.Commands.Add(yesCmd);
                UICommand noCmd = new UICommand("No");
                msgDialog.Commands.Add(noCmd);
                IUICommand cmd = await msgDialog.ShowAsync();
                if (cmd == yesCmd)
                {
                    // Launch the retrieved file 
                    bool success = await Windows.System.Launcher.LaunchFileAsync(stFile);
                }
            }
        }
        #endregion
    }
}
