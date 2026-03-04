using System.ComponentModel.DataAnnotations;

namespace OlympicApp.Models;

public class Sport
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    
    public ICollection<Competition> Competitions { get; set; } = new List<Competition>();
}