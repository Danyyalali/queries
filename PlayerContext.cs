using Microsoft.EntityFrameworkCore;
using System;

namespace LINQMANIPULATION
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerContext() : base()
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=PlayersDataBase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Player>().HasQueryFilter(b => b.age==40 && b.nationality=="pakistani");
        }
    }
}
