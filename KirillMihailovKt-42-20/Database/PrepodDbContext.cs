using KirillMihailovKt_42_20.Database.Configuration;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace KirillMihailovKt_42_20.Database
{
    public class PrepodDbContext : DbContext
    {
        DbSet<Kafedra> Kafedra { get; set; }
        DbSet<Prepod> Prepod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
        }
        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options) 
        {
        }
    }
}
