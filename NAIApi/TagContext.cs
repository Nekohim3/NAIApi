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

    public TagContext(bool resetDatabase = false) 
    {
        if (resetDatabase)
            Database.EnsureDeleted();
        
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=NovelAIHelper;Username=postgres;Password=KuroNeko2112@");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        //modelBuilder.Entity<Dir>().Ignore(_ => _.Dirs).Ignore(_ => _.Tags);
    }
}
