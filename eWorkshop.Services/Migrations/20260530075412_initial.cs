using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komponente",
                columns: table => new
                {
                    KomponentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Vrijednost = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komponenta", x => x.KomponentaID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Prezime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    RadnaJedinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    LokacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.LokacijaID);
                });

            migrationBuilder.CreateTable(
                name: "RadniZadatak",
                columns: table => new
                {
                    RadniZadatakID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    StateMachine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniZadatak", x => x.RadniZadatakID);
                });

            migrationBuilder.CreateTable(
                name: "TipUredjaja",
                columns: table => new
                {
                    TipUredjajaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUredjaja", x => x.TipUredjajaID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UlogeClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlogeClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisniciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnici_KorisniciId",
                        column: x => x.KorisniciId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Uredjaj",
                columns: table => new
                {
                    UredjajID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipID = table.Column<int>(type: "int", nullable: false),
                    Koda = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SerijskiBroj = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GodinaIzvedbe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LokacijaID = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaj", x => x.UredjajID);
                    table.ForeignKey(
                        name: "FK_UredjajTip",
                        column: x => x.TipID,
                        principalTable: "TipUredjaja",
                        principalColumn: "TipUredjajaID");
                    table.ForeignKey(
                        name: "FK__Uredjaj__Lokacij__45F365D3",
                        column: x => x.LokacijaID,
                        principalTable: "Lokacija",
                        principalColumn: "LokacijaID");
                });

            migrationBuilder.CreateTable(
                name: "RadniZadatakUredjaj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadniZadatakId = table.Column<int>(type: "int", nullable: false),
                    UredjajId = table.Column<int>(type: "int", nullable: false),
                    Napomena = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniZadatakUredjaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RadniZadatak",
                        column: x => x.RadniZadatakId,
                        principalTable: "RadniZadatak",
                        principalColumn: "RadniZadatakID");
                    table.ForeignKey(
                        name: "FK_Uredjaj",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaj",
                        principalColumn: "UredjajID");
                });

            migrationBuilder.CreateTable(
                name: "Servi",
                columns: table => new
                {
                    ServisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Napomena = table.Column<string>(type: "text", nullable: true),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UredjajID = table.Column<int>(type: "int", nullable: false),
                    RadniZadatakID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisID", x => x.ServisID);
                    table.ForeignKey(
                        name: "FK_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RadniZadatakID",
                        column: x => x.RadniZadatakID,
                        principalTable: "RadniZadatak",
                        principalColumn: "RadniZadatakID");
                    table.ForeignKey(
                        name: "FK_UredjajID",
                        column: x => x.UredjajID,
                        principalTable: "Uredjaj",
                        principalColumn: "UredjajID");
                });

            migrationBuilder.CreateTable(
                name: "IzvrseniServis",
                columns: table => new
                {
                    IzvrseniServisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomponentaID = table.Column<int>(type: "int", nullable: true),
                    ServisID = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    KomponentaNaziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KomponentaVrijednost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KomponentaTip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvrseniServis", x => x.IzvrseniServisID);
                    table.ForeignKey(
                        name: "FK_KomponentaServis",
                        column: x => x.KomponentaID,
                        principalTable: "Komponente",
                        principalColumn: "KomponentaID");
                    table.ForeignKey(
                        name: "FK_Servis",
                        column: x => x.ServisID,
                        principalTable: "Servi",
                        principalColumn: "ServisID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzvrseniServis_KomponentaID",
                table: "IzvrseniServis",
                column: "KomponentaID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvrseniServis_ServisID",
                table: "IzvrseniServis",
                column: "ServisID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisniciId",
                table: "KorisniciUloge",
                column: "KorisniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniZadatakUredjaj_KorisnikId",
                table: "RadniZadatakUredjaj",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniZadatakUredjaj_RadniZadatakId",
                table: "RadniZadatakUredjaj",
                column: "RadniZadatakId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniZadatakUredjaj_UredjajId",
                table: "RadniZadatakUredjaj",
                column: "UredjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Servi_KorisnikID",
                table: "Servi",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Servi_RadniZadatakID",
                table: "Servi",
                column: "RadniZadatakID");

            migrationBuilder.CreateIndex(
                name: "IX_Servi_UredjajID",
                table: "Servi",
                column: "UredjajID");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaj_LokacijaID",
                table: "Uredjaj",
                column: "LokacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaj_TipID",
                table: "Uredjaj",
                column: "TipID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzvrseniServis");

            migrationBuilder.DropTable(
                name: "KorisniciClaim");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "RadniZadatakUredjaj");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "UlogeClaim");

            migrationBuilder.DropTable(
                name: "Komponente");

            migrationBuilder.DropTable(
                name: "Servi");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "RadniZadatak");

            migrationBuilder.DropTable(
                name: "Uredjaj");

            migrationBuilder.DropTable(
                name: "TipUredjaja");

            migrationBuilder.DropTable(
                name: "Lokacija");
        }
    }
}
