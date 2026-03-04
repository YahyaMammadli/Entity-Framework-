using OlympicApp.DTO;
using OlympicApp.Models;

namespace OlympicApp.Repositories.Abstract;

public interface IOlympiadRepository
{
    Olympiad? GetById(int id);
    IQueryable<Olympiad> GetAll();
    IQueryable<Olympiad> GetOlympiadsWithDetails();
    Olympiad? GetOlympiadWithDetails(int id);
    void Add(Olympiad olympiad);
    void Update(Olympiad olympiad);
    void Delete(int id);

    IQueryable<MedalRowDto> GetMedalTableByOlympiad(int olympiadId);
    IQueryable<MedalRowDto> GetAllTimeMedalTable();
    string? GetCountryWithMostGoldByOlympiad(int olympiadId);
    string? GetAllTimeMostGoldCountry();
    IQueryable<MedalistDto> GetMedalistsByOlympiadAndSport(int olympiadId, int? sportId);
    IQueryable<MedalistDto> GetAllTimeMedalistsBySport(int? sportId);
    IQueryable<BestAthleteDto> GetBestAthleteInSport(string sportName);
    string? GetMostFrequentHostCountry();
    IQueryable<AthleteDto> GetTeamOfCountry(string country);
    CountryStatisticsDto? GetCountryStatisticsForOlympiad(int olympiadId, string country);
    CountryStatisticsDto? GetAllTimeCountryStatistics(string country);
}