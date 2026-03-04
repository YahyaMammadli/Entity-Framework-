

using OlympicApp.Data;
using OlympicApp.Repositories.Concrete;
using OlympicApp.Services.Concrete;
using OlympicApp.MenuList;

namespace OlympicApp;

public class Program
{
    static void Main()
    {


        using var context = new AppDbContext();


        #region Repositories

        var olympiadRepository = new OlympiadRepository(context);
        
        var athleteRepository = new AthleteRepository(context);
        
        var resultRepository = new ResultRepository(context);
        
        var sportRepository = new SportRepository(context);
        
        var competitionRepository = new CompetitionRepository(context);

        var countryRepository = new CountryRepository(context);
        
        var citiRepository = new CityRepository(context);

        #endregion



        #region Services

        var olympiadService = new OlympiadService(olympiadRepository);
        
        var sportService = new SportService(sportRepository);
        
        var athleteService = new AthleteService(athleteRepository);
        
        var competitionService = new CompetitionService(competitionRepository);
        
        var resultService = new ResultService(resultRepository);
        
        var statisticsService = new StatisticsService(olympiadRepository);

        var countryService = new CountryService(countryRepository);

        
        var cityService = new CityService(citiRepository);

        #endregion
        



        var menu = new Menu(olympiadService,sportService,athleteService,competitionService,resultService,statisticsService, countryService, cityService);

        menu.Run();


    }
}
