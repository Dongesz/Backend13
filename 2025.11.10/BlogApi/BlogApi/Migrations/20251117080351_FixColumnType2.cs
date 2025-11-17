using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "posts",
                newName: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Post",
                table: "posts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post",
                table: "posts",
                newName: "text");

            migrationBuilder.AlterColumn<string>(
                name: "text",
                table: "posts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
