using Microsoft.EntityFrameworkCore;
using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Infrastructure.Config;

namespace PitchData.Database.Context
{
    public class PitchDataDatabaseContext : DbContext
    {
        public PitchDataDatabaseContext(DbContextOptions<PitchDataDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionStrings?.PitchDataDatabase);

            if (AppConfig.ConsoleLogQueries)
            {
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.NationalTeam)
                .WithMany(nt => nt.Players)
                .HasForeignKey(p => p.NationalTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InternationalTrophy>()
                .HasOne(it => it.WinnerTeam)
                .WithMany(nt => nt.TrophiesWon)
                .HasForeignKey(it => it.NationalTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.ClubTeam)
                .WithMany(c => c.Players)
                .HasForeignKey(p => p.ClubTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClubTrophy>()
                .HasOne(t => t.WinnerTeam)
                .WithMany(c => c.TrophiesWon)
                .HasForeignKey(t => t.ClubTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<ClubTeam> ClubTeams { get; set; }
        public DbSet<NationalTeam> NationalTeams { get; set; }
        public DbSet<InternationalTrophy> InternationalTrophies { get; set; }
        public DbSet<ClubTrophy> ClubTrophies { get; set; }
        public DbSet<Coach> Coaches { get; set; }
    }
}
