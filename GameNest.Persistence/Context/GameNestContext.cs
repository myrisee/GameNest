using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameNest.Persistence.Context
{
    public class GameNestContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemInstance> ItemInstances { get; set; }
        public DbSet<Loadout> Loadouts { get; set; }
        public DbSet<Clan> Clans { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4NJ0E9G;Database=GameNest;integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(x => x.Loadout)
                .WithOne(y => y.Player)
                .HasForeignKey<Player>(z => z.LoadoutId)
                .IsRequired(false);

            modelBuilder.Entity<Player>()
                .HasOne(x => x.Clan)
                .WithMany(y => y.Members)
                .HasForeignKey(z => z.ClanId)
                .IsRequired(false);

            modelBuilder.Entity<ItemInstance>()
                .HasOne(x => x.Player)
                .WithMany(y => y.Items)
                .HasForeignKey(z => z.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ItemInstance>()
                .HasOne(x => x.Item);
        }
    }
}
