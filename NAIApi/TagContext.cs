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
    public DbSet<DirTag>   DirTag   { get; set; }

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
        modelBuilder.Entity<Dir>().HasOne(_ => _.ParentDir).WithMany(_ => _.Dirs).HasForeignKey(_ => _.IdParent);
        modelBuilder.Entity<Dir>().HasMany(_ => _.Tags).WithMany(_ => _.Dirs).UsingEntity<DirTag>(x => x.HasOne(_ => _.Tag).WithMany(_ => _.DirTags).HasForeignKey(_ => _.TagsId),
                                                                                                  x => x.HasOne(_ => _.Dir).WithMany(_ => _.DirTags).HasForeignKey(_ => _.DirsId),
                                                                                                  x => x.HasKey(_ => new {_.DirsId, _.TagsId}));
        //base.OnModelCreating(modelBuilder); 
        //modelBuilder.Entity<Dir>().Ignore(_ => _.Dirs).Ignore(_ => _.Tags);
    }
}
