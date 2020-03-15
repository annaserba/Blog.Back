using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Admin.Migrations
{
    public partial class addExcerpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "Categories");
        }
    }
}
