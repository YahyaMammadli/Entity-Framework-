
namespace OlympicApp.Models;

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int OlympiadId { get; set; }
    public int SportId { get; set; }
    public DateTime? Date { get; set; } = DateTime.Now;

    public Olympiad Olympiad { get; set; } = null!;
    public Sport Sport { get; set; } = null!;


    public ICollection<Result> Results { get; set; } = new List<Result>();
}