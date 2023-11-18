using domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infrastructure
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions options) : base(options)
        { }

        public DbSet<Follow> Follow { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<tweetPost> tweetPosts { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<ApplicationUser> User { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<tweetPost>()
        //        .HasOne(tp => tp.Retweet)
        //        .WithMany(tp => tp.Reposts)
        //        .HasForeignKey(tp => tp.retweetId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //}
    }
}