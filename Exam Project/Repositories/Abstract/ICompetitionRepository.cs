using OlympicApp.Models;

namespace OlympicApp.Repositories.Abstract;

public interface ICompetitionRepository
{
    Competition? GetById(int id);
    IQueryable<Competition> GetAll();
    void Add(Competition competition);
    void Update(Competition competition);
    void Delete(int id);
}