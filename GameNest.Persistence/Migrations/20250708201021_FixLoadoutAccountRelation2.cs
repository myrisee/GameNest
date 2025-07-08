using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameNest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixLoadoutAccountRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Loadouts_LoadoutId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_LoadoutId",
                table: "Accounts");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Loadouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Loadouts_AccountId",
                table: "Loadouts",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loadouts_Accounts_AccountId",
                table: "Loadouts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loadouts_Accounts_AccountId",
                table: "Loadouts");

            migrationBuilder.DropIndex(
                name: "IX_Loadouts_AccountId",
                table: "Loadouts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Loadouts");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LoadoutId",
                table: "Accounts",
                column: "LoadoutId",
                unique: true,
                filter: "[LoadoutId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Loadouts_LoadoutId",
                table: "Accounts",
                column: "LoadoutId",
                principalTable: "Loadouts",
                principalColumn: "Id");
        }
    }
}
