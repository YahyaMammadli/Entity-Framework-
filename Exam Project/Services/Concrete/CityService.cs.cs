using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public City? GetCityById(int id)
    {
        try
        {
            return _cityRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<City> GetAllCities()
    {
        try
        {
            return _cityRepository.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<City> GetCitiesByCountry(int countryId)
    {
        try
        {
            return _cityRepository.GetCitiesByCountry(countryId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddCity(City city)
    {
        try
        {
            _cityRepository.Add(city);
            Console.Write("City added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateCity(City city)
    {
        try
        {
            _cityRepository.Update(city);

            Console.Write("City updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    
    }

    public void DeleteCity(int id)
    {
        try
        {
            _cityRepository.Delete(id);

            Console.Write("City deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}