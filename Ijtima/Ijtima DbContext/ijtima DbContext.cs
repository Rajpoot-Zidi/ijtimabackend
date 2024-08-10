using Ijtima.models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Registration> Registrations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
    }
}