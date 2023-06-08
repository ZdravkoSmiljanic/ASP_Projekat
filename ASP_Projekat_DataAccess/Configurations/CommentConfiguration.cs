using ASP_Projekat_DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Configurations
{
    public class CommentConfiguration : EntityConfiguration<Comment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BlogId).IsRequired();
            builder.Property(x => x.TextComment).IsRequired().HasMaxLength(1024);
            builder.HasIndex(x => x.TextComment);

            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.ChildComments).WithOne(x => x.ParentCommnet).HasForeignKey(x => x.ParentId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
