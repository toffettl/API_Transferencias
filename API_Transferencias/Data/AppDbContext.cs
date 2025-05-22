using API_Transferencias.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Transferencias.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.Transfers> Transfers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Models.User>()
            .HasKey(u => u.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.SentTransfers)
            .WithOne(t => t.UserSubmitted)
            .HasForeignKey(t => t.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.IncomingTransfers)
            .WithOne(t => t.UserReceived)
            .HasForeignKey(t => t.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
