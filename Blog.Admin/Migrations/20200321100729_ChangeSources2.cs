using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Admin.Migrations
{
    public partial class ChangeSources2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedSource_Feeds_FeedID",
                table: "FeedSource");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedSource_Source_SourceID",
                table: "FeedSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Source",
                table: "Source");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedSource",
                table: "FeedSource");

            migrationBuilder.RenameTable(
                name: "Source",
                newName: "Sources");

            migrationBuilder.RenameTable(
                name: "FeedSource",
                newName: "FeedSources");

            migrationBuilder.RenameIndex(
                name: "IX_FeedSource_SourceID",
                table: "FeedSources",
                newName: "IX_FeedSources_SourceID");

            migrationBuilder.RenameIndex(
                name: "IX_FeedSource_FeedID",
                table: "FeedSources",
                newName: "IX_FeedSources_FeedID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sources",
                table: "Sources",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedSources",
                table: "FeedSources",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedSources_Feeds_FeedID",
                table: "FeedSources",
                column: "FeedID",
                principalTable: "Feeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedSources_Sources_SourceID",
                table: "FeedSources",
                column: "SourceID",
                principalTable: "Sources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedSources_Feeds_FeedID",
                table: "FeedSources");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedSources_Sources_SourceID",
                table: "FeedSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sources",
                table: "Sources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedSources",
                table: "FeedSources");

            migrationBuilder.RenameTable(
                name: "Sources",
                newName: "Source");

            migrationBuilder.RenameTable(
                name: "FeedSources",
                newName: "FeedSource");

            migrationBuilder.RenameIndex(
                name: "IX_FeedSources_SourceID",
                table: "FeedSource",
                newName: "IX_FeedSource_SourceID");

            migrationBuilder.RenameIndex(
                name: "IX_FeedSources_FeedID",
                table: "FeedSource",
                newName: "IX_FeedSource_FeedID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Source",
                table: "Source",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedSource",
                table: "FeedSource",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedSource_Feeds_FeedID",
                table: "FeedSource",
                column: "FeedID",
                principalTable: "Feeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedSource_Source_SourceID",
                table: "FeedSource",
                column: "SourceID",
                principalTable: "Source",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
