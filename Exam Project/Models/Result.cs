using OlympicApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace OlympicApp.Models;

public class Result
{
    public int Id { get; set; }
    public int AthleteId { get; set; }
    public int CompetitionId { get; set; }
    public Medal Medal { get; set; }
    [MaxLength(250)]
    public string? ResultDetails { get; set; }

    public Athlete Athlete { get; set; } = null!;
    public Competition Competition { get; set; } = null!;
}