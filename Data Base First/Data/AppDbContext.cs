using Microsoft.EntityFrameworkCore;
using Users;
using Posts;


namespace Data.AppDbContext;

class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DIOR\MSSQLSERVER02;Initial Catalog=SocialMediaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
