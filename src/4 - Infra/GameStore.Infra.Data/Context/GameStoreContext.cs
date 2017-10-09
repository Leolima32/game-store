﻿using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infra.Data.Context
{
    public class GameStoreContext : DbContext
    {

        public GameStoreContext(DbContextOptions<GameStoreContext> options) 
        : base (options) { this.Database.EnsureCreated(); }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Plataform> Plataforms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}