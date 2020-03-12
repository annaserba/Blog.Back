using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Admin.Migrations
{
    public partial class ChangeFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Feeds");

            migrationBuilder.AddColumn<bool>(
                name: "CommentStatus",
                table: "Feeds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Feeds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "Feeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Feeds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Feeds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentStatus",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Feeds");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Feeds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Feeds",
                type: "text",
                nullable: true);
        }
    }
}
