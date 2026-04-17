using Syncfusion.SmartTableExtractor;
using System;
using System.Collections.Generic;
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

namespace Extract_Table_Data
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void ExtractButton_Click(object sender, RoutedEventArgs e)
		{
			// Open the input PDF file as a stream.
			using (FileStream stream = new FileStream(@"Data\Input.pdf", FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Smart Table Extractor.
				TableExtractor extractor = new TableExtractor();
				// Extract table data from the PDF document as JSON string.
				string data = extractor.ExtractTableAsJson(stream);
				// Save the extracted JSON data into an output file.
				File.WriteAllText(@"Output\Output.json", data, Encoding.UTF8);
			}
		}
	}
}
