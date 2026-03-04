

namespace OlympicApp.Services.Abstract;

public interface IStatisticsService
{
    void DisplayMedalTableByOlympiad(int olympiadId);
    void DisplayAllTimeMedalTable();
    void DisplayMedalistsByOlympiadAndSport(int olympiadId, int? sportId);
    void DisplayAllTimeMedalistsBySport(int? sportId);
    void DisplayMostGoldCountryByOlympiad(int olympiadId);
    void DisplayAllTimeMostGoldCountry();
    void DisplayBestAthleteInSport(string sportName);
    void DisplayMostFrequentHostCountry();
    void DisplayTeamOfCountry(string country);
    void DisplayCountryStatisticsForOlympiad(int olympiadId, string country);
    void DisplayAllTimeCountryStatistics(string country);
}