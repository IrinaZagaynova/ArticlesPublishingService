using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id_category = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id_image = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id_image);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    id_article = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    content = table.Column<string>(nullable: false),
                    id_user = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.id_article);
                    table.ForeignKey(
                        name: "FK_article_user_id_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "article_has_category",
                columns: table => new
                {
                    id_article_has_category = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_article = table.Column<int>(nullable: false),
                    id_category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_has_category", x => x.id_article_has_category);
                    table.ForeignKey(
                        name: "FK_article_has_category_article_id_article",
                        column: x => x.id_article,
                        principalTable: "article",
                        principalColumn: "id_article",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_has_category_category_id_category",
                        column: x => x.id_category,
                        principalTable: "category",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_has_image",
                columns: table => new
                {
                    id_article_has_image = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_article = table.Column<int>(nullable: false),
                    id_image = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_has_image", x => x.id_article_has_image);
                    table.ForeignKey(
                        name: "FK_article_has_image_article_id_article",
                        column: x => x.id_article,
                        principalTable: "article",
                        principalColumn: "id_article",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_has_image_image_id_image",
                        column: x => x.id_image,
                        principalTable: "image",
                        principalColumn: "id_image",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id_comment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_article = table.Column<int>(nullable: false),
                    id_user = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id_comment);
                    table.ForeignKey(
                        name: "FK_comment_article_id_article",
                        column: x => x.id_article,
                        principalTable: "article",
                        principalColumn: "id_article",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_user_id_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_id_user",
                table: "article",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_article_has_category_id_article",
                table: "article_has_category",
                column: "id_article");

            migrationBuilder.CreateIndex(
                name: "IX_article_has_category_id_category",
                table: "article_has_category",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_article_has_image_id_article",
                table: "article_has_image",
                column: "id_article");

            migrationBuilder.CreateIndex(
                name: "IX_article_has_image_id_image",
                table: "article_has_image",
                column: "id_image");

            migrationBuilder.CreateIndex(
                name: "IX_comment_id_article",
                table: "comment",
                column: "id_article");

            migrationBuilder.CreateIndex(
                name: "IX_comment_id_user",
                table: "comment",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_has_category");

            migrationBuilder.DropTable(
                name: "article_has_image");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
