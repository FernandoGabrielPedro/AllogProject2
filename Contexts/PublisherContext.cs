using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AllogProject2.Api.Entities;

namespace AllogProject2.Api.Contexts;

public class PublisherContext : DbContext
{
    public DbSet<Publisher> Pulishers {get; set;} = null!;
    public DbSet<Author> Authors {get; set;} = null!;
    public DbSet<Course> Courses {get; set;} = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=AllogProject2.Api;Username=postgres;Password=123456"
        ).LogTo(Console.WriteLine,
        new[] {DbLoggerCategory.Database.Command.Name},
        LogLevel.Information)
        .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var author = modelBuilder.Entity<Author>();

        author
            .Property(a => a.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        author
            .Property(a => a.LastName)
            .HasMaxLength(30)
            .IsRequired();

        
        var course = modelBuilder.Entity<Course>();

        course
            .Property(c => c.Title)
            .HasMaxLength(60)
            .IsRequired();

        course
            .Property(c => c.Price)
            .HasPrecision(5,2)
            .HasColumnName("BasePrice")
            .IsRequired();

        course
            .Property(c => c.Description)
            .IsRequired(false);
    }
}