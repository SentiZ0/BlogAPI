using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

       // public DbSet<Author_Post> Author_Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Post>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Author_Posts)
                .HasForeignKey(b1 => b1.AuthorId);

            modelBuilder.Entity<Author_Post>()
                .HasOne(b => b.Post)
                .WithMany(ba => ba.Author_Posts)
                .HasForeignKey(b1 => b1.PostId);
        }

    }
}
