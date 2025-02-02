public class CelestialBody
{
    public string Id { get; set; }        
    public string Name { get; set; }       
    public bool IsPlanet { get; set; }    
    public List<Moon> Moons { get; set; }  
    public double AvgTemp { get; set; }    
}

public class Moon
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double AvgTemp { get; set; }
}

// API response container
public class ApiResponse
{
    public List<CelestialBody> Bodies { get; set; }
}
