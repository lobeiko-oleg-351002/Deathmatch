using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Models.InitialSeed
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
            (
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                }
            );
        }
    }
}
