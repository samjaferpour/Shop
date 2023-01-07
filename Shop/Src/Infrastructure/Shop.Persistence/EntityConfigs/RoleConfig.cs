using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EntityConfigs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Users).WithOne(x => x.Role);

            builder.HasData(new Role { Id = Guid.NewGuid(), Name = "Admin" });
            builder.HasData(new Role { Id =Guid.NewGuid(), Name = "Public" });
        }
    }
}
