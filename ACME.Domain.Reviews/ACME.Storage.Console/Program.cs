using Azure.Storage.Blobs;

namespace ACME.Storage.Console2;

internal class Program
{
    const string constr = "DefaultEndpointsProtocol=https;AccountName=psgestoord;AccountKey=uUZSqsnjzxLCBkTqbE6lYvI1oSF01sM1TrU1qezoMtzMFV3TQK1jWvG9+V1BFH7PK5g1pnE//1vp+ASt0v4DOw==;EndpointSuffix=core.windows.net";
    static async Task Main(string[] args)
    {
        var blobServiceClient = new BlobServiceClient(constr);
        var container = blobServiceClient.GetBlobContainerClient("bak");
        var blobClient = container.GetBlobClient("chambord.jpg");
       // await blobClient.DownloadToAsync(@"E:\Vakantiewoning.jpg");

        var bc = container.GetBlobClient("inbrekers.jpg");
        
        await bc.UploadAsync(@"E:\Vakantiewoning.jpg");

        Console.WriteLine( "Klaar!");
        Console.ReadLine();
    }
}
