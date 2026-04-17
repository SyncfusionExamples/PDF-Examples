using Syncfusion.SmartFormRecognizer;

namespace AsyncVariantsWithCancellationToken
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Read the input PDF file as stream.
			using FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.Read);
			// Initialize the Form Recognizer.
			FormRecognizer recognizer = new FormRecognizer();
			// Create a cancellation token that cancels after 5 seconds.
			using CancellationTokenSource cts = new CancellationTokenSource();
			cts.CancelAfter(TimeSpan.FromSeconds(5));
			CancellationToken token = cts.Token;

			// Recognize the form and get the output as PDF stream asynchronously.
			using Stream resultStream = await recognizer.RecognizeFormAsPdfStreamAsync(inputStream, token);

			// Save the output PDF stream to file.
			using FileStream fileStream = File.Create(Path.GetFullPath(@"Output\Output.pdf"));
			await resultStream.CopyToAsync(fileStream, token);
		}
	}
}
