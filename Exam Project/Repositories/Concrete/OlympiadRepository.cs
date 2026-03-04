using Microsoft.EntityFrameworkCore;
using OlympicApp.Data;
using OlympicApp.DTO;
using OlympicApp.Enums;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;


namespace OlympicApp.Repositories.Concrete;

public class OlympiadRepository : IOlympiadRepository
{
    private readonly AppDbContext _context;

    public OlympiadRepository(AppDbContext context)
    {
        _context = context;
    }

    public Olympiad? GetById(int id)
    {
        try
        {
            return _context.Olympiads
                .Include(o => o.Country)
                .Include(o => o.City)
                .FirstOrDefault(o => o.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Olympiad> GetAll()
    {
        try
        {
            return _context.Olympiads
                .Include(o => o.Country)
                .Include(o => o.City);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<Olympiad> GetOlympiadsWithDetails()
    {
        try
        {
            return _context.Olympiads
                .Include(o => o.Country)
                .Include(o => o.City)
                .Include(o => o.Competitions)
                    .ThenInclude(c => c.Sport)
                .Include(o => o.Competitions)
                    .ThenInclude(c => c.Results)
                        .ThenInclude(r => r.Athlete)
                            .ThenInclude(a => a.Country);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Olympiad? GetOlympiadWithDetails(int id)
    {
        try
        {
            return _context.Olympiads  
                .Include(o => o.Country)
                .Include(o => o.City)
                .Include(o => o.Competitions)
                    .ThenInclude(c => c.Sport)
                .Include(o => o.Competitions)
                    .ThenInclude(c => c.Results)
                        .ThenInclude(r => r.Athlete)
                            .ThenInclude(a => a.Country)
                .FirstOrDefault(o => o.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Olympiad olympiad)
    {
        try
        {
            _context.Olympiads.Add(olympiad);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Olympiad olympiad)
    {
        try
        {
            _context.Olympiads.Update(olympiad);
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
            var olympiad = GetById(id);
            if (olympiad != null)
            {
                _context.Olympiads.Remove(olympiad);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<MedalRowDto> GetMedalTableByOlympiad(int olympiadId)
    {
        try
        {
            var query = _context.Results.Where(r => r.Medal != Medal.None)
                .Join(_context.Competitions,r => r.CompetitionId,c => c.Id,(r, c) => new { r, c })
                .Join(_context.Athletes,rc => rc.r.AthleteId,a => a.Id,(rc, a) => new { rc.r, rc.c, a })
                .Where(x => x.c.OlympiadId == olympiadId)
                .GroupBy(x => x.a.Country.Name)
                .Select(g => new MedalRowDto
                {
                    Country = new Country { Name = g.Key },
                    Gold = g.Count(x => x.r.Medal == Medal.Gold),
                    Silver = g.Count(x => x.r.Medal == Medal.Silver),
                    Bronze = g.Count(x => x.r.Medal == Medal.Bronze),
                    Total = g.Count()
                })
                .OrderByDescending(x => x.Gold)
                .ThenByDescending(x => x.Silver)
                .ThenByDescending(x => x.Bronze);

            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<MedalRowDto> GetAllTimeMedalTable()
    {
        try
        {
            var query = _context.Results
                .Where(r => r.Medal != Medal.None)
                .Join(_context.Athletes,r => r.AthleteId,a => a.Id,(r, a) => new { r, a })
                .GroupBy(x => x.a.Country.Name)
                .Select(g => new MedalRowDto
                {
                    Country = new Country { Name = g.Key },
                    Gold = g.Count(x => x.r.Medal == Medal.Gold),
                    Silver = g.Count(x => x.r.Medal == Medal.Silver),
                    Bronze = g.Count(x => x.r.Medal == Medal.Bronze),
                    Total = g.Count()
                })
                .OrderByDescending(x => x.Gold)
                .ThenByDescending(x => x.Silver)
                .ThenByDescending(x => x.Bronze);

            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string? GetCountryWithMostGoldByOlympiad(int olympiadId)
    {
        try
        {
            var table = GetMedalTableByOlympiad(olympiadId);
            return table.FirstOrDefault()?.Country?.Name;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string? GetAllTimeMostGoldCountry()
    {
        try
        {
            var table = GetAllTimeMedalTable();
            return table.FirstOrDefault()?.Country?.Name;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<MedalistDto> GetMedalistsByOlympiadAndSport(int olympiadId, int? sportId)
    {
        try
        {
            var query = _context.Results
                .Where(r => r.Medal != Medal.None)
                .Join(_context.Competitions,r => r.CompetitionId,c => c.Id,(r, c) => new { r, c })
                .Join(_context.Athletes,rc => rc.r.AthleteId,a => a.Id,(rc, a) => new { rc.r, rc.c, a })
                .Join(_context.Sports,rca => rca.c.SportId,s => s.Id,(rca, s) => new { rca.r, rca.c, rca.a, s })
                .Where(x => x.c.OlympiadId == olympiadId);

            if (sportId.HasValue)
            {
                query = query.Where(x => x.s.Id == sportId.Value);
            }

            var result = query
                .Select(x => new MedalistDto
                {
                    Sport = x.s.Name,
                    AthleteName = x.a.Name + " " + x.a.Surname,
                    Country = new Country { Name = x.a.Country.Name },
                    Medal = x.r.Medal.ToString()
                });

            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<MedalistDto> GetAllTimeMedalistsBySport(int? sportId)
    {
        try
        {
            var query = _context.Results
                .Where(r => r.Medal != Medal.None)
                .Join(_context.Competitions,r => r.CompetitionId,c => c.Id,(r, c) => new { r, c })
                .Join(_context.Athletes,rc => rc.r.AthleteId,a => a.Id,(rc, a) => new { rc.r, rc.c, a })
                .Join(_context.Sports,rca => rca.c.SportId,s => s.Id,(rca, s) => new { rca.r, rca.c, rca.a, s });

            if (sportId.HasValue)
            {
                query = query.Where(x => x.s.Id == sportId.Value);
            }

            var result = query
                .Select(x => new MedalistDto
                {
                    Sport = x.s.Name,
                    AthleteName = x.a.Name + " " + x.a.Surname,
                    Country = new Country { Name = x.a.Country.Name },
                    Medal = x.r.Medal.ToString()
                });

            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<BestAthleteDto> GetBestAthleteInSport(string sportName)
    {
        try
        {
            var query = _context.Results
                .Where(r => r.Medal == Medal.Gold)
                .Join(_context.Competitions,r => r.CompetitionId,c => c.Id,(r, c) => new { r, c })
                .Join(_context.Sports,rc => rc.c.SportId,s => s.Id,(rc, s) => new { rc.r, rc.c, s })
                .Where(x => x.s.Name.ToLower() == sportName.ToLower())
                .Join(_context.Athletes,rcs => rcs.r.AthleteId,a => a.Id,(rcs, a) => new { rcs.r, rcs.c, rcs.s, a })
                .GroupBy(x => x.a.Id)
                .Select(g => new BestAthleteDto
                {
                    AthleteId = g.Key,
                    Name = g.FirstOrDefault().a.Name,
                    Surname = g.FirstOrDefault().a.Surname,
                    Country = new Country { Name = g.FirstOrDefault().a.Country.Name },
                    GoldCount = g.Count()
                })
                .OrderByDescending(x => x.GoldCount);

            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string? GetMostFrequentHostCountry()
    {
        try
        {
            var query = _context.Olympiads
                .GroupBy(o => o.Country.Name)
                .Select(g => new { Country = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count);

            return query.FirstOrDefault()?.Country;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<AthleteDto> GetTeamOfCountry(string country)
    {
        try
        {
            return _context.Athletes
                .Include(a => a.Country)
                .Where(a => a.Country.Name.ToLower() == country.ToLower())
                .Select(a => new AthleteDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Surname = a.Surname,
                    Country = new Country { Name = a.Country.Name },
                    BirthDate = a.BirthDate,
                    PhotoPath = a.PhotoPath
                });
        }
        catch (Exception)
        {
            throw;
        }
    }

    public CountryStatisticsDto? GetCountryStatisticsForOlympiad(int olympiadId, string country)
    {
        try
        {
            var medals = _context.Results
                .Where(r => r.Medal != Medal.None)
                .Join(_context.Competitions,r => r.CompetitionId,c => c.Id,(r, c) => new { r, c })
                .Join(_context.Athletes,rc => rc.r.AthleteId,a => a.Id,(rc, a) => new { rc.r, rc.c, a })
                .Where(x => x.c.OlympiadId == olympiadId && x.a.Country.Name.ToLower() == country.ToLower())
                .Select(x => x.r)
                .ToList();

            return new CountryStatisticsDto
            {
                Gold = medals.Count(m => m.Medal == Medal.Gold),
                Silver = medals.Count(m => m.Medal == Medal.Silver),
                Bronze = medals.Count(m => m.Medal == Medal.Bronze),
                Total = medals.Count
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public CountryStatisticsDto? GetAllTimeCountryStatistics(string country)
    {
        try
        {
            var medals = _context.Results
                .Where(r => r.Medal != Medal.None)
                .Join(_context.Athletes,r => r.AthleteId,a => a.Id,(r, a) => new { r, a })
                .Where(x => x.a.Country.Name.ToLower() == country.ToLower())
                .Select(x => x.r)
                .ToList();

            return new CountryStatisticsDto
            {
                Gold = medals.Count(m => m.Medal == Medal.Gold),
                Silver = medals.Count(m => m.Medal == Medal.Silver),
                Bronze = medals.Count(m => m.Medal == Medal.Bronze),
                Total = medals.Count
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}