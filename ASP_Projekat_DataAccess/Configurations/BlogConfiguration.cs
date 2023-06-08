using ASP_Projekat_DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Configurations
{
    public class BlogConfiguration : EntityConfiguration<Blog>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BlogText).IsRequired().HasMaxLength(1024);
            builder.HasIndex(x => x.BlogText);

            builder.HasOne(x => x.User).WithMany(x => x.Blogs).HasForeignKey(x => x.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasMany(x => x.BlogTags).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.Comments).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.BlogImages).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.BlogReactions).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
