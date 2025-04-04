﻿// <auto-generated />
using System;
using GameNest.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameNest.Persistence.Migrations
{
    [DbContext(typeof(GameNestContext))]
    [Migration("20240229180704_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameNest.Domain.Entities.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CashPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("CoinPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Level")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Rarity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.ItemInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PlayerId");

                    b.ToTable("ItemInstances");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.Loadout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MainId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MainId");

                    b.ToTable("Loadouts");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cash")
                        .HasColumnType("int");

                    b.Property<int>("Coin")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid?>("LoadoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoadoutId")
                        .IsUnique()
                        .HasFilter("[LoadoutId] IS NOT NULL");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.ItemInstance", b =>
                {
                    b.HasOne("GameNest.Domain.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameNest.Domain.Entities.Player", "Player")
                        .WithMany("Items")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.Loadout", b =>
                {
                    b.HasOne("GameNest.Domain.Entities.ItemInstance", "Main")
                        .WithMany()
                        .HasForeignKey("MainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Main");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.Player", b =>
                {
                    b.HasOne("GameNest.Domain.Entities.Loadout", "Loadout")
                        .WithOne("Player")
                        .HasForeignKey("GameNest.Domain.Entities.Player", "LoadoutId");

                    b.Navigation("Loadout");
                });

            modelBuilder.Entity("GameNest.Domain.Entities.Loadout", b =>
                {
                    b.Navigation("Player")
                        .IsRequired();
                });

            modelBuilder.Entity("GameNest.Domain.Entities.Player", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
