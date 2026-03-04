using System.ComponentModel.DataAnnotations;


namespace OlympicApp.Models
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public ICollection<City> Cities { get; set; } = null!;
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
