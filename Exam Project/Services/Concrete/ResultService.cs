using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;

namespace OlympicApp.Services.Concrete;

public class ResultService : IResultService
{
    private readonly IResultRepository _resultRepository;

    public ResultService(IResultRepository resultRepository)
    {
        _resultRepository = resultRepository;
    }

    public Result? GetResultById(int id)
    {
        try
        {
            return _resultRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Result> GetAllResults()
    {
        try
        {
            return _resultRepository.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddResult(Result result)
    {
        try
        {
            _resultRepository.Add(result);

            Console.Write("Result added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateResult(Result result)
    {
        try
        {
            _resultRepository.Update(result);


            Console.Write("Result updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteResult(int id)
    {
        try
        {
            _resultRepository.Delete(id);
            Console.Write("Result deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}