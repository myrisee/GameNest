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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemInstance> ItemInstances { get; set; }
        public DbSet<Loadout> Loadouts { get; set; }
        public DbSet<Clan> Clans { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GameNest;integrated Security=True;TrustServerCertificate=True;");
            //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(x => x.Loadout)
                .WithOne(y => y.Account)
                .HasForeignKey<Loadout>(z => z.AccountId)
                .IsRequired(true);

            modelBuilder.Entity<Account>()
                .HasOne(x => x.Clan)
                .WithMany(y => y.Members)
                .HasForeignKey(z => z.ClanId)
                .IsRequired(false);

            modelBuilder.Entity<ItemInstance>()
                .HasOne(x => x.Account)
                .WithMany(y => y.Items)
                .HasForeignKey(z => z.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ItemInstance>()
                .HasOne(x => x.Item);

            modelBuilder.Entity<Loadout>()
                .HasOne(l => l.Main)
                .WithMany()
                .HasForeignKey("MainId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loadout>()
                .HasOne(l => l.Secondary)
                .WithMany()
                .HasForeignKey("SecondaryId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loadout>()
                .HasOne(l => l.Chest)
                .WithMany()
                .HasForeignKey("ChestId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loadout>()
                .HasOne(l => l.Helmet)
                .WithMany()
                .HasForeignKey("HelmetId")
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Items: 10 weapons, 5 equipment (all in English)
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "AK-47", Description = "Assault rifle", Rarity = 1, Level = 1, CoinPrice = 1000, CashPrice = 100 },
                new Item { Id = 2, Name = "M4A1", Description = "Submachine gun", Rarity = 2, Level = 2, CoinPrice = 1200, CashPrice = 120 },
                new Item { Id = 3, Name = "AWP", Description = "Sniper rifle", Rarity = 3, Level = 5, CoinPrice = 2000, CashPrice = 200 },
                new Item { Id = 4, Name = "Desert Eagle", Description = "Pistol", Rarity = 1, Level = 1, CoinPrice = 500, CashPrice = 50 },
                new Item { Id = 5, Name = "UMP-45", Description = "Submachine gun", Rarity = 2, Level = 2, CoinPrice = 900, CashPrice = 90 },
                new Item { Id = 6, Name = "Glock-18", Description = "Pistol", Rarity = 1, Level = 1, CoinPrice = 400, CashPrice = 40 },
                new Item { Id = 7, Name = "FAMAS", Description = "Assault rifle", Rarity = 2, Level = 3, CoinPrice = 1100, CashPrice = 110 },
                new Item { Id = 8, Name = "MP5", Description = "Submachine gun", Rarity = 2, Level = 2, CoinPrice = 950, CashPrice = 95 },
                new Item { Id = 9, Name = "SG 553", Description = "Assault rifle", Rarity = 3, Level = 4, CoinPrice = 1300, CashPrice = 130 },
                new Item { Id = 10, Name = "M249", Description = "Machine gun", Rarity = 4, Level = 6, CoinPrice = 2500, CashPrice = 250 },
                // Equipment
                new Item { Id = 11, Name = "Helmet", Description = "Head protection equipment", Rarity = 1, Level = 1, CoinPrice = 300, CashPrice = 30 },
                new Item { Id = 12, Name = "Body Armor", Description = "Body armor equipment", Rarity = 2, Level = 2, CoinPrice = 600, CashPrice = 60 },
                new Item { Id = 13, Name = "Grenade", Description = "Explosive equipment", Rarity = 1, Level = 1, CoinPrice = 200, CashPrice = 20 },
                new Item { Id = 14, Name = "Scope", Description = "Sniper scope equipment", Rarity = 2, Level = 3, CoinPrice = 800, CashPrice = 80 },
                new Item { Id = 15, Name = "Tactical Gloves", Description = "Gloves equipment", Rarity = 1, Level = 1, CoinPrice = 150, CashPrice = 15 }
            );
        }
    }
}
