using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class addindextoarticlebycreationdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_article_creation-date",
                table: "article",
                column: "creation-date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_article_creation-date",
                table: "article");
        }
    }
}
