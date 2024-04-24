
namespace ACME.Clients.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://ps-acme-review.azurewebsites.net");

        var response = await client.GetAsync("reviews");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(data);
        }

        System.Console.ReadLine();
    }
}
