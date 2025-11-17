using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatePostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    varchar20 = table.Column<string>(name: "varchar(20)", type: "longtext", nullable: false),
                    text = table.Column<string>(type: "longtext", nullable: false),
                    Regtime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modtime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BloggerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_bloggers_BloggerId",
                        column: x => x.BloggerId,
                        principalTable: "bloggers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_posts_BloggerId",
                table: "posts",
                column: "BloggerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
