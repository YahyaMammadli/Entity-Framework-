using OlympicApp.Data;
using OlympicApp.Models;
using OlympicApp.Repositories.Abstract;
using OlympicApp.Services.Abstract;


namespace OlympicApp.Services.Concrete;

public class CompetitionService : ICompetitionService
{
    private readonly ICompetitionRepository _competitionRepository;

    public CompetitionService(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public Competition? GetCompetitionById(int id)
    {
        try
        {
            return _competitionRepository.GetById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Competition> GetAllCompetitions()
    {
        try
        {
            return _competitionRepository.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddCompetition(Competition competition)
    {
        try
        {
            _competitionRepository.Add(competition);

            Console.Write("Competition added.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateCompetition(Competition competition)
    {
        try
        {
            _competitionRepository.Update(competition);

            Console.Write("Competition updated.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteCompetition(int id)
    {
        try
        {
            _competitionRepository.Delete(id);

            Console.Write("Competition deleted.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}