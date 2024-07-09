using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_difficulty_id",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_region_id",
                table: "Walks");

            migrationBuilder.AlterColumn<Guid>(
                name: "region_id",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "difficulty_id",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_difficulty_id",
                table: "Walks",
                column: "difficulty_id",
                principalTable: "Difficulties",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_region_id",
                table: "Walks",
                column: "region_id",
                principalTable: "Regions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_difficulty_id",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_region_id",
                table: "Walks");

            migrationBuilder.AlterColumn<Guid>(
                name: "region_id",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "difficulty_id",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_difficulty_id",
                table: "Walks",
                column: "difficulty_id",
                principalTable: "Difficulties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_region_id",
                table: "Walks",
                column: "region_id",
                principalTable: "Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
