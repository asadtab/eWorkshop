using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class opisprijema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Napomena",
                table: "Servi",
                newName: "OpisPrijema");

            migrationBuilder.AddColumn<int>(
                name: "EvBroj",
                table: "Uredjaj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kuciste",
                table: "Uredjaj",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvBroj",
                table: "Uredjaj");

            migrationBuilder.DropColumn(
                name: "Kuciste",
                table: "Uredjaj");

            migrationBuilder.RenameColumn(
                name: "OpisPrijema",
                table: "Servi",
                newName: "Napomena");
        }
    }
}
