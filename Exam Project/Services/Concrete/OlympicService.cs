
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class OlympiadService : IOlympiadService
{
    private readonly IOlympiadRepository _olympiadRepository;

    public OlympiadService(IOlympiadRepository olympiadRepository)
    {
        _olympiadRepository = olympiadRepository;
    }

    public Olympiad? GetOlympiadById(int id)
    {
        try
        {
            return _olympiadRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Olympiad> GetAllOlympiads()
    {
        try
        {
            return _olympiadRepository.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddOlympiad(Olympiad olympiad)
    {
        try
        {
            _olympiadRepository.Add(olympiad);

            Console.Write("Olympiad added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateOlympiad(Olympiad olympiad)
    {
        try
        {
            _olympiadRepository.Update(olympiad);

            Console.Write("Olympiad updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteOlympiad(int id)
    {
        try
        {
            _olympiadRepository.Delete(id);

            Console.Write("Olympiad deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }

    }


}