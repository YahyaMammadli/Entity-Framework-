using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;


namespace OlympicApp.Repositories.Concrete;

public class AthleteRepository : IAthleteRepository
{
    private readonly AppDbContext _context;

    public AthleteRepository(AppDbContext context)
    {
        _context = context;
    }

    public Athlete? GetById(int id)
    {
        try
        {
            return _context.Athletes
                .Include(a => a.Country)
                .FirstOrDefault(a => a.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Athlete> GetAll()
    {
        try
        {
            return _context.Athletes
                .Include(a => a.Country)
                .AsQueryable();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Athlete> GetAthletesByCountry(string country)
    {
        try
        {
            return _context.Athletes
                .Include(a => a.Country)
                .Where(a => a.Country.Name.ToLower() == country.ToLower())
                .AsQueryable();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Athlete athlete)
    {
        try
        {
            _context.Athletes.Add(athlete);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Athlete athlete)
    {
        try
        {
            _context.Athletes.Update(athlete);
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
            var athlete = GetById(id);
            if (athlete != null)
            {
                _context.Athletes.Remove(athlete);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}