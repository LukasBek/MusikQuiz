using MusikQuiz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace MusikQuiz.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Sound> Sound { get; set; }
        public DbSet<Tag> Tag { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Quiz>().ToTable("Quiz");
            modelBuilder.Entity<Sound>().ToTable("Sound");
        }


        
    }
}
