using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class removeindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_article_id_user",
                table: "article");

            migrationBuilder.CreateIndex(
                name: "IX_article_id_user",
                table: "article",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_article_id_user",
                table: "article");

            migrationBuilder.CreateIndex(
                name: "IX_article_id_user",
                table: "article",
                column: "id_user")
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
