using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_user_type",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "user_type",
                table: "User",
                newName: "user_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_User_user_type",
                table: "User",
                newName: "IX_User_user_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_user_type_id",
                table: "User",
                column: "user_type_id",
                principalTable: "UserType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_user_type_id",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "user_type_id",
                table: "User",
                newName: "user_type");

            migrationBuilder.RenameIndex(
                name: "IX_User_user_type_id",
                table: "User",
                newName: "IX_User_user_type");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_user_type",
                table: "User",
                column: "user_type",
                principalTable: "UserType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
