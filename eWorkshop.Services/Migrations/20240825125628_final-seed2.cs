using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class finalseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 106, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 107, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 107, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 107, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 116, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 12, 56, 27, 130, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 12, 56, 27, 130, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 12, 56, 27, 130, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 12, 56, 27, 130, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 12, 56, 27, 130, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 3,
                column: "RadnaJedinica",
                value: "Sarajevo");

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 132, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 132, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 132, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 135, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 135, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 135, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 135, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 14, 56, 27, 135, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "587aaee7-f17d-4145-a6ec-4ada37f3c932");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "836daf62-4236-4ec5-9f7e-f6263a28d976");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8eeca724-39ce-498e-957f-e1cd5c45fddf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 808, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 809, DateTimeKind.Local).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 809, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 809, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 825, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 11, 55, 10, 827, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 11, 55, 10, 827, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 11, 55, 10, 827, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 11, 55, 10, 827, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 11, 55, 10, 827, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 3,
                column: "RadnaJedinica",
                value: null);

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 828, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 828, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 828, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 829, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 829, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 829, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 829, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 25, 13, 55, 10, 829, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "34a80253-4618-4cf3-8de4-111625dfe0f4");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fe1a80d0-9c1e-4e4e-b873-eea93237e287");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1c757034-0178-434f-b16c-bc80c33df08b");
        }
    }
}
