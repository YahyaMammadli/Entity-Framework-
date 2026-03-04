using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class AthleteService : IAthleteService
{

    private readonly IAthleteRepository _athleteRepository;

    public AthleteService(IAthleteRepository athleteRepository)
    {
        _athleteRepository = athleteRepository;
    }

    public Athlete? GetAthleteById(int id)
    {
        try
        {
            return _athleteRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Athlete> GetAllAthletes()
    {
        try
        {
            return _athleteRepository.GetAll().ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddAthlete(Athlete athlete)
    {
        try
        {
            _athleteRepository.Add(athlete);
            Console.Write("Athlete added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateAthlete(Athlete athlete)
    {
        try
        {
            _athleteRepository.Update(athlete);

            Console.Write("Athlete updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteAthlete(int id)
    {
        try
        {
            _athleteRepository.Delete(id);

            Console.Write("Athlete deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}