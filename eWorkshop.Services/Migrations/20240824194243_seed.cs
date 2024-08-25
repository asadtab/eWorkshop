using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Email", "Ime", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "user.admin@tab.ba", "User", "USER.ADMIN@TAB.BA", "USER.ADMIN", "user.admin" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Ime", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "user.serviser@tab.ba", "User", "USER.SERVISER@TAB.BA", "USER.SERVISER", "user.serviser" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "RadnaJedinica", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", "user.pretplatnik@tab.ba", true, "User", false, null, "USER.PRETPLATNIK@TAB.BA", "USER.PRETPLATNIK", "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", null, false, "Pretplatnik", null, "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ", true, false, "user.pretplatnik" });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 3, 3, "IdentityUserRole<int>" });

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 24, 21, 42, 42, 616, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.InsertData(
                table: "RadniZadatak",
                columns: new[] { "RadniZadatakID", "Datum", "Naziv", "StateMachine" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 8, 24, 21, 42, 42, 616, DateTimeKind.Local).AddTicks(5952), "Sarajevo", "idle" },
                    { 3, new DateTime(2024, 8, 24, 21, 42, 42, 616, DateTimeKind.Local).AddTicks(5955), "Zenica", "idle" }
                });

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

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "25c03fea-234a-4d5d-add0-cd53c9dab79e", "Pretplatnik", "PRETPLATNIK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KorisniciUloge",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Ime", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "asad.admin@tab.ba", "Asad", "ASAD.ADMIN@TAB.BA", "ASAD.ADMIN", "asad.admin" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Ime", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "asad.serviser@tab.ba", "Asad", "ASAD.SERVISER@TAB.BA", "ASAD.SERVISER", "asad.serviser" });

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
    }
}
