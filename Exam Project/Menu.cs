using OlympicApp.Models;
using OlympicApp.Enums;
using OlympicApp.Services.Abstract;


namespace OlympicApp.MenuList;

public class Menu
{
    private readonly IOlympiadService _olympiadService;
    private readonly ISportService _sportService;
    private readonly IAthleteService _athleteService;
    private readonly ICompetitionService _competitionService;
    private readonly IResultService _resultService;
    private readonly IStatisticsService _statisticsService;
    private readonly ICountryService _countryService;
    private readonly ICityService _cityService;

    public Menu(IOlympiadService olympiadService,ISportService sportService,IAthleteService athleteService,ICompetitionService competitionService,IResultService resultService,IStatisticsService statisticsService,ICountryService countryService,ICityService cityService)
    {
        _olympiadService = olympiadService;
        _sportService = sportService;
        _athleteService = athleteService;
        _competitionService = competitionService;
        _resultService = resultService;
        _statisticsService = statisticsService;
        _countryService = countryService;
        _cityService = cityService;
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.Write("===== Olympic Application =====\n");
            Console.Write("1. Add Olympiad\n");
            Console.Write("2. Add Sport\n");
            Console.Write("3. Add Athlete\n");
            Console.Write("4. Add Competition\n");
            Console.Write("5. Add Result (Medal)\n");
            Console.Write("6. Edit entity\n");
            Console.Write("7. Delete entity\n");
            Console.Write("8. Display medal table\n");
            Console.Write("9. Display medalists by sport\n");
            Console.Write("10. Country with most gold medals\n");
            Console.Write("11. Best athlete in a sport\n");
            Console.Write("12. Most frequent host country\n");
            Console.Write("13. Team of a country\n");
            Console.Write("14. Country statistics\n");
            Console.Write("0. Exit\n");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddOlympiad();
                    break;
                case "2":
                    AddSport();
                    break;
                case "3":
                    AddAthlete();
                    break;
                case "4":
                    AddCompetition();
                    break;
                case "5":
                    AddResult();
                    break;
                case "6":
                    EditEntity();
                    break;
                case "7":
                    DeleteEntity();
                    break;
                case "8":
                    ShowMedalTableMenu();
                    break;
                case "9":
                    ShowMedalistsMenu();
                    break;
                case "10":
                    ShowMostGoldMenu();
                    break;
                case "11":
                    ShowBestAthleteInSport();
                    break;
                case "12":
                    ShowMostFrequentHost();
                    break;
                case "13":
                    ShowTeamOfCountry();
                    break;
                case "14":
                    ShowCountryStatisticsMenu();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.Write("Invalid choice.\n");
                    Pause();
                    break;
            }
        }
    }

    private void Pause()
    {
        Console.Write("Press any key to continue...\n");
        Console.ReadKey();
    }


    private void DisplayOlympiads()
    {
        var olympiads = _olympiadService.GetAllOlympiads().ToList();
        if (!olympiads.Any())
        {
            Console.Write("No Olympiads available.\n");
            return;
        }
        Console.Write("Olympiads:\n");
        foreach (var o in olympiads)
        {
            Console.Write($"{o.Id}: {o.Year} {o.Season} - {o.Country.Name} ({o.City.Name})\n");
        }
    }

    private void DisplaySports()
    {
        var sports = _sportService.GetAllSports().ToList();
        if (!sports.Any())
        {
            Console.Write("No sports available.\n");
            return;
        }
        Console.Write("Sports:\n");
        foreach (var s in sports)
        {
            Console.Write($"{s.Id}: {s.Name}\n");
        }
    }

    private void DisplayCountries()
    {
        var countries = _countryService.GetAllCountries().ToList();
        if (!countries.Any())
        {
            Console.Write("No countries available.\n");
            return;
        }
        Console.Write("Countries:\n");
        foreach (var c in countries)
        {
            Console.Write($"{c.Id}: {c.Name}\n");
        }
    }

    private void DisplayCitiesByCountry(int countryId)
    {
        var cities = _cityService.GetCitiesByCountry(countryId).ToList();
        if (!cities.Any())
        {
            Console.Write("No cities available for this country.\n");
            return;
        }
        Console.Write("Cities:\n");
        foreach (var ci in cities)
        {
            Console.Write($"{ci.Id}: {ci.Name}\n");
        }
    }

    private void DisplayAthletes()
    {
        var athletes = _athleteService.GetAllAthletes().ToList();
        if (!athletes.Any())
        {
            Console.Write("No athletes available.\n");
            return;
        }
        Console.Write("Athletes (first 10):\n");
        foreach (var a in athletes.Take(10))
        {
            Console.Write($"{a.Id}: {a.Name} {a.Surname} ({a.Country.Name})\n");
        }
    }

    private void DisplayCompetitions()
    {
        var competitions = _competitionService.GetAllCompetitions().ToList();
        if (!competitions.Any())
        {
            Console.Write("No competitions available.\n");
            return;
        }

        Console.Write("Competitions:\n");

        foreach (var c in competitions.Take(10)) 
        {
            string countryName = c.Olympiad?.Country?.Name ?? "Unknown";
            string sportName = c.Sport?.Name ?? "Unknown";
            string compName = string.IsNullOrEmpty(c.Name) ? "Unnamed" : c.Name;

            Console.Write($"  {c.Id}: {compName} | Olympiad: {c.Olympiad?.Year} {c.Olympiad?.Season} ({countryName}) | Sport: {sportName}\n");
        }
    }


    private void AddOlympiad()
    {
        try
        {
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine()!);

            Console.Write("Season (Summer/Winter): ");
            Season season = Enum.Parse<Season>(Console.ReadLine()!, true);

            DisplayCountries();
            
            Console.Write("Select Country ID: ");
            
            int countryId = int.Parse(Console.ReadLine()!);
            
            var selectedCountry = _countryService.GetCountryById(countryId);
            
            if (selectedCountry == null)
            {
                Console.Write("Invalid country ID.\n");
                Pause();
                return;
            }

            DisplayCitiesByCountry(countryId);
            
            Console.Write("Select City ID: ");
            
            int cityId = int.Parse(Console.ReadLine()!);
            
            var selectedCity = _cityService.GetCityById(cityId);
            
            if (selectedCity == null || selectedCity.CountryId != countryId)
            {
                Console.Write("Invalid city ID or city does not belong to the selected country.\n");
                Pause();
                return;
            }

            var olympiad = new Olympiad
            {
                Year = year,
                Season = season,
                Country = selectedCountry,
                City = selectedCity
            };
            _olympiadService.AddOlympiad(olympiad);
        }
        catch (Exception)
        {
            throw;
        }

        Pause();
    }

    private void AddSport()
    {
        try
        {
            Console.Write("Sport name: ");
            string name = Console.ReadLine()!;
            var sport = new Sport { Name = name };
            _sportService.AddSport(sport);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void AddAthlete()
    {
        try
        {
            Console.Write("First name: ");
            string name = Console.ReadLine()!;
            Console.Write("Surname: ");
            string surname = Console.ReadLine()!;

            DisplayCountries();
            Console.Write("Select Country ID: ");
            int countryId = int.Parse(Console.ReadLine()!);
            var selectedCountry = _countryService.GetCountryById(countryId);
            if (selectedCountry == null)
            {
                Console.Write("Invalid country ID.\n");
                Pause();
                return;
            }

            Console.Write("Birth date (yyyy-mm-dd): ");
            DateTime bd = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Photo path (optional): ");
            string? photo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(photo)) photo = null;

            var athlete = new Athlete
            {
                Name = name,
                Surname = surname,
                Country = selectedCountry,
                BirthDate = bd,
                PhotoPath = photo
            };
            _athleteService.AddAthlete(athlete);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void AddCompetition()
    {
        try
        {
            DisplayOlympiads();
            Console.Write("Select Olympiad ID: ");
            int oid = int.Parse(Console.ReadLine()!);

            DisplaySports();
            Console.Write("Select Sport ID: ");
            int sid = int.Parse(Console.ReadLine()!);

            Console.Write("Date (optional, yyyy-mm-dd, leave empty): ");
            string dateStr = Console.ReadLine()!;
            DateTime? date = null;
            if (!string.IsNullOrWhiteSpace(dateStr))
                date = DateTime.Parse(dateStr);

            var comp = new Competition
            {
                OlympiadId = oid,
                SportId = sid,
                Date = date
            };
            _competitionService.AddCompetition(comp);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void AddResult()
    {
        try
        {
            DisplayAthletes();
            Console.Write("Select Athlete ID: ");
            int aid = int.Parse(Console.ReadLine()!);

            DisplayCompetitions();
            Console.Write("Select Competition ID: ");
            int cid = int.Parse(Console.ReadLine()!);

            Console.Write("Medal (None, Gold, Silver, Bronze): ");
            Medal medal = Enum.Parse<Medal>(Console.ReadLine()!, true);

            Console.Write("Result details : ");
            string details = Console.ReadLine()!;

            var result = new Result
            {
                AthleteId = aid,
                CompetitionId = cid,
                Medal = medal,
                ResultDetails = details
            };
            _resultService.AddResult(result);
        }
        catch (Exception)
        {
            throw;
        }

        Pause();
    }


    private void EditEntity()
    {
        Console.Write("Select entity type to edit:\n");
        Console.Write("1. Olympiad\n");
        Console.Write("2. Sport\n");
        Console.Write("3. Athlete\n");
        Console.Write("4. Competition\n");
        Console.Write("5. Result\n");
        Console.Write("Choice: ");
        string? typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                EditOlympiad();
                break;
            case "2":
                EditSport();
                break;
            case "3":
                EditAthlete();
                break;
            case "4":
                EditCompetition();
                break;
            case "5":
                EditResult();
                break;
            default:
                Console.Write("Invalid choice.\n");
                Pause();
                break;
        }
    }

    private void EditOlympiad()
    {
        try
        {
            DisplayOlympiads();
            Console.Write("Enter Olympiad ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var olympiad = _olympiadService.GetOlympiadById(id);
            if (olympiad == null)
            {
                Console.Write("Olympiad not found.\n");
                Pause();
                return;
            }

            Console.Write($"Current Year: {olympiad.Year}\n");
            Console.Write("New Year (leave empty to keep): ");
            string yearInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(yearInput) && int.TryParse(yearInput, out int newYear))
                olympiad.Year = newYear;

            Console.Write($"Current Season: {olympiad.Season}\n");
            Console.Write("New Season (Summer/Winter, leave empty to keep): ");
            string seasonInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(seasonInput))
                olympiad.Season = Enum.Parse<Season>(seasonInput, true);

            DisplayCountries();
            Console.Write($"Current Country: {olympiad.Country.Name} (ID: {olympiad.Country.Id})\n");
            Console.Write("Select new Country ID (or leave empty to keep): ");
            string countryInput = Console.ReadLine()!;
            int newCountryId = olympiad.Country.Id; 
            if (!string.IsNullOrWhiteSpace(countryInput) && int.TryParse(countryInput, out int tempCountryId))
            {
                var newCountry = _countryService.GetCountryById(tempCountryId);
                if (newCountry != null)
                {
                    olympiad.Country = newCountry;
                    newCountryId = tempCountryId;
                }
                else
                    Console.Write("Invalid country ID, keeping current.\n");
            }

            DisplayCitiesByCountry(newCountryId);
            Console.Write($"Current City: {olympiad.City.Name} (ID: {olympiad.City.Id})\n");
            Console.Write("Select new City ID (or leave empty to keep): ");
            string cityInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(cityInput) && int.TryParse(cityInput, out int newCityId))
            {
                var newCity = _cityService.GetCityById(newCityId);
                if (newCity != null && newCity.CountryId == newCountryId)
                    olympiad.City = newCity;
                else
                    Console.Write("Invalid city ID or city does not belong to the selected country, keeping current.\n");
            }

            _olympiadService.UpdateOlympiad(olympiad);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void EditSport()
    {
        try
        {
            DisplaySports();
            Console.Write("Enter Sport ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var sport = _sportService.GetSportById(id);
            if (sport == null)
            {
                Console.Write("Sport not found.\n");
                Pause();
                return;
            }

            Console.Write($"Current Name: {sport.Name}\n");
            Console.Write("New Name (leave empty to keep): ");
            string name = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(name))
                sport.Name = name;

            _sportService.UpdateSport(sport);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void EditAthlete()
    {
        try
        {
            DisplayAthletes();
            Console.Write("Enter Athlete ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var athlete = _athleteService.GetAthleteById(id);
            if (athlete == null)
            {
                Console.Write("Athlete not found.\n");
                Pause();
                return;
            }

            Console.Write($"Current First Name: {athlete.Name}\n");
            Console.Write("New First Name (leave empty to keep): ");
            string name = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(name))
                athlete.Name = name;

            Console.Write($"Current Surname: {athlete.Surname}\n");
            Console.Write("New Surname (leave empty to keep): ");
            string surname = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(surname))
                athlete.Surname = surname;

            DisplayCountries();
            Console.Write($"Current Country: {athlete.Country.Name} (ID: {athlete.Country.Id})\n");
            Console.Write("Select new Country ID (or leave empty to keep): ");
            string countryInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(countryInput) && int.TryParse(countryInput, out int newCountryId))
            {
                var newCountry = _countryService.GetCountryById(newCountryId);
                if (newCountry != null)
                    athlete.Country = newCountry;
                else
                    Console.Write("Invalid country ID, keeping current.\n");
            }

            Console.Write($"Current Birth Date: {athlete.BirthDate:yyyy-MM-dd}\n");
            Console.Write("New Birth Date (yyyy-mm-dd, leave empty to keep): ");
            string bdInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(bdInput) && DateTime.TryParse(bdInput, out DateTime newBd))
                athlete.BirthDate = newBd;

            Console.Write($"Current Photo Path: {athlete.PhotoPath ?? "none"}\n");
            Console.Write("New Photo Path (leave empty to keep, 'null' to clear): ");
            string photo = Console.ReadLine()!;
            if (photo.ToLower() == "null")
                athlete.PhotoPath = null;
            else if (!string.IsNullOrWhiteSpace(photo))
                athlete.PhotoPath = photo;

            _athleteService.UpdateAthlete(athlete);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void EditCompetition()
    {
        try
        {
            DisplayCompetitions();
            Console.Write("Enter Competition ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var competition = _competitionService.GetCompetitionById(id);
            if (competition == null)
            {
                Console.Write("Competition not found.\n");
                Pause();
                return;
            }

            DisplayOlympiads();
            Console.Write($"Current Olympiad ID: {competition.OlympiadId}\n");
            Console.Write("New Olympiad ID (leave empty to keep): ");
            string oidInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(oidInput) && int.TryParse(oidInput, out int newOid))
                competition.OlympiadId = newOid;

            DisplaySports();
            Console.Write($"Current Sport ID: {competition.SportId}\n");
            Console.Write("New Sport ID (leave empty to keep): ");
            string sidInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(sidInput) && int.TryParse(sidInput, out int newSid))
                competition.SportId = newSid;

            Console.Write($"Current Date: {(competition.Date.HasValue ? competition.Date.Value.ToString("yyyy-MM-dd") : "none")}\n");
            Console.Write("New Date (yyyy-mm-dd, or leave empty to keep, type 'null' to clear): ");
            string dateInput = Console.ReadLine()!;
            if (dateInput.ToLower() == "null")
                competition.Date = null;
            else if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime newDate))
                competition.Date = newDate;

            _competitionService.UpdateCompetition(competition);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void EditResult()
    {
        try
        {
            Console.Write("Enter Result ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var result = _resultService.GetResultById(id);
            if (result == null)
            {
                Console.Write("Result not found.\n");
                Pause();
                return;
            }

            DisplayAthletes();
            Console.Write($"Current Athlete ID: {result.AthleteId}\n");
            Console.Write("New Athlete ID (leave empty to keep): ");
            string aidInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(aidInput) && int.TryParse(aidInput, out int newAid))
                result.AthleteId = newAid;

            DisplayCompetitions();
            Console.Write($"Current Competition ID: {result.CompetitionId}\n");
            Console.Write("New Competition ID (leave empty to keep): ");
            string cidInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(cidInput) && int.TryParse(cidInput, out int newCid))
                result.CompetitionId = newCid;

            Console.Write($"Current Medal: {result.Medal}\n");
            Console.Write("New Medal (None, Gold, Silver, Bronze; leave empty to keep): ");
            string medalInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(medalInput))
                result.Medal = Enum.Parse<Medal>(medalInput, true);

            Console.Write($"Current Result Details: {result.ResultDetails ?? "none"}\n");
            Console.Write("New Result Details (leave empty to keep, type 'null' to clear): ");
            string details = Console.ReadLine()!;
            if (details.ToLower() == "null")
                result.ResultDetails = null;
            else if (!string.IsNullOrWhiteSpace(details))
                result.ResultDetails = details;

            _resultService.UpdateResult(result);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }


    private void DeleteEntity()
    {
        Console.Write("Select entity type to delete:\n");
        Console.Write("1. Olympiad\n");
        Console.Write("2. Sport\n");
        Console.Write("3. Athlete\n");
        Console.Write("4. Competition\n");
        Console.Write("5. Result\n");
        Console.Write("Choice: ");
        string? typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                DeleteOlympiad();
                break;
            case "2":
                DeleteSport();
                break;
            case "3":
                DeleteAthlete();
                break;
            case "4":
                DeleteCompetition();
                break;
            case "5":
                DeleteResult();
                break;
            default:
                Console.Write("Invalid choice.\n");
                Pause();
                break;
        }
    }

    private void DeleteOlympiad()
    {
        try
        {
            DisplayOlympiads();
            Console.Write("Enter Olympiad ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var olympiad = _olympiadService.GetOlympiadById(id);
            if (olympiad == null)
            {
                Console.Write("Olympiad not found.\n");
                Pause();
                return;
            }

            Console.Write($"Are you sure you want to delete Olympiad {olympiad.Year} {olympiad.Season} - {olympiad.Country.Name}? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                _olympiadService.DeleteOlympiad(id);
            }
            else
            {
                Console.Write("Deletion cancelled.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void DeleteSport()
    {
        try
        {
            DisplaySports();
            Console.Write("Enter Sport ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var sport = _sportService.GetSportById(id);
            if (sport == null)
            {
                Console.Write("Sport not found.\n");
                Pause();
                return;
            }

            Console.Write($"Are you sure you want to delete sport {sport.Name}? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                _sportService.DeleteSport(id);
            }
            else
            {
                Console.Write("Deletion cancelled.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void DeleteAthlete()
    {
        try
        {
            DisplayAthletes();
            Console.Write("Enter Athlete ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var athlete = _athleteService.GetAthleteById(id);
            if (athlete == null)
            {
                Console.Write("Athlete not found.\n");
                Pause();
                return;
            }

            Console.Write($"Are you sure you want to delete athlete {athlete.Name} {athlete.Surname}? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                _athleteService.DeleteAthlete(id);
            }
            else
            {
                Console.Write("Deletion cancelled.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void DeleteCompetition()
    {
        try
        {
            DisplayCompetitions();
            Console.Write("Enter Competition ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var competition = _competitionService.GetCompetitionById(id);
            if (competition == null)
            {
                Console.Write("Competition not found.\n");
                Pause();
                return;
            }

            Console.Write($"Are you sure you want to delete competition ID {id}? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                _competitionService.DeleteCompetition(id);
            }
            else
            {
                Console.Write("Deletion cancelled.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void DeleteResult()
    {
        try
        {
            Console.Write("Enter Result ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Invalid ID.\n");
                Pause();
                return;
            }

            var result = _resultService.GetResultById(id);
            if (result == null)
            {
                Console.Write("Result not found.\n");
                Pause();
                return;
            }

            Console.Write($"Are you sure you want to delete result ID {id}? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                _resultService.DeleteResult(id);
            }
            else
            {
                Console.Write("Deletion cancelled.\n");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }


    private void ShowMedalTableMenu()
    {
        Console.Write("1. For a specific Olympiad\n");
        Console.Write("2. All-time\n");
        string? choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayOlympiads();
            Console.Write("Enter Olympiad ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _statisticsService.DisplayMedalTableByOlympiad(id);
            }
            else
            {
                Console.Write("Invalid ID.\n");
            }
        }
        else if (choice == "2")
        {
            _statisticsService.DisplayAllTimeMedalTable();
        }
        Pause();
    }

    private void ShowMedalistsMenu()
    {
        Console.Write("1. For a specific Olympiad\n");
        Console.Write("2. All-time\n");
        string? choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayOlympiads();
            Console.Write("Enter Olympiad ID: ");
            if (int.TryParse(Console.ReadLine(), out int oid))
            {
                DisplaySports();
                Console.Write("Enter Sport ID (or leave empty for all): ");
                string sportInput = Console.ReadLine()!;
                int? sportId = string.IsNullOrWhiteSpace(sportInput) ? null : int.Parse(sportInput);
                _statisticsService.DisplayMedalistsByOlympiadAndSport(oid, sportId);
            }
            else
            {
                Console.Write("Invalid ID.\n");
            }
        }
        else if (choice == "2")
        {
            DisplaySports();
            Console.Write("Enter Sport ID (or leave empty for all): ");
            string sportInput = Console.ReadLine()!;
            int? sportId = string.IsNullOrWhiteSpace(sportInput) ? null : int.Parse(sportInput);
            _statisticsService.DisplayAllTimeMedalistsBySport(sportId);
        }
        Pause();
    }

    private void ShowMostGoldMenu()
    {
        Console.Write("1. For a specific Olympiad\n");
        Console.Write("2. All-time\n");
        string? choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayOlympiads();
            Console.Write("Enter Olympiad ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _statisticsService.DisplayMostGoldCountryByOlympiad(id);
            }
            else
            {
                Console.Write("Invalid ID.\n");
            }
        }
        else if (choice == "2")
        {
            _statisticsService.DisplayAllTimeMostGoldCountry();
        }
        Pause();
    }

    private void ShowBestAthleteInSport()
    {
        try
        {
            var sports = _sportService.GetAllSports().ToList();
            if (!sports.Any())
            {
                Console.Write("No sports available.\n");
                Pause();
                return;
            }

            Console.Write("\nAvailable sports:\n");
            foreach (var s in sports)
                Console.Write($"  {s.Id}: {s.Name}\n");

            Console.Write("Enter sport ID: ");
            if (!int.TryParse(Console.ReadLine(), out int sportId))
            {
                Console.Write("Invalid input. Please enter a number.\n");
                Pause();
                return;
            }

            var selectedSport = sports.FirstOrDefault(s => s.Id == sportId);
            if (selectedSport == null)
            {
                Console.Write("Sport not found.\n");
                Pause();
                return;
            }

            _statisticsService.DisplayBestAthleteInSport(selectedSport.Name);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void ShowMostFrequentHost()
    {
        _statisticsService.DisplayMostFrequentHostCountry();
        Pause();
    }

    private void ShowTeamOfCountry()
    {
        try
        {
            var countries = _countryService.GetAllCountries().ToList();
            if (!countries.Any())
            {
                Console.Write("No countries available.\n");
                Pause();
                return;
            }

            Console.Write("\nAvailable countries:\n");
            foreach (var c in countries)
            {

                Console.Write($"  {c.Id}: {c.Name}\n");
            }    

            Console.Write("Enter country ID: ");
            if (!int.TryParse(Console.ReadLine(), out int countryId))
            {
                Console.Write("Invalid input. Please enter a number.\n");
                Pause();
                return;
            }

            var selectedCountry = countries.FirstOrDefault(c => c.Id == countryId);
            if (selectedCountry == null)
            {
                Console.Write("Country not found.\n");
                Pause();
                return;
            }

            _statisticsService.DisplayTeamOfCountry(selectedCountry.Name);
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }

    private void ShowCountryStatisticsMenu()
    {
        try
        {
            Console.Write("1. For a specific Olympiad\n");
            Console.Write("2. All-time\n");
            string? choice = Console.ReadLine();

            var countries = _countryService.GetAllCountries().ToList();
            if (!countries.Any())
            {
                Console.Write("No countries available.\n");
                Pause();
                return;
            }

            Console.Write("\nAvailable countries:\n");
            foreach (var c in countries)
                Console.Write($"  {c.Id}: {c.Name}\n");

            Console.Write("Enter country ID: ");
            if (!int.TryParse(Console.ReadLine(), out int countryId))
            {
                Console.Write("Invalid input. Please enter a number.\n");
                Pause();
                return;
            }

            var selectedCountry = countries.FirstOrDefault(c => c.Id == countryId);
            if (selectedCountry == null)
            {
                Console.Write("Country not found.\n");
                Pause();
                return;
            }

            if (choice == "1")
            {
                var olympiads = _olympiadService.GetAllOlympiads().ToList();
                if (!olympiads.Any())
                {
                    Console.Write("No Olympiads available.\n");
                    Pause();
                    return;
                }

                Console.Write("\nAvailable Olympiads:\n");
                foreach (var o in olympiads)
                    Console.Write($"  {o.Id}: {o.Year} {o.Season} - {o.Country.Name} ({o.City.Name})\n");

                Console.Write("Enter Olympiad ID: ");
                if (int.TryParse(Console.ReadLine(), out int oid) && olympiads.Any(o => o.Id == oid))
                {
                    _statisticsService.DisplayCountryStatisticsForOlympiad(oid, selectedCountry.Name);
                }
                else
                {
                    Console.Write("Invalid ID.\n");
                }
            }
            else if (choice == "2")
            {
                _statisticsService.DisplayAllTimeCountryStatistics(selectedCountry.Name);
            }
        }
        catch (Exception)
        {
            throw;
        }
        Pause();
    }


}