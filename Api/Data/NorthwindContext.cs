using Api.Data.Configuration;
using Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class NorthwindContext : IdentityDbContext<User, UserRole, Guid>
{
    public NorthwindContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderEntry> OrderEntries { get; set; }

    public DbSet<Review> Reviews { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // table name change
        modelBuilder.Entity<User>().ToTable("Users");
        // modelBuilder.Entity<UserRole>().ToTable("Roles"); // already configuring in the seeding part.
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

        // seed data
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}