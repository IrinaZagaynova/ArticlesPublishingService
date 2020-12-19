using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class nameschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryId",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Images_ImageId",
                table: "ArticleImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleImages",
                table: "ArticleImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "image");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "article");

            migrationBuilder.RenameTable(
                name: "ArticleImages",
                newName: "article_has_image");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "article_has_category");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "user",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "EMail",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id_user");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "image",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "image",
                newName: "id_image");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "comment",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "comment",
                newName: "id_user");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "comment",
                newName: "id_article");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "comment",
                newName: "id_comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "comment",
                newName: "IX_comment_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
                table: "comment",
                newName: "IX_comment_id_article");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "category",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "category",
                newName: "id_category");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "article",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "article",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "article",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "article",
                newName: "id_article");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserId",
                table: "article",
                newName: "IX_article_UserId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "article_has_image",
                newName: "id_image");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "article_has_image",
                newName: "id_article");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "article_has_image",
                newName: "id_article_has_image");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleImages_ImageId",
                table: "article_has_image",
                newName: "IX_article_has_image_id_image");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "article_has_image",
                newName: "IX_article_has_image_id_article");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "article_has_category",
                newName: "id_category");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "article_has_category",
                newName: "id_article");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "article_has_category",
                newName: "id_article_has_category");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "article_has_category",
                newName: "IX_article_has_category_id_category");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "article_has_category",
                newName: "IX_article_has_category_id_article");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_image",
                table: "image",
                column: "id_image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                column: "id_comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "id_category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_article",
                table: "article",
                column: "id_article");

            migrationBuilder.AddPrimaryKey(
                name: "PK_article_has_image",
                table: "article_has_image",
                column: "id_article_has_image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_article_has_category",
                table: "article_has_category",
                column: "id_article_has_category");

            migrationBuilder.AddForeignKey(
                name: "FK_article_user_UserId",
                table: "article",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_article_has_category_article_id_article",
                table: "article_has_category",
                column: "id_article",
                principalTable: "article",
                principalColumn: "id_article",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_article_has_category_category_id_category",
                table: "article_has_category",
                column: "id_category",
                principalTable: "category",
                principalColumn: "id_category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_article_has_image_article_id_article",
                table: "article_has_image",
                column: "id_article",
                principalTable: "article",
                principalColumn: "id_article",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_article_has_image_image_id_image",
                table: "article_has_image",
                column: "id_image",
                principalTable: "image",
                principalColumn: "id_image",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_article_id_article",
                table: "comment",
                column: "id_article",
                principalTable: "article",
                principalColumn: "id_article",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_user_id_user",
                table: "comment",
                column: "id_user",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_article_user_UserId",
                table: "article");

            migrationBuilder.DropForeignKey(
                name: "FK_article_has_category_article_id_article",
                table: "article_has_category");

            migrationBuilder.DropForeignKey(
                name: "FK_article_has_category_category_id_category",
                table: "article_has_category");

            migrationBuilder.DropForeignKey(
                name: "FK_article_has_image_article_id_article",
                table: "article_has_image");

            migrationBuilder.DropForeignKey(
                name: "FK_article_has_image_image_id_image",
                table: "article_has_image");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_article_id_article",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_user_id_user",
                table: "comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_image",
                table: "image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_article_has_image",
                table: "article_has_image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_article_has_category",
                table: "article_has_category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_article",
                table: "article");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "image",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "article_has_image",
                newName: "ArticleImages");

            migrationBuilder.RenameTable(
                name: "article_has_category",
                newName: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "article",
                newName: "Articles");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "EMail");

            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id_image",
                table: "Images",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Comments",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id_article",
                table: "Comments",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "id_comment",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_comment_id_user",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_comment_id_article",
                table: "Comments",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Categories",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id_category",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_image",
                table: "ArticleImages",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "id_article",
                table: "ArticleImages",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "id_article_has_image",
                table: "ArticleImages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_article_has_image_id_image",
                table: "ArticleImages",
                newName: "IX_ArticleImages_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_article_has_image_id_article",
                table: "ArticleImages",
                newName: "IX_ArticleImages_ArticleId");

            migrationBuilder.RenameColumn(
                name: "id_category",
                table: "ArticleCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "id_article",
                table: "ArticleCategories",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "id_article_has_category",
                table: "ArticleCategories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_article_has_category_id_category",
                table: "ArticleCategories",
                newName: "IX_ArticleCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_article_has_category_id_article",
                table: "ArticleCategories",
                newName: "IX_ArticleCategories_ArticleId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Articles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Articles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Articles",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id_article",
                table: "Articles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_article_UserId",
                table: "Articles",
                newName: "IX_Articles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleImages",
                table: "ArticleImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Images_ImageId",
                table: "ArticleImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
