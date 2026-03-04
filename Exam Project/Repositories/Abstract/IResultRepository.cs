using OlympicApp.Models;

namespace OlympicApp.Repositories.Abstract;

public interface IResultRepository
{
    Result? GetById(int id);
    IQueryable<Result> GetAll();
    IQueryable<Result> GetResultsWithDetails();
    void Add(Result result);
    void Update(Result result);
    void Delete(int id);
}