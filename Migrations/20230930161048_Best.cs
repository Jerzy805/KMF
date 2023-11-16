using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMF.Migrations
{
    /// <inheritdoc />
    public partial class Best : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Concertos",
                newName: "Miejsce");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Concertos",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Miejsce",
                table: "Concertos",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Concertos",
                newName: "Place");
        }
    }
}
