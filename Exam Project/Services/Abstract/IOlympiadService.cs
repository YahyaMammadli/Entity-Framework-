using OlympicApp.Models;

namespace OlympicApp.Services.Abstract;

public interface IOlympiadService
{
    Olympiad? GetOlympiadById(int id);
    IEnumerable<Olympiad> GetAllOlympiads();
    void AddOlympiad(Olympiad olympiad);
    void UpdateOlympiad(Olympiad olympiad);
    void DeleteOlympiad(int id);
}