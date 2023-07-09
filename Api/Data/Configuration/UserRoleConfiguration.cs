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
            new() { Id = Guid.NewGuid(), Name = "Administrator"   , NormalizedName = "admin"   },
            new() { Id = Guid.NewGuid(), Name = "ContentModerator", NormalizedName = "mod"     },
            new() { Id = Guid.NewGuid(), Name = "RegisteredUser"  , NormalizedName = "user"    },
            new() { Id = Guid.NewGuid(), Name = "UnregisteredUser", NormalizedName = "visitor" },
        });
    }
}