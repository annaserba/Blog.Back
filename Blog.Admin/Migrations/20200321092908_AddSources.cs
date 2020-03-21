using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.Admin.Migrations
{
    public partial class AddSources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Feeds");

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URL = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FeedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Source_Feeds_FeedID",
                        column: x => x.FeedID,
                        principalTable: "Feeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Source_FeedID",
                table: "Source",
                column: "FeedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Feeds",
                type: "text",
                nullable: true);
        }
    }
}
