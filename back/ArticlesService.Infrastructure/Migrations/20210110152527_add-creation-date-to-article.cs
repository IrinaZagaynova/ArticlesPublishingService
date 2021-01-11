using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlesService.Infrastructure.Migrations
{
    public partial class addcreationdatetoarticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "creation-date",
                table: "article",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creation-date",
                table: "article");
        }
    }
}
