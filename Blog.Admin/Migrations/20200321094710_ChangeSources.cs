using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.Admin.Migrations
{
    public partial class ChangeSources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Source_Feeds_FeedID",
                table: "Source");

            migrationBuilder.DropIndex(
                name: "IX_Source_FeedID",
                table: "Source");

            migrationBuilder.DropColumn(
                name: "FeedID",
                table: "Source");

            migrationBuilder.CreateTable(
                name: "FeedSource",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedID = table.Column<int>(nullable: false),
                    SourceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedSource", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FeedSource_Feeds_FeedID",
                        column: x => x.FeedID,
                        principalTable: "Feeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedSource_Source_SourceID",
                        column: x => x.SourceID,
                        principalTable: "Source",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedSource_FeedID",
                table: "FeedSource",
                column: "FeedID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedSource_SourceID",
                table: "FeedSource",
                column: "SourceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedSource");

            migrationBuilder.AddColumn<int>(
                name: "FeedID",
                table: "Source",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Source_FeedID",
                table: "Source",
                column: "FeedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Source_Feeds_FeedID",
                table: "Source",
                column: "FeedID",
                principalTable: "Feeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
