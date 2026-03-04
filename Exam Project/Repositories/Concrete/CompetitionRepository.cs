using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;

namespace OlympicApp.Repositories.Concrete;

public class CompetitionRepository : ICompetitionRepository
{
    private readonly AppDbContext _context;

    public CompetitionRepository(AppDbContext context)
    {
        _context = context;
    }

    public Competition? GetById(int id)
    {
        try
        {
            return _context.Competitions
                .Include(c => c.Olympiad)
                    .ThenInclude(o => o.Country)
                .Include(c => c.Olympiad)
                    .ThenInclude(o => o.City)
                .Include(c => c.Sport)
                .FirstOrDefault(c => c.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    
    }

    public IQueryable<Competition> GetAll()
    {
        try
        {
            return _context.Competitions
                .Include(c => c.Olympiad)
                    .ThenInclude(o => o.Country)
                .Include(c => c.Olympiad)
                    .ThenInclude(o => o.City)
                .Include(c => c.Sport);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Competition competition)
    {
        try
        {
            if (competition.Olympiad != null && competition.Olympiad.Id > 0)
            {
                _context.Olympiads.Attach(competition.Olympiad);

            }

            if (competition.Sport != null && competition.Sport.Id > 0)
            {

                _context.Sports.Attach(competition.Sport);
            }

            _context.Competitions.Add(competition);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Competition competition)
    {
        try
        {
            if (competition.Olympiad != null && competition.Olympiad.Id > 0)
                _context.Olympiads.Attach(competition.Olympiad);
            if (competition.Sport != null && competition.Sport.Id > 0)
                _context.Sports.Attach(competition.Sport);

            _context.Competitions.Update(competition);
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
            var competition = GetById(id);
            if (competition != null)
            {
                _context.Competitions.Remove(competition);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}