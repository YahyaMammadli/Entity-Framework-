using Microsoft.EntityFrameworkCore;
using Program.Models;


namespace Program.Data;

public class AppDbContext : DbContext
{
    

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DIOR\MSSQLSERVER02;Initial Catalog=BookDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(a => a.FirstName).HasMaxLength(150);
            entity.Property(a => a.LastName).HasMaxLength(150);
            entity.Property(a => a.Email).HasMaxLength(150);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(b => b.Title).HasMaxLength(200);
            entity.Property(b => b.Description).HasMaxLength(500);
            entity.Property(b => b.Price).HasColumnType("decimal(9,2)");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.Property(ba => ba.Role).HasMaxLength(50);
            
        });

        
        
    }

    






}
