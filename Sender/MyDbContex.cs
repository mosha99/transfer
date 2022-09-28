using Microsoft.EntityFrameworkCore;

namespace Sender;

public class MyDbContex : DbContext
{


    public DbSet<User> users { get; set; }
    public DbSet<Person> people { get; set; }
    public DbSet<Admin> admins { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=DbSender0256.db");
        base.OnConfiguring(optionsBuilder); 
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u=>u.dateTime);
            entity.HasKey(u=>u.UserId);
        });     
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasIndex(u=>u.dateTime);
            entity.HasKey(u=>u.AdminId);
        });    
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(u=>u.dateTime);
            entity.HasKey(u=>u.PersonId);
        });
        base.OnModelCreating(modelBuilder); 
    }
}
