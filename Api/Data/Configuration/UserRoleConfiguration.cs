using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole").HasData(new List<UserRole>()
        {
            new() { Id = Guid.NewGuid(), Name = "Administrator"    , NormalizedName = "admin"   },
            new() { Id = Guid.NewGuid(), Name = "Content Moderator", NormalizedName = "mod"     },
            new() { Id = Guid.NewGuid(), Name = "Registered User"  , NormalizedName = "user"    },
            new() { Id = Guid.NewGuid(), Name = "Unregistered User", NormalizedName = "visitor" },
        });
    }
}