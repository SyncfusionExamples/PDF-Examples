using Syncfusion.SmartDataExtractor;
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

namespace Extract_Data
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
			// Open the input PDF file as a stream (inline path).
			using (FileStream stream = new FileStream(@"Data\Input.pdf", FileMode.Open, FileAccess.Read))
			{
				// Initialize the Smart Data Extractor.
				DataExtractor extractor = new DataExtractor();
				// Extract form data as JSON.
				string data = extractor.ExtractDataAsJson(stream);
				// Save the extracted JSON data into an output file (inline path).
				File.WriteAllText(@"Output\Output.json", data, Encoding.UTF8);
			}
		}
	}
}
