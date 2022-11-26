using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class promjenaimenakoloneStateMachinetabeleUredjajuuStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    KlijentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Prezime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LozinkaHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.KlijentID);
                });

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
                    KorisniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Prezime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisniciID);
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
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Upit",
                columns: table => new
                {
                    UpitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    KlijentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upis", x => x.UpitID);
                    table.ForeignKey(
                        name: "FK_KlijentUpis",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "KlijentID");
                });

            migrationBuilder.CreateTable(
                name: "Magacin",
                columns: table => new
                {
                    MagacinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomponentaID = table.Column<int>(type: "int", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magacin", x => x.MagacinID);
                    table.ForeignKey(
                        name: "FK_Komponenta",
                        column: x => x.KomponentaID,
                        principalTable: "Komponente",
                        principalColumn: "KomponentaID");
                });

            migrationBuilder.CreateTable(
                name: "Ugovor",
                columns: table => new
                {
                    UgovorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadniZadatakID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    Cijena = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uogovor", x => x.UgovorID);
                    table.ForeignKey(
                        name: "FK_RadniZadatakUgovor",
                        column: x => x.RadniZadatakID,
                        principalTable: "RadniZadatak",
                        principalColumn: "RadniZadatakID");
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
                    GodinaIzvedbe = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LokacijaID = table.Column<int>(type: "int", nullable: true)
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
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisniciID");
                    table.ForeignKey(
                        name: "FK_UlogaKorisnik",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID");
                });

            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    ServisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Napomena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
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
                        principalColumn: "KorisniciID");
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
                    Datum = table.Column<DateTime>(type: "date", nullable: true)
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
                        principalTable: "Servis",
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
                name: "IX_KorisniciUloge_KorisnikID",
                table: "KorisniciUloge",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Magacin_KomponentaID",
                table: "Magacin",
                column: "KomponentaID");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_KorisnikID",
                table: "Servis",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_RadniZadatakID",
                table: "Servis",
                column: "RadniZadatakID");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_UredjajID",
                table: "Servis",
                column: "UredjajID");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovor_RadniZadatakID",
                table: "Ugovor",
                column: "RadniZadatakID");

            migrationBuilder.CreateIndex(
                name: "IX_Upit_KlijentID",
                table: "Upit",
                column: "KlijentID");

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
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Magacin");

            migrationBuilder.DropTable(
                name: "Ugovor");

            migrationBuilder.DropTable(
                name: "Upit");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Komponente");

            migrationBuilder.DropTable(
                name: "Klijenti");

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
