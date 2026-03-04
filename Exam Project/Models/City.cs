using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OlympicApp.Models;

public class City
{

    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}
