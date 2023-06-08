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
    public class ImageConfiguration : EntityConfiguration<Image>
    {

        protected override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageSize).IsRequired();
            builder.HasIndex(x => x.ImagePath).IsUnique();

            builder.HasMany(x => x.BlogImages).WithOne(x => x.Image).HasForeignKey(x => x.ImageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Users).WithOne(x => x.Image).HasForeignKey(x => x.ProfileImgId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
