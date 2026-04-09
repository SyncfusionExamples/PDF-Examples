using Syncfusion.SmartFormRecognizer;
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

namespace Recognize_Forms
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
			// Read the input PDF file as stream.
			using (FileStream inputStream = new FileStream(System.IO.Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Form Recognizer.
				FormRecognizer smartFormRecognizer = new FormRecognizer();
				// Recognize the form and get the output as JSON string.
				string outputJson = smartFormRecognizer.RecognizeFormAsJson(inputStream);
				// Save the output JSON to file.
				File.WriteAllText(System.IO.Path.GetFullPath(@"Output\Output.json"), outputJson, Encoding.UTF8);
			}
		}
	}
}
