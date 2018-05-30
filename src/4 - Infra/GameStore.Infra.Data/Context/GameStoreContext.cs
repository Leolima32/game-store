using System;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.ReleationshipEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infra.Data.Context
{
    public class GameStoreContext : IdentityDbContext
    {

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
        : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Plataform> Plataforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDeveloper>().HasKey(t => new { t.GameId, t.DeveloperId });

            modelBuilder.Entity<GameDeveloper>()
            .HasOne(gg => gg.Game)
            .WithMany("GameDevelopers");

            modelBuilder.Entity<GameDeveloper>()
                .HasOne(gg => gg.Developer)
                .WithMany("GameDevelopers");

            modelBuilder.Entity<GameGenre>().HasKey(t => new { t.GameId, t.GenreId });

            modelBuilder.Entity<GameGenre>()
            .HasOne(gg => gg.Game)
            .WithMany("GameGenres");

            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Genre)
                .WithMany("GameGenres");

            modelBuilder.Entity<GamePlataform>().HasKey(t => new { t.GameId, t.PlataformId });

            modelBuilder.Entity<GamePlataform>()
            .HasOne(gp => gp.Game)
            .WithMany("GamePlataforms");

            modelBuilder.Entity<GamePlataform>()
                .HasOne(gp => gp.Plataform)
                .WithMany("GamePlataforms");

            modelBuilder.Entity<GamePublisher>().HasKey(t => new { t.GameId, t.PublisherId });

            modelBuilder.Entity<GamePublisher>()
            .HasOne(gg => gg.Game)
            .WithMany("GamePublishers");

            modelBuilder.Entity<GamePublisher>()
                .HasOne(gg => gg.Publisher)
                .WithMany("GamePublishers");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("CreatedDate").IsModified = false;
                    }
                }
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("LastUpdated") != null))
                {
                    entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                }
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Active") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Active").CurrentValue = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return base.SaveChanges();
        }

    }
}