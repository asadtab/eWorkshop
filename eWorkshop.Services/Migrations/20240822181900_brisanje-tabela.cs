using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class brisanjetabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaniceUredjaj");

            migrationBuilder.DropTable(
                name: "Stanice");

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 972, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 974, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 974, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 974, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 986, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 18, 18, 58, 987, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 18, 18, 58, 987, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 18, 18, 58, 987, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 18, 18, 58, 987, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 18, 18, 58, 987, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 988, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 990, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 990, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 990, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 990, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 22, 20, 18, 58, 990, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ecce9232-b581-4153-ae3a-26bd03c035ba");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0a02c9b8-3f48-4934-8906-dbca5590ef8e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stanice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaniceUredjaj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanicaID = table.Column<int>(type: "int", nullable: false),
                    UredjajID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaniceUredjaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaniceUredjaj_Stanice_StanicaID",
                        column: x => x.StanicaID,
                        principalTable: "Stanice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaniceUredjaj_Uredjaj_UredjajID",
                        column: x => x.UredjajID,
                        principalTable: "Uredjaj",
                        principalColumn: "UredjajID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 411, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 413, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 413, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 413, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 423, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 5, 18, 16, 425, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 5, 18, 16, 425, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 5, 18, 16, 425, DateTimeKind.Utc).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 5, 18, 16, 425, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 5, 18, 16, 425, DateTimeKind.Utc).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 425, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 427, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 427, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 427, DateTimeKind.Local).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 427, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 18, 7, 18, 16, 427, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "201ba48a-2a03-4292-ac94-042cc162971f");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "be8500a5-2fd7-4eb0-a31d-1587bfd7358b");

            migrationBuilder.CreateIndex(
                name: "IX_StaniceUredjaj_StanicaID",
                table: "StaniceUredjaj",
                column: "StanicaID");

            migrationBuilder.CreateIndex(
                name: "IX_StaniceUredjaj_UredjajID",
                table: "StaniceUredjaj",
                column: "UredjajID");
        }
    }
}
