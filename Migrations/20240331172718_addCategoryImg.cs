using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_MVC.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Categories");
        }
    }
}
