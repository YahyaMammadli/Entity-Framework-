using OlympicApp.Models;


namespace OlympicApp.Services.Abstract;

public interface IAthleteService
{
    Athlete? GetAthleteById(int id);
    IEnumerable<Athlete> GetAllAthletes();
    void AddAthlete(Athlete athlete);
    void UpdateAthlete(Athlete athlete);
    void DeleteAthlete(int id);
}