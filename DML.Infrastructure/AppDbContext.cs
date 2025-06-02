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
        _loggerFactory = loggerFactory;
    }
    
    public DbSet<User> Users { get; set; }

    public DbSet<JournalEntry> JournalEntries { get; set; }

    public DbSet<JournalEntryTag> JournalEntryTags { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your entity mappings here
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<JournalEntry>().ToTable("JournalEntries").HasKey(j=> j.Id);
        modelBuilder.Entity<JournalEntryTag>().ToTable("JournalEntryTags").HasKey(jt => new {jt.JournalEntryId, jt.TagId });
        modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(t => t.Id);
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
