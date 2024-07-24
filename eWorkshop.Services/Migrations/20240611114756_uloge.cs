using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class uloge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Uloge",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Uloge",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "Uloge",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 797, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 799, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 799, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 799, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 820, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 11, 47, 53, 822, DateTimeKind.Utc).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 11, 47, 53, 822, DateTimeKind.Utc).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 11, 47, 53, 822, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 11, 47, 53, 822, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 11, 47, 53, 822, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 823, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 826, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 826, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 826, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 826, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 6, 11, 13, 47, 53, 826, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "682fcbf8-571a-45eb-a821-e00f368f1f1d", "Administrator", "ADMINISTRATOR" },
                    { 2, "1675e729-73f8-4f03-aeab-22b419f8c1a9", "Serviser", "SERVISER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Uloge",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Uloge",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "Uloge",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

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
    }
}
