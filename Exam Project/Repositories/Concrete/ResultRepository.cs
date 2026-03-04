using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;

namespace OlympicApp.Repositories.Concrete;


public class ResultRepository : IResultRepository
{
    private readonly AppDbContext _context;

    public ResultRepository(AppDbContext context)
    {
        _context = context;
    }

    public Result? GetById(int id)
    {
        try
        {
            return _context.Results.Find(id);
        }
        catch (Exception)
        {
            throw ;
        }
    }

    public IQueryable<Result> GetAll()
    {
        try
        {
            return _context.Results;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Result> GetResultsWithDetails()
    {
        try
        {
            return _context.Results
                .Include(r => r.Athlete)
                .Include(r => r.Competition)
                    .ThenInclude(c => c.Sport)
                .Include(r => r.Competition)
                    .ThenInclude(c => c.Olympiad);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Result result)
    {
        try
        {
            _context.Results.Add(result);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;

        }
    }

    public void Update(Result result)
    {
        try
        {
            _context.Results.Update(result);
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
            var result = GetById(id);
            if (result != null)
            {
                _context.Results.Remove(result);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}