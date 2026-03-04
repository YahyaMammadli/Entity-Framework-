
using System.ComponentModel.DataAnnotations;

namespace Program.Models;

public class Author
{
    public int Id { get; set; }

    [MaxLength(150)]
    public string FirstName { get; set; }

    [MaxLength(150)]
    public string LastName { get; set; }

    [MaxLength(150)]
    public string Email { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
}
