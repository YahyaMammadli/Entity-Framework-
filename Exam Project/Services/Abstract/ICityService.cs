using OlympicApp.Models;
using System.Collections.Generic;

namespace OlympicApp.Services.Abstract;

public interface ICityService
{
    City? GetCityById(int id);
    IEnumerable<City> GetAllCities();
    IEnumerable<City> GetCitiesByCountry(int countryId); 
    void AddCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int id);
}