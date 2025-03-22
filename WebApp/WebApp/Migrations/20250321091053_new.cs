using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Category_CaregoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CaregoryId",
                table: "Items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CaregoryId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Category_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Category_CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Items",
                newName: "CaregoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                newName: "IX_Items_CaregoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Category_CaregoryId",
                table: "Items",
                column: "CaregoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
