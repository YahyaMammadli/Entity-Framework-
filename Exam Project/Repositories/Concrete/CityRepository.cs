using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;



namespace OlympicApp.Repositories.Concrete;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }

    public City? GetById(int id)
    {
        try
        {
            return _context.Cities
                .Include(c => c.Country)
                .FirstOrDefault(c => c.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<City> GetAll()
    {
        try
        {
            return _context.Cities
                .Include(c => c.Country);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<City> GetCitiesByCountry(int countryId)
    {
        try
        {
            return _context.Cities
                .Include(c => c.Country)
                .Where(c => c.CountryId == countryId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(City city)
    {
        try
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(City city)
    {
        try
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var city = GetById(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw ;
        }
    }
}