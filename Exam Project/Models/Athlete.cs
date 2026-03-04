using System.ComponentModel.DataAnnotations;

namespace OlympicApp.Models;

public class Athlete
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Surname { get; set; } = string.Empty;


    public int CountryId { get; set; }



    public DateTime BirthDate { get; set; } = DateTime.Now;
    public string? PhotoPath { get; set; }

    public Country Country { get; set; } = null!;
    
    public ICollection<Result> Results { get; set; } = Enumerable.Empty<Result>().ToList();
}