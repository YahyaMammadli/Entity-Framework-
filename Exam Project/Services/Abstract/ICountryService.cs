using OlympicApp.Models;

namespace OlympicApp.Services.Abstract;

public interface ICountryService
{
    Country? GetCountryById(int id);
    IEnumerable<Country> GetAllCountries();
    void AddCountry(Country country);
    void UpdateCountry(Country country);
    void DeleteCountry(int id);
}