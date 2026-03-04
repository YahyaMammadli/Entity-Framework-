using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;


namespace OlympicApp.Repositories.Concrete;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _context;

    public CountryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Country? GetById(int id)
    {
        try
        {
            return _context.Countries
                .Include(c => c.Cities)
                .FirstOrDefault(c => c.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Country> GetAll()
    {
        try
        {
            return _context.Countries
                .Include(c => c.Cities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Country country)
    {
        try
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Country country)
    {
        try
        {
            _context.Countries.Update(country);
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
            var country = GetById(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}