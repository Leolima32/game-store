using System;
using System.Linq;
using System.Reflection;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.ReleationshipEntities;
using GameStore.Domain.ValueObjects;
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
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }
        public DbSet<PayPalPayment> PayPalPayments { get; set; }
        public DbSet<Review> Reviews { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDeveloper>().HasKey(t => new { t.GameId, t.DeveloperId });

            modelBuilder.Entity<Payment>().OwnsOne(typeof(Email), "Email");

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

            modelBuilder.Entity<GamePlatform>().HasKey(t => new { t.GameId, t.PlatformId });

            modelBuilder.Entity<GamePlatform>()
            .HasOne(gp => gp.Game)
            .WithMany("GamePlatforms");

            modelBuilder.Entity<GamePlatform>()
                .HasOne(gp => gp.Platform)
                .WithMany("GamePlatforms");

            modelBuilder.Entity<GamePublisher>().HasKey(t => new { t.GameId, t.PublisherId });

            modelBuilder.Entity<GamePublisher>()
            .HasOne(gg => gg.Game)
            .WithMany("GamePublishers");

            modelBuilder.Entity<GamePublisher>()
                .HasOne(gg => gg.Publisher)
                .WithMany("GamePublishers");


            modelBuilder.Entity<ShoppingCart>()
            .HasOne(s => s.Order)
            .WithMany()
            .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<ShoppingCart>()
            .HasMany(x => x.ListOfItems)
            .WithOne(_ => _.ShoppingCart)
            .HasForeignKey(f => f.ShoppingCartId);

            modelBuilder.Entity<CartItem>()
            .HasOne(_ => _.ShoppingCart)
            .WithMany(x => x.ListOfItems)
            .HasForeignKey(f => f.ShoppingCartId);

            modelBuilder.Entity<CartItem>()
            .HasOne(_ => _.Product)
            .WithMany()
            .HasForeignKey(f => f.ProductId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
            .HasOne(_ =>_.Product)
            .WithMany(_ => _.Reviews)
            .HasForeignKey(_ => _.ProductId);
            
        }

        public override int SaveChanges()
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
            return base.SaveChanges();
        }
    }
}