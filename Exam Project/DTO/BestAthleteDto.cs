using OlympicApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OlympicApp.DTO;

public class BestAthleteDto
{
    public int AthleteId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Surname { get; set; } = string.Empty;
    public Country Country { get; set; } = null!;

    public int GoldCount { get; set; }
}