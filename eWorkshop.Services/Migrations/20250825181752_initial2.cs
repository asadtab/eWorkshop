using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komponenta",
                table: "Magacin");

            migrationBuilder.RenameColumn(
                name: "KomponentaID",
                table: "Magacin",
                newName: "KomponentaId");

            migrationBuilder.RenameColumn(
                name: "MagacinID",
                table: "Magacin",
                newName: "MagacinId");

            migrationBuilder.RenameIndex(
                name: "IX_Magacin_KomponentaID",
                table: "Magacin",
                newName: "IX_Magacin_KomponentaId");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Magacin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Magacin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Magacin_Komponente_KomponentaId",
                table: "Magacin",
                column: "KomponentaId",
                principalTable: "Komponente",
                principalColumn: "KomponentaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magacin_Komponente_KomponentaId",
                table: "Magacin");

            migrationBuilder.RenameColumn(
                name: "KomponentaId",
                table: "Magacin",
                newName: "KomponentaID");

            migrationBuilder.RenameColumn(
                name: "MagacinId",
                table: "Magacin",
                newName: "MagacinID");

            migrationBuilder.RenameIndex(
                name: "IX_Magacin_KomponentaId",
                table: "Magacin",
                newName: "IX_Magacin_KomponentaID");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Magacin",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Magacin",
                type: "nvarchar(255)",
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
                value: new DateTime(2025, 6, 13, 21, 48, 15, 50, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 51, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 51, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 51, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 52, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "IzvrseniServis",
                keyColumn: "IzvrseniServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "RadniZadatak",
                keyColumn: "RadniZadatakID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "Servis",
                keyColumn: "ServisID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7e4cfe1e-8374-4f73-9eae-001950af72a8");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5313ce61-726c-4b01-b021-282125380370");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "73710dab-5cc5-49c0-9f7e-db554d272845");

            migrationBuilder.AddForeignKey(
                name: "FK_Komponenta",
                table: "Magacin",
                column: "KomponentaID",
                principalTable: "Komponente",
                principalColumn: "KomponentaID");
        }
    }
}
