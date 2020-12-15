using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class updatearticleandimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Articles_ArticleId",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Categories_CategoryId",
                table: "ArticleCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "ArticleCategory",
                newName: "ArticleCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_CategoryId",
                table: "ArticleCategories",
                newName: "IX_ArticleCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_ArticleId",
                table: "ArticleCategories",
                newName: "IX_ArticleCategories_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryId",
                table: "ArticleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "ArticleCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_ArticleId");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Articles_ArticleId",
                table: "ArticleCategory",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Categories_CategoryId",
                table: "ArticleCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
