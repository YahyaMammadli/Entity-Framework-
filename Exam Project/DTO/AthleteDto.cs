using OlympicApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OlympicApp.DTO;

public class AthleteDto
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Surname { get; set; } = string.Empty;
    public Country Country { get; set; } = null!;


    public DateTime BirthDate { get; set; } = DateTime.Now;
    public string? PhotoPath { get; set; }

}