using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Admin.Migrations
{
    public partial class AddSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Feeds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Feeds");
        }
    }
}
