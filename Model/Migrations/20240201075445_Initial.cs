using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Like",
                table: "TodoItems",
                newName: "Complated");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "TodoItems",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TodoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoItems",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Complated",
                table: "TodoItems",
                newName: "Like");
        }
    }
}
