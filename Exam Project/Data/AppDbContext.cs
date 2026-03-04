using Microsoft.EntityFrameworkCore;
using OlympicApp.Models;
using Microsoft.Extensions.Logging;


namespace OlympicApp.Data;

public class AppDbContext : DbContext
{

    public DbSet<Olympiad> Olympiads { get; set; }
    public DbSet<Sport> Sports { get; set; }
    public DbSet<Athlete> Athletes { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DIOR\MSSQLSERVER02;Initial Catalog=OlympiadDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").LogTo(Console.WriteLine, LogLevel.Information);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<City>()
            .HasOne(c => c.Country)
            .WithMany(c => c.Cities) 
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);








        modelBuilder.Entity<Olympiad>()
            .HasOne(o => o.Country)
            .WithMany()
            .HasForeignKey(o => o.CountryId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Olympiad>()
            .HasOne(o => o.City)
            .WithMany()
            .HasForeignKey(o => o.CityId)
            .OnDelete(DeleteBehavior.Restrict);


         



        modelBuilder.Entity<Athlete>()
            .HasOne(a => a.Country)
            .WithMany()
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.Restrict); 



         

      
        modelBuilder.Entity<Competition>()
            .HasOne(c => c.Sport)
            .WithMany(s => s.Competitions)
            .HasForeignKey(c => c.SportId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Athlete)
            .WithMany(a => a.Results)
            .HasForeignKey(r => r.AthleteId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Competition)
            .WithMany(c => c.Results)
            .HasForeignKey(r => r.CompetitionId)
            .OnDelete(DeleteBehavior.Restrict);





















        modelBuilder.Entity<Competition>()
            .HasOne(c => c.Olympiad)
            .WithMany(o => o.Competitions)
            .HasForeignKey(c => c.OlympiadId)
            .OnDelete(DeleteBehavior.Restrict);

        

        
    }





}