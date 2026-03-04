using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;


namespace OlympicApp.Repositories.Concrete;

public class SportRepository : ISportRepository
{
    private readonly AppDbContext _context;

    public SportRepository(AppDbContext context)
    {
        _context = context;
    }

    public Sport? GetById(int id)
    {
        try
        {
            return _context.Sports.Find(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Sport> GetAll()
    {
        try
        {
            return _context.Sports;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Sport sport)
    {
        try
        {
            _context.Sports.Add(sport);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Sport sport)
    {
        try
        {
            _context.Sports.Update(sport);
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
            var sport = GetById(id);
            if (sport != null)
            {
                _context.Sports.Remove(sport);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}