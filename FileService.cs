using System.IO;
using System.Text;

public static class FileService
{
    public static void WriteToFile(List<string> lines)
    {
        string filePath = "PlanetsWithMoons.txt";
        File.WriteAllLines(filePath, lines, Encoding.UTF8);
        Console.WriteLine($"Data written to {filePath}");
    }
}

var outputLines = planetsWithMoons.Select(p => $"{p.PlanetName}: {p.AvgMoonTemp:F2}°C").ToList();
FileService.WriteToFile(outputLines);