using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiService
{
    private static readonly HttpClient client = new HttpClient();
    private const string ApiUrl = "https://api.le-systeme-solaire.net/rest/bodies/";

    public static async Task<List<CelestialBody>> FetchBodiesAsync()
    {
        try
        {
            Console.WriteLine("Fetching data from API...");
            var response = await client.GetStringAsync(ApiUrl);

            var data = JsonSerializer.Deserialize<ApiResponse>(response);
            return data?.Bodies ?? new List<CelestialBody>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
            return new List<CelestialBody>();
        }
    }
}
