using ASP_Projekat_DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Configurations
{
    public class ReactionConfiguration : EntityConfiguration<Reaction>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(x => x.ReactionName).IsRequired().HasMaxLength(40);
            builder.HasIndex(x => x.ReactionName).IsUnique();


            builder.HasMany(x => x.BlogReactions).WithOne(x => x.Reaction).HasForeignKey(x => x.ReactionId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
