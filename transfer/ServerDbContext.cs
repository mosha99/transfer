using Microsoft.EntityFrameworkCore;

using Share;

namespace transfer;
public class ServerDbContext : DbContext
{


    public DbSet<User> users { get; set; }
    public DbSet<Person> people { get; set; }
    public DbSet<Admin> admins { get; set; }
    public DbSet<TransferrEdntities> transferrEdntities { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=DbSender0256.db");
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.dateTime);
            entity.HasKey(u => u.UserId);
        });
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasIndex(u => u.dateTime);
            entity.HasKey(u => u.AdminId);
        });
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(u => u.dateTime);
            entity.HasKey(u => u.PersonId);
        });  
        modelBuilder.Entity<TransferrEdntities>(entity =>
        {
            entity.HasIndex(u => u.EntityGuid);
            entity.HasKey(u => u.TransferrEdntitiesId);
        });
        base.OnModelCreating(modelBuilder);
    }
}
