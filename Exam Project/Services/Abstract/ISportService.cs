using OlympicApp.Models;


namespace OlympicApp.Services.Abstract;

public interface ISportService
{
    Sport? GetSportById(int id);
    IEnumerable<Sport> GetAllSports();
    void AddSport(Sport sport);
    void UpdateSport(Sport sport);
    void DeleteSport(int id);
}