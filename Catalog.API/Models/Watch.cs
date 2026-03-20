namespace Catalog.API.Models;

public class Watch
{
    public Guid Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Movement { get; set; } = "Quartz"; // Ex: Automatic, Quartz
}
