using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BloggerSilindi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bloggers");

            migrationBuilder.RenameColumn(
                name: "BloggerId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BloggerId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BloggerId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Likes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "BloggerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "BloggerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "BloggerId");

            migrationBuilder.CreateTable(
                name: "Bloggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloggers", x => x.Id);
                });
        }
    }
}
