using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class SportService : ISportService
{
    private readonly ISportRepository _sportRepository;




    public SportService(ISportRepository sportRepository)
    {
        _sportRepository = sportRepository;
    }

    public Sport? GetSportById(int id)
    {
        try
        {
            return _sportRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Sport> GetAllSports()
    {
        try
        {
            return _sportRepository.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddSport(Sport sport)
    {
        try
        {
            _sportRepository.Add(sport);


            Console.Write("Sport added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateSport(Sport sport)
    {
        try
        {
            _sportRepository.Update(sport);


            Console.Write("Sport updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteSport(int id)
    {
        try
        {
            _sportRepository.Delete(id);


            Console.Write("Sport deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}