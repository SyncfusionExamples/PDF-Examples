using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Newtonsoft.Json;
using System.IO;

//Create a new AmazonLambdaClient
AmazonLambdaClient client = new AmazonLambdaClient("awsaccessKeyID", "awsSecreteAccessKey", RegionEndpoint.USEast1);
//Create new InvokeRequest with published function name.
InvokeRequest invoke = new InvokeRequest
{
    FunctionName = "MyNewFunction", //Add your lambda function name here
    InvocationType = InvocationType.RequestResponse,
    Payload = "\"Test\""
};
//Get the InvokeResponse from client InvokeRequest
InvokeResponse response = await client.InvokeAsync(invoke);
//Read the response stream
var stream = new StreamReader(response.Payload);
//Deserialize the response stream
JsonReader reader = new JsonTextReader(stream);
JsonSerializer serializer = new JsonSerializer();
var responseText = serializer.Deserialize(reader);

//Convert Base64String into byte array
byte[] bytes = Convert.FromBase64String(responseText.ToString());

//Write the byte array into a file
FileStream fileStream = new FileStream("Sample.pdf", FileMode.Create);
fileStream.Write(bytes, 0, bytes.Length);
fileStream.Flush();
fileStream.Dispose();

System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = "Sample.pdf", UseShellExecute = true });