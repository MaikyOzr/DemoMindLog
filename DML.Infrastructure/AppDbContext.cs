using DML.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DML.Infrastructure;

public class AppDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    private readonly ILoggerFactory _loggerFactory;

    public AppDbContext(DbContextOptions<AppDbContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }

    public DbSet<JournalEntry> JournalEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your entity mappings here
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<JournalEntry>().ToTable("JournalEntries").HasKey(j=> j.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
        optionsBuilder.EnableSensitiveDataLogging(); // Enable sensitive data logging for debugging purposes, remove in production
        base.OnConfiguring(optionsBuilder);
    }
}
