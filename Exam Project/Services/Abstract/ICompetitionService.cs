using OlympicApp.Models;

namespace OlympicApp.Services.Abstract;

public interface ICompetitionService
{
    Competition? GetCompetitionById(int id);
    IEnumerable<Competition> GetAllCompetitions();
    void AddCompetition(Competition competition);
    void UpdateCompetition(Competition competition);
    void DeleteCompetition(int id);
}