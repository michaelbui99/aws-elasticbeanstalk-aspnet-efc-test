using Domain;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Book>? Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStringGenerator.GetConnectionString());
    }
}