using OlympicApp.Models;

namespace OlympicApp.DTO;

public class MedalistDto
{
    public string Sport { get; set; } = string.Empty;
    public string AthleteName { get; set; } = string.Empty;
    public Country Country { get; set; } = null!;


    public string Medal { get; set; } = string.Empty; 
}