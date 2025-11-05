using Microsoft.EntityFrameworkCore;
using UserManagement.Api.Models;

namespace UserManagement.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(256).IsRequired();
            entity.Property(e => e.CreatedAtUtc).HasDefaultValueSql("GETUTCDATE()");
            entity.Property(e => e.UpdatedAtUtc).HasDefaultValueSql("GETUTCDATE()");
            entity.HasIndex(e => e.Email).IsUnique();
        });
    }
}
