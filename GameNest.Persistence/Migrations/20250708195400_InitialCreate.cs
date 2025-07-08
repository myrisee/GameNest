using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameNest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rarity = table.Column<long>(type: "bigint", nullable: false),
                    Level = table.Column<long>(type: "bigint", nullable: false),
                    CoinPrice = table.Column<long>(type: "bigint", nullable: false),
                    CashPrice = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Coin = table.Column<int>(type: "int", nullable: false),
                    Cash = table.Column<int>(type: "int", nullable: false),
                    LoadoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInstances_Accounts_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemInstances_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loadouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HelmetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loadouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loadouts_ItemInstances_ChestId",
                        column: x => x.ChestId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loadouts_ItemInstances_HelmetId",
                        column: x => x.HelmetId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loadouts_ItemInstances_MainId",
                        column: x => x.MainId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loadouts_ItemInstances_SecondaryId",
                        column: x => x.SecondaryId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CashPrice", "CoinPrice", "Description", "Level", "Name", "Rarity" },
                values: new object[,]
                {
                    { 1L, 100L, 1000L, "Assault rifle", 1L, "AK-47", 1L },
                    { 2L, 120L, 1200L, "Submachine gun", 2L, "M4A1", 2L },
                    { 3L, 200L, 2000L, "Sniper rifle", 5L, "AWP", 3L },
                    { 4L, 50L, 500L, "Pistol", 1L, "Desert Eagle", 1L },
                    { 5L, 90L, 900L, "Submachine gun", 2L, "UMP-45", 2L },
                    { 6L, 40L, 400L, "Pistol", 1L, "Glock-18", 1L },
                    { 7L, 110L, 1100L, "Assault rifle", 3L, "FAMAS", 2L },
                    { 8L, 95L, 950L, "Submachine gun", 2L, "MP5", 2L },
                    { 9L, 130L, 1300L, "Assault rifle", 4L, "SG 553", 3L },
                    { 10L, 250L, 2500L, "Machine gun", 6L, "M249", 4L },
                    { 11L, 30L, 300L, "Head protection equipment", 1L, "Helmet", 1L },
                    { 12L, 60L, 600L, "Body armor equipment", 2L, "Body Armor", 2L },
                    { 13L, 20L, 200L, "Explosive equipment", 1L, "Grenade", 1L },
                    { 14L, 80L, 800L, "Sniper scope equipment", 3L, "Scope", 2L },
                    { 15L, 15L, 150L, "Gloves equipment", 1L, "Tactical Gloves", 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClanId",
                table: "Accounts",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LoadoutId",
                table: "Accounts",
                column: "LoadoutId",
                unique: true,
                filter: "[LoadoutId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ItemId",
                table: "ItemInstances",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_PlayerId",
                table: "ItemInstances",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loadouts_ChestId",
                table: "Loadouts",
                column: "ChestId");

            migrationBuilder.CreateIndex(
                name: "IX_Loadouts_HelmetId",
                table: "Loadouts",
                column: "HelmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Loadouts_MainId",
                table: "Loadouts",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_Loadouts_SecondaryId",
                table: "Loadouts",
                column: "SecondaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Loadouts_LoadoutId",
                table: "Accounts",
                column: "LoadoutId",
                principalTable: "Loadouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clans_ClanId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Loadouts_LoadoutId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropTable(
                name: "Loadouts");

            migrationBuilder.DropTable(
                name: "ItemInstances");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
