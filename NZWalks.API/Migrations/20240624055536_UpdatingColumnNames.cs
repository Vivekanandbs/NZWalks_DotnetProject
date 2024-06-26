using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Walks",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Walks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Walks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WalkImageUrl",
                table: "Walks",
                newName: "walk_image_url");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Walks",
                newName: "region_id");

            migrationBuilder.RenameColumn(
                name: "LengthInKm",
                table: "Walks",
                newName: "length_in_km");

            migrationBuilder.RenameColumn(
                name: "DifficultyId",
                table: "Walks",
                newName: "difficulty_id");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                newName: "IX_Walks_region_id");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                newName: "IX_Walks_difficulty_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Regions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Regions",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Regions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegionImageUrl",
                table: "Regions",
                newName: "region_image_url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Difficulties",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Difficulties",
                newName: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_difficulty_id",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_region_id",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Walks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Walks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Walks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "walk_image_url",
                table: "Walks",
                newName: "WalkImageUrl");

            migrationBuilder.RenameColumn(
                name: "region_id",
                table: "Walks",
                newName: "RegionId");

            migrationBuilder.RenameColumn(
                name: "length_in_km",
                table: "Walks",
                newName: "LengthInKm");

            migrationBuilder.RenameColumn(
                name: "difficulty_id",
                table: "Walks",
                newName: "DifficultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_region_id",
                table: "Walks",
                newName: "IX_Walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_difficulty_id",
                table: "Walks",
                newName: "IX_Walks_DifficultyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Regions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Regions",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Regions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "region_image_url",
                table: "Regions",
                newName: "RegionImageUrl");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Difficulties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Difficulties",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
