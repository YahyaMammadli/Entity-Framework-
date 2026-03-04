using OlympicApp.Models;


namespace OlympicApp.Repositories.Abstract;

public interface IAthleteRepository
{
    Athlete? GetById(int id);
    IQueryable<Athlete> GetAll();
    IQueryable<Athlete> GetAthletesByCountry(string country);
    void Add(Athlete athlete);
    void Update(Athlete athlete);
    void Delete(int id);
}