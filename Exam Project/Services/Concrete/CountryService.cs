using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public Country? GetCountryById(int id)
    {
        try
        {
            return _countryRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Country> GetAllCountries()
    {
        try
        {
            return _countryRepository.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddCountry(Country country)
    {
        try
        {
            _countryRepository.Add(country);

            Console.Write("Country added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateCountry(Country country)
    {
        try
        {
            _countryRepository.Update(country);

            Console.Write("Country updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteCountry(int id)
    {
        try
        {
            _countryRepository.Delete(id);

            Console.Write("Country deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}