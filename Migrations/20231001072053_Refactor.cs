using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMF.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Concertos");

            migrationBuilder.RenameColumn(
                name: "Program",
                table: "Concertos",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "Miejsce",
                table: "Concertos",
                newName: "ConcertProgram");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Concertos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Concertos");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Concertos",
                newName: "Program");

            migrationBuilder.RenameColumn(
                name: "ConcertProgram",
                table: "Concertos",
                newName: "Miejsce");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Concertos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
