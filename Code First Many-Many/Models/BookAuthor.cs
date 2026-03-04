using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models;

public class BookAuthor
{
    
    public int BookId { get; set; }

    
    public int AuthorId { get; set; }

    [MaxLength(50)]
    public string Role { get; set; } 

    [Range(0, 100)]
    public int ContributionPercentage { get; set; }

    public DateTime AddedAt { get; set; } = DateTime.UtcNow; 

    
    public Book Book { get; set; }
    public Author Author { get; set; }
}
