

using OlympicApp.Enums;

namespace OlympicApp.Models;

public class Olympiad
{
    public int Id { get; set; }
    public int Year { get; set; }
    public Season Season { get; set; }


    public int CountryId { get; set; }


    public int CityId { get; set; }
    public Country Country { get; set; } = null!;


    public City City { get; set; } = null!;

    public ICollection<Competition> Competitions { get; set; } = Enumerable.Empty<Competition>().ToList();
}