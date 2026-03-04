using OlympicApp.Models;

namespace OlympicApp.Services.Abstract;

public interface IResultService
{
    Result? GetResultById(int id);
    IEnumerable<Result> GetAllResults();
    void AddResult(Result result);
    void UpdateResult(Result result);
    void DeleteResult(int id);
}