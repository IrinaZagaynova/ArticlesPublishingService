using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class changedtitletypename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_login",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_article_title",
                table: "article");

            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "article",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "user",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "article",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.CreateIndex(
                name: "IX_user_login",
                table: "user",
                column: "login");

            migrationBuilder.CreateIndex(
                name: "IX_article_title",
                table: "article",
                column: "title");
        }
    }
}
