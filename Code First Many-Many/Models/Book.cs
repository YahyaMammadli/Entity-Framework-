
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Program.Models;

public class Book
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal Price { get; set; }

    
    public ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
}
