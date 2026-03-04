

using OlympicApp.Models;

namespace OlympicApp.DTO;

public class MedalRowDto
{

    public Country Country { get; set; } = null!;
    public int Gold { get; set; }
    public int Silver { get; set; }
    public int Bronze { get; set; }
    public int Total { get; set; }
}
