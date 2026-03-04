using OlympicApp.Models;

namespace OlympicApp.Repositories.Abstract;

public interface ISportRepository
{
    Sport? GetById(int id);
    IQueryable<Sport> GetAll();
    void Add(Sport sport);
    void Update(Sport sport);
    void Delete(int id);
}