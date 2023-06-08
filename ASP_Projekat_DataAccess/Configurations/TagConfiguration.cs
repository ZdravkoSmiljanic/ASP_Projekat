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
    public class TagConfiguration : EntityConfiguration<Tag>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.TagText).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.TagText).IsUnique();

            builder.HasMany(x => x.BlogTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
