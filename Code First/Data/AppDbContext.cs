using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 
using Program.Models.Prod; 

namespace Propgram.Data;
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DIOR\MSSQLSERVER02;Initial Catalog=EfCore_CodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(9, 2);

        
    }
}