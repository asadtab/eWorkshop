using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magacin");

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 520, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 521, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 521, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 521, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 521, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 30, 44, 522, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 30, 44, 522, DateTimeKind.Utc).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 30, 44, 522, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 30, 44, 522, DateTimeKind.Utc).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 30, 44, 522, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 30, 44, 522, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1180205a-3bb6-4f1a-949b-c27f2999965e");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b118f256-6216-4caa-9924-d7b134976bbd");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b7388536-06cc-4b40-a65d-bf072b9c0f08");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magacin",
                columns: table => new
                {
                    MagacinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomponentaId = table.Column<int>(type: "int", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magacin", x => x.MagacinId);
                    table.ForeignKey(
                        name: "FK_Magacin_Komponente_KomponentaId",
                        column: x => x.KomponentaId,
                        principalTable: "Komponente",
                        principalColumn: "KomponentaID");
                });

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 86, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 86, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 86, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 86, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 87, DateTimeKind.Local).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 17, 52, 88, DateTimeKind.Utc).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 17, 52, 88, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 17, 52, 88, DateTimeKind.Utc).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 17, 52, 88, DateTimeKind.Utc).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 18, 17, 52, 88, DateTimeKind.Utc).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(2949));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2025, 8, 25, 20, 17, 52, 88, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "324617d5-0b96-4fd8-8744-9e04caaf72ca");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e0ce8804-d533-4656-819a-fd546780abe3");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "26882fdc-a8d9-467b-a634-30b45d0954cc");

            migrationBuilder.CreateIndex(
                name: "IX_Magacin_KomponentaId",
                table: "Magacin",
                column: "KomponentaId");
        }
    }
}
