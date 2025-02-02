using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        // Fetch data from API
        var bodies = await ApiService.FetchBodiesAsync();

        // Filtering only planets with at least one moon
        var planetsWithMoons = bodies
            .Where(p => p.IsPlanet && p.Moons != null && p.Moons.Count > 0)
            .Select(p => new
            {
                PlanetName = p.Name,
                AvgMoonTemp = p.Moons
                              .Select(moon => bodies.FirstOrDefault(b => b.Id == moon.Id)?.AvgTemp ?? 0)
                              .Average()
            })
            .ToList();

        // Displaying the output
        Console.WriteLine("\nPlanets with Moons and their Average Moon Temperatures:");
        foreach (var planet in planetsWithMoons)
        {
            Console.WriteLine($"{planet.PlanetName}: {planet.AvgMoonTemp:F2}°C");
        }
    }
}
