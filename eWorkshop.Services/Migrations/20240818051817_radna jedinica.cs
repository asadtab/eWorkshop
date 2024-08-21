using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class radnajedinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RadnaJedinica",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                column: "RadnaJedinica",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                column: "RadnaJedinica",
                value: null);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RadnaJedinica",
                table: "Korisnici");

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

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "682fcbf8-571a-45eb-a821-e00f368f1f1d");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1675e729-73f8-4f03-aeab-22b419f8c1a9");
        }
    }
}
