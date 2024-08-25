using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class finalseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6934403b-2af5-4a78-8c73-6f10971a4fa4", "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6934403b-2af5-4a78-8c73-6f10971a4fa4", "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6934403b-2af5-4a78-8c73-6f10971a4fa4", "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 588, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 591, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 591, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 591, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 614, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 19, 42, 42, 615, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 19, 42, 42, 615, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 19, 42, 42, 615, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 19, 42, 42, 615, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 19, 42, 42, 615, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ" });

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 616, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 616, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 616, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 617, DateTimeKind.Local).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 617, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 617, DateTimeKind.Local).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 617, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 617, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "86a57e10-d2c2-4afc-b621-f178d5ff390b");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2326cb7b-a044-4062-8225-9708fcba4c12");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "25c03fea-234a-4d5d-add0-cd53c9dab79e");
        }
    }
}
