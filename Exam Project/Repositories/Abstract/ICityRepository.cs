using OlympicApp.Models;

namespace OlympicApp.Repositories.Abstract;

public interface ICityRepository
{
    City? GetById(int id);
    IQueryable<City> GetAll();
    IQueryable<City> GetCitiesByCountry(int countryId);
    void Add(City city);
    void Update(City city);
    void Delete(int id);
}