using KirillMihailovKt_42_20.Database.Configuration;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace KirillMihailovKt_42_20.Database
{
    public class PrepodDbContext : DbContext
    {
        public DbSet<Kafedra> Kafedra { get; set; }
        public DbSet<Prepod> Prepod { get; set; }
        public DbSet<AcademicDegree> AcademicDegree { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
        }
        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options) 
        {

        }
    }
}
