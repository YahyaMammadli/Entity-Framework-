using OlympicApp.Data;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class StatisticsService : IStatisticsService
{
    private readonly IOlympiadRepository _olympiadRepository;




    public StatisticsService(IOlympiadRepository olympiadRepository)
    {
        _olympiadRepository = olympiadRepository;
    }

    public void DisplayMedalTableByOlympiad(int olympiadId)
    {
        try
        {
            var table = _olympiadRepository.GetMedalTableByOlympiad(olympiadId);
            if (!table.Any())
            {
                Console.Write("\nNo medal data found for this Olympiad.\n");
                return;
            }

            Console.Write("\nMedal table:\n");
            Console.Write("{0,-20} {1,6} {2,6} {3,6} {4,6}\n", "Country", "Gold", "Silver", "Bronze", "Total");
            foreach (var item in table)
            {
                Console.Write("{0,-20} {1,6} {2,6} {3,6} {4,6}\n",
                    item.Country, item.Gold, item.Silver, item.Bronze, item.Total);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayAllTimeMedalTable()
    {
        try
        {
            var table = _olympiadRepository.GetAllTimeMedalTable();
            if (!table.Any())
            {
                Console.Write("\nNo all-time medal data found.\n");
                return;
            }

            Console.Write("\nAll-time medal table:\n");
            Console.Write("{0,-20} {1,6} {2,6} {3,6} {4,6}\n", "Country", "Gold", "Silver", "Bronze", "Total");
            foreach (var item in table)
            {
                Console.Write("{0,-20} {1,6} {2,6} {3,6} {4,6}\n",
                    item.Country, item.Gold, item.Silver, item.Bronze, item.Total);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayMedalistsByOlympiadAndSport(int olympiadId, int? sportId)
    {
        try
        {
            var medalists = _olympiadRepository.GetMedalistsByOlympiadAndSport(olympiadId, sportId);
            if (!medalists.Any())
            {
                Console.Write("\nNo medalists found for this Olympiad and sport.\n");
                return;
            }

            Console.Write("\nMedalists:\n");
            foreach (var m in medalists)
            {
                Console.Write("{0} - {1} ({2}) - {3}\n", m.Sport, m.AthleteName, m.Country, m.Medal);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayAllTimeMedalistsBySport(int? sportId)
    {
        try
        {
            var medalists = _olympiadRepository.GetAllTimeMedalistsBySport(sportId);
            if (!medalists.Any())
            {
                Console.Write("\nNo all-time medalists found.\n");
                return;
            }

            Console.Write("\nAll-time medalists:\n");
            foreach (var m in medalists)
            {
                Console.Write("{0} - {1} ({2}) - {3}\n", m.Sport, m.AthleteName, m.Country, m.Medal);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayMostGoldCountryByOlympiad(int olympiadId)
    {
        try
        {
            var country = _olympiadRepository.GetCountryWithMostGoldByOlympiad(olympiadId);
            if (country != null)
                Console.Write($"\nCountry with most gold medals: {country}\n");
            else
                Console.Write("\nNo data for this Olympiad.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayAllTimeMostGoldCountry()
    {
        try
        {
            var country = _olympiadRepository.GetAllTimeMostGoldCountry();
            if (country != null)
                Console.Write($"\nAll-time country with most gold medals: {country}\n");
            else
                Console.Write("\nNo all-time data.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayBestAthleteInSport(string sportName)
    {
        try
        {
            var athletes = _olympiadRepository.GetBestAthleteInSport(sportName);
            if (athletes.Any())
            {
                var best = athletes.FirstOrDefault();
                Console.Write($"\nBest athlete in {sportName}: {best.Name} {best.Surname} ({best.Country}) with {best.GoldCount} gold medals.\n");
            }
            else
            {
                Console.Write($"\nNo athletes found for sport '{sportName}'.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayMostFrequentHostCountry()
    {
        try
        {
            var country = _olympiadRepository.GetMostFrequentHostCountry();
            if (country != null)
                Console.Write($"\nMost frequent host country: {country}\n");
            else
                Console.Write("\nNo data.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayTeamOfCountry(string country)
    {
        try
        {
            var team = _olympiadRepository.GetTeamOfCountry(country);
            if (!team.Any())
            {
                Console.Write($"\nNo athletes found for country '{country}'.\n");
                return;
            }

            Console.Write($"\nTeam of {country}:\n");
            foreach (var a in team)
            {
                Console.Write($"{a.Name} {a.Surname}, born {a.BirthDate}\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayCountryStatisticsForOlympiad(int olympiadId, string country)
    {
        try
        {
            var stats = _olympiadRepository.GetCountryStatisticsForOlympiad(olympiadId, country);
            if (stats != null && stats.Total > 0)
            {
                Console.Write($"\nStatistics for {country} at Olympiad {olympiadId}:\n");
                Console.Write($"Gold: {stats.Gold}, Silver: {stats.Silver}, Bronze: {stats.Bronze}, Total: {stats.Total}\n");
            }
            else
            {
                Console.Write($"\nNo statistics for {country} at this Olympiad.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DisplayAllTimeCountryStatistics(string country)
    {
        try
        {
            var stats = _olympiadRepository.GetAllTimeCountryStatistics(country);
            if (stats != null && stats.Total > 0)
            {
                Console.Write($"\nAll-time statistics for {country}:\n");
                Console.Write($"Gold: {stats.Gold}, Silver: {stats.Silver}, Bronze: {stats.Bronze}, Total: {stats.Total}\n");
            }
            else
            {
                Console.Write($"\nNo statistics for {country}.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}