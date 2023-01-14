using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using NAIApi.Models;

namespace NAIApi;

public class TagContext : DbContext
{
    public DbSet<Dir>      Dirs      { get; set; }
    public DbSet<Tag>      Tags      { get; set; }
    public DbSet<Session>  Sessions  { get; set; }
    public DbSet<Group>    Groups    { get; set; }
    public DbSet<GroupTag> GroupTags { get; set; }
    public DbSet<DirTag>   DirTag    { get; set; }

    public bool      IsValid   { get; set; }
    public Exception Exception { get; set; }

    public TagContext(bool resetDatabase = false)
    {
        try
        {
            if (resetDatabase)
                Database.EnsureDeleted();

            Database.EnsureCreated();
            IsValid = true;
        }
        catch (Exception e)
        {
            IsValid   = false;
            Exception = e;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (g.DatabaseSettings == null)
            return;
        optionsBuilder.UseNpgsql($"Host={g.DatabaseSettings.DatabaseHost};"         +
                                 $"Port={g.DatabaseSettings.DatabasePort};"         +
                                 $"Database={g.DatabaseSettings.DatabaseName};"     +
                                 $"Username={g.DatabaseSettings.DatabaseUsername};" +
                                 $"Password={g.DatabaseSettings.DatabasePassword}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dir>()
                    .HasOne(_ => _.ParentDir)
                    .WithMany(_ => _.Dirs)
                    .HasForeignKey(_ => _.IdParent);

        modelBuilder.Entity<Dir>()
                    .HasMany(_ => _.Tags)
                    .WithMany(_ => _.Dirs)
                    .UsingEntity<DirTag>(x => x.HasOne(_ => _.Second).WithMany(_ => _.DirTags).HasForeignKey(_ => _.IdSecond),
                                         x => x.HasOne(_ => _.First).WithMany(_ => _.DirTags).HasForeignKey(_ => _.IdFirst),
                                         x => x.HasKey(_ => new {_.IdFirst, _.IdSecond}));

        modelBuilder.Entity<Tag>().HasIndex(_ => _.Name).IsUnique();

        //base.OnModelCreating(modelBuilder); 
        //modelBuilder.Entity<Dir>().Ignore(_ => _.Dirs).Ignore(_ => _.Tags);
    }
}
