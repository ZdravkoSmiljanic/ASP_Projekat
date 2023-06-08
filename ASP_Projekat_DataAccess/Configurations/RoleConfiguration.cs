using ASP_Projekat_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Configurations
{
    public class RoleConfiguration : EntityConfiguration<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.RoleName).IsUnique();
            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
