using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Fill_form_in_a_PDF_document
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create the file open picker.
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".pdf");

            //Browse and chose the file.
            StorageFile file = await picker.PickSingleFileAsync();

            //Creates an empty PDF loaded document instance.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument();

            //Loads or opens an existing PDF document through Open method of PdfLoadedDocument class.
            await loadedDocument.OpenAsync(file);

            //Loads the form
            PdfLoadedForm form = loadedDocument.Form;

            //Fills the textbox field by using index
            (form.Fields[0] as PdfLoadedTextBoxField).Text = "John";

            //Fills the textbox fields by using field name
            (form.Fields["Last Name"] as PdfLoadedTextBoxField).Text = "Doe";
            (form.Fields["Address"] as PdfLoadedTextBoxField).Text = " John Doe \n 123 Main St \n Anytown, USA";

            //Loads the radio button group
            PdfLoadedRadioButtonItemCollection radioButtonCollection = (form.Fields["Gender"] as PdfLoadedRadioButtonListField).Items;

            //Checks the 'Male' option
            radioButtonCollection[0].Checked = true;

            //Loads the radio button group
            PdfLoadedRadioButtonItemCollection radioButtonCollection1 = (form.Fields["Occupation"] as PdfLoadedRadioButtonListField).Items;

            //Checks the 'Male' option
            radioButtonCollection1[0].Checked = true;

            //Save the PDF document to stream.
            MemoryStream stream = new MemoryStream();
            await loadedDocument.SaveAsync(stream);
            
            //Close the document.
            loadedDocument.Close(true);
            
            //Save the stream as PDF document file in local machine. Refer to PDF/UWP section for respected code samples.
            Save(stream, "output.pdf");
        }

        #region Helper Methods

        /// <summary>
        /// Save the stream as a physical file and open file for viewing. 
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
