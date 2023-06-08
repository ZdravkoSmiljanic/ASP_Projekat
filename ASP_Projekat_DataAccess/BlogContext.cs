using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_Projekat_Domain
{
    public class BlogContext:DbContext
    {

        public BlogContext()
        {

        }
        public BlogContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=projekat_blog;Integrated Security=True;Pooling=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<Comment>().Property(x => x.CommentedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<BlogImages>().HasKey(x => new { x.BlogId,x.ImageId});
            modelBuilder.Entity<BlogReactions>().HasKey(x => new { x.ReactionId, x.BlogId,x.UserId });
            modelBuilder.Entity<RoleUseCases>().HasKey(x => new { x.RoleId, x.UseacaseId });
            modelBuilder.Entity<BlogTag>().HasKey(x => new { x.BlogId, x.TagId });
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImages> BlogImages { get; set; }
        public DbSet<BlogReactions> BlogReactions { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }


    }
}