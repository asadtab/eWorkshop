using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class asad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 867, DateTimeKind.Local).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 869, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 869, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 869, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 888, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 18, 34, 34, 890, DateTimeKind.Utc).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 18, 34, 34, 890, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 18, 34, 34, 890, DateTimeKind.Utc).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 18, 34, 34, 890, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 18, 34, 34, 890, DateTimeKind.Utc).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 891, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 894, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 894, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 894, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 894, DateTimeKind.Local).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 20, 34, 34, 894, DateTimeKind.Local).AddTicks(1628));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 533, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 537, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 537, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 537, DateTimeKind.Local).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 557, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 13, 1, 32, 560, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 13, 1, 32, 560, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 13, 1, 32, 560, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 13, 1, 32, 560, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 13, 1, 32, 560, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 562, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 569, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 569, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 569, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 569, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 6, 10, 15, 1, 32, 569, DateTimeKind.Local).AddTicks(4618));
        }
    }
}
