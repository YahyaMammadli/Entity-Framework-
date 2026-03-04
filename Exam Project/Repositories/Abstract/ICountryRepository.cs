using OlympicApp.Models;

namespace OlympicApp.Repositories.Abstract;

public interface ICountryRepository
{
    Country? GetById(int id);
    IQueryable<Country> GetAll();
    void Add(Country country);
    void Update(Country country);
    void Delete(int id);
}