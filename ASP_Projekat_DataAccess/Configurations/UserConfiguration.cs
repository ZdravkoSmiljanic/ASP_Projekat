using ASP_Projekat_DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
    

            builder.Property(x => x.Surname).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x=>x.BlogReactions).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(x => x.Image).WithMany(x => x.Users).HasForeignKey(x => x.ProfileImgId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.Blogs).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
