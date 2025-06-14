using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eWorkshop.Services.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AllowedAccessTokenSigningAlgorithms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    RequireResourceIndicator = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Emphasize = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequireClientSecret = table.Column<bool>(type: "bit", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequireConsent = table.Column<bool>(type: "bit", nullable: false),
                    AllowRememberConsent = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(type: "bit", nullable: false),
                    RequirePkce = table.Column<bool>(type: "bit", nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(type: "bit", nullable: false),
                    RequireRequestObject = table.Column<bool>(type: "bit", nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(type: "bit", nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(type: "bit", nullable: false),
                    BackChannelLogoutUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(type: "bit", nullable: false),
                    AllowOfflineAccess = table.Column<bool>(type: "bit", nullable: false),
                    IdentityTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    AllowedIdentityTokenSigningAlgorithms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    ConsentLifetime = table.Column<int>(type: "int", nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenUsage = table.Column<int>(type: "int", nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(type: "bit", nullable: false),
                    RefreshTokenExpiration = table.Column<int>(type: "int", nullable: false),
                    AccessTokenType = table.Column<int>(type: "int", nullable: false),
                    EnableLocalLogin = table.Column<bool>(type: "bit", nullable: false),
                    IncludeJwtId = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(type: "bit", nullable: false),
                    ClientClaimsPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSsoLifetime = table.Column<int>(type: "int", nullable: true),
                    UserCodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    CibaLifetime = table.Column<int>(type: "int", nullable: true),
                    PollingInterval = table.Column<int>(type: "int", nullable: true),
                    CoordinateLifetimeWithUserSession = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "IdentityProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scheme = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Emphasize = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
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
                name: "PersistedGrants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Id);
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
                name: "ServerSideSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Renewed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerSideSessions", x => x.Id);
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
                name: "ApiResourceClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceClaims_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceProperties_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceScopes_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceSecrets_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeClaims_ApiScopes_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "ApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeProperties_ApiScopes_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "ApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientClaims_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCorsOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCorsOrigins_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGrantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGrantTypes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdPRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientIdPRestrictions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPostLogoutRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPostLogoutRedirectUris_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProperties_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientRedirectUris_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScopes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSecrets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceClaims_IdentityResources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceProperties_IdentityResources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Servis",
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
                        principalTable: "Servis",
                        principalColumn: "ServisID");
                });

            migrationBuilder.InsertData(
                table: "ApiResources",
                columns: new[] { "Id", "AllowedAccessTokenSigningAlgorithms", "Created", "Description", "DisplayName", "Enabled", "LastAccessed", "Name", "NonEditable", "RequireResourceIndicator", "ShowInDiscoveryDocument", "Updated" },
                values: new object[] { 1, null, new DateTime(2025, 6, 13, 21, 48, 15, 50, DateTimeKind.Local).AddTicks(8005), "Api", "api", true, null, "api", false, false, true, null });

            migrationBuilder.InsertData(
                table: "ApiScopes",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "LastAccessed", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 13, 21, 48, 15, 51, DateTimeKind.Local).AddTicks(2979), "Pristup informacijama o korisniku", "Pristup", false, true, null, "profile", false, false, false, null },
                    { 2, new DateTime(2025, 6, 13, 21, 48, 15, 51, DateTimeKind.Local).AddTicks(2997), "Pristup e-mail adresama korisnika", "Email", false, true, null, "email", false, false, false, null },
                    { 3, new DateTime(2025, 6, 13, 21, 48, 15, 51, DateTimeKind.Local).AddTicks(3000), "Potreban je OpenID Connect, zahtijeva osnovne informacije o korisniku", "OpenID", false, true, null, "openid", false, false, false, null }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "CibaLifetime", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "CoordinateLifetimeWithUserSession", "Created", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "PollingInterval", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[] { 1, 0, 0, 0, false, true, false, false, null, false, false, 0, false, null, null, null, "flutter", "Flutter", "uri", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, false, true, false, null, 0, false, null, null, false, null, null, "x", 0, 0, true, false, false, false, 0, false, null, null, null });

            migrationBuilder.InsertData(
                table: "Komponente",
                columns: new[] { "KomponentaID", "Naziv", "Opis", "Tip", "Vrijednost" },
                values: new object[,]
                {
                    { 1, "Otpornik", null, null, "100Ω" },
                    { 2, "Relej WT", null, "7/VFV 190a", null },
                    { 3, "Relej FV", null, "8/WRW 170a", null },
                    { 4, "Kondenzator", null, null, "200pF" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "RadnaJedinica", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "6934403b-2af5-4a78-8c73-6f10971a4fa4", "user.admin@tab.ba", true, "User", false, null, "USER.ADMIN@TAB.BA", "USER.ADMIN", "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", null, false, "Admin", null, "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL", true, false, "user.admin" },
                    { 2, 0, "6934403b-2af5-4a78-8c73-6f10971a4fa4", "user.serviser@tab.ba", true, "User", false, null, "USER.SERVISER@TAB.BA", "USER.SERVISER", "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", null, false, "Serviser", null, "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL", true, false, "user.serviser" },
                    { 3, 0, "6934403b-2af5-4a78-8c73-6f10971a4fa4", "user.pretplatnik@tab.ba", true, "User", false, null, "USER.PRETPLATNIK@TAB.BA", "USER.PRETPLATNIK", "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", null, false, "Pretplatnik", "Sarajevo", "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL", true, false, "user.pretplatnik" }
                });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { 1, 1, "IdentityUserRole<int>" },
                    { 2, 2, "IdentityUserRole<int>" },
                    { 3, 3, "IdentityUserRole<int>" }
                });

            migrationBuilder.InsertData(
                table: "Lokacija",
                columns: new[] { "LokacijaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Sarajevo", null },
                    { 2, "Zenica", null },
                    { 3, "Mostar", null }
                });

            migrationBuilder.InsertData(
                table: "RadniZadatak",
                columns: new[] { "RadniZadatakID", "Datum", "Naziv", "StateMachine" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(1033), "Mostar", "active" },
                    { 2, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(1075), "Sarajevo", "idle" },
                    { 3, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(1078), "Zenica", "idle" }
                });

            migrationBuilder.InsertData(
                table: "TipUredjaja",
                columns: new[] { "TipUredjajaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "KRS", "Skretnička relejna grupa" },
                    { 2, "RGS", "Signalna relejna grupa" },
                    { 3, "RKG", "Relejna kontrolna grupa" }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "7e4cfe1e-8374-4f73-9eae-001950af72a8", "Administrator", "ADMINISTRATOR" },
                    { 2, "5313ce61-726c-4b01-b021-282125380370", "Serviser", "SERVISER" },
                    { 3, "73710dab-5cc5-49c0-9f7e-db554d272845", "Pretplatnik", "PRETPLATNIK" }
                });

            migrationBuilder.InsertData(
                table: "ClientClaims",
                columns: new[] { "Id", "ClientId", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Email", "email" },
                    { 2, 1, "Name", "name" },
                    { 3, 1, "Id", "id" },
                    { 4, 1, "Username", "username" }
                });

            migrationBuilder.InsertData(
                table: "ClientGrantTypes",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[] { 1, 1, "client_credentials" });

            migrationBuilder.InsertData(
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 1, 1, "weatherapi.read" },
                    { 2, 1, "weatherapi.write" }
                });

            migrationBuilder.InsertData(
                table: "ClientSecrets",
                columns: new[] { "Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[] { 1, 1, new DateTime(2025, 6, 13, 21, 48, 15, 52, DateTimeKind.Local).AddTicks(2628), "Aplikacija", new DateTime(2025, 2, 4, 9, 39, 35, 109, DateTimeKind.Unspecified), "app", "flutter" });

            migrationBuilder.InsertData(
                table: "Uredjaj",
                columns: new[] { "UredjajID", "GodinaIzvedbe", "isDeleted", "Koda", "LokacijaID", "SerijskiBroj", "Status", "TipID" },
                values: new object[,]
                {
                    { 189, "1987", false, "465-406-503", 1, "4810 AS", "idle", 2 },
                    { 190, "1987", false, "13E7283-1", 1, "62 66", "idle", 1 },
                    { 191, "1987", false, "465-406-503", 2, "1188 ES", "active", 1 },
                    { 192, "1987", false, "465-406-503", 3, "22 33", "fix", 1 },
                    { 193, "1987", false, "465-406-503", 1, "88 99", "task", 1 },
                    { 194, "1987", false, "465-204-000", 2, "7697 OS", "fix", 1 },
                    { 195, "1987", false, "465-417-500", 3, "7034 OS", "ready", 2 },
                    { 196, "1987", false, "465-436-701", 1, "32/87", "out", 3 },
                    { 197, "1987", false, "471-008-503", 2, "1712 MS", "parts", 2 },
                    { 198, "1987", false, "471-008-504", 3, "197/19", "idle", 2 },
                    { 199, "1987", false, "465-406-503", 1, "174 AS", "active", 3 },
                    { 200, "1987", false, "465-406-800", 2, "2413 NS", "fix", 2 },
                    { 201, "1987", false, "465-406-800", 3, "2423 NS", "task", 2 },
                    { 202, "1987", false, "465-436-700", 1, "231181", "fix", 3 },
                    { 203, "1987", false, "465-436-701", 2, "2566 FS", "ready", 3 },
                    { 204, "1987", false, "465-436-701", 3, "2676 FS", "out", 3 },
                    { 205, "1987", false, "13E7234-2", 1, "3/66", "parts", 2 },
                    { 206, "1987", false, "471-008-504", 2, "23040", "ready", 3 },
                    { 207, "1987", false, "471-008-504", 3, "0105051", "out", 3 },
                    { 208, "1987", false, "471-008-504", 1, "8723069", "parts", 3 }
                });

            migrationBuilder.InsertData(
                table: "RadniZadatakUredjaj",
                columns: new[] { "Id", "KorisnikId", "Napomena", "RadniZadatakId", "UredjajId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 189 },
                    { 2, 1, null, 1, 190 },
                    { 3, 2, null, 1, 192 },
                    { 4, 2, null, 1, 193 },
                    { 5, 1, null, 1, 194 }
                });

            migrationBuilder.InsertData(
                table: "Servis",
                columns: new[] { "ServisID", "Datum", "KorisnikID", "Napomena", "RadniZadatakID", "UredjajID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6057), 1, null, 1, 189 },
                    { 2, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6071), 1, null, 1, 190 },
                    { 3, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6073), 2, null, 1, 191 },
                    { 4, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6075), 2, null, 1, 192 },
                    { 5, new DateTime(2025, 6, 13, 21, 48, 15, 53, DateTimeKind.Local).AddTicks(6077), 1, null, 1, 193 }
                });

            migrationBuilder.InsertData(
                table: "IzvrseniServis",
                columns: new[] { "IzvrseniServisID", "Datum", "KomponentaID", "KomponentaNaziv", "KomponentaTip", "KomponentaVrijednost", "ServisID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7767), 1, null, null, null, 1 },
                    { 2, new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7769), 2, null, null, null, 1 },
                    { 3, new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7771), 1, null, null, null, 2 },
                    { 4, new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7772), 3, null, null, null, 2 },
                    { 5, new DateTime(2025, 6, 13, 19, 48, 15, 52, DateTimeKind.Utc).AddTicks(7770), 3, null, null, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaims_ApiResourceId_Type",
                table: "ApiResourceClaims",
                columns: new[] { "ApiResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperties_ApiResourceId_Key",
                table: "ApiResourceProperties",
                columns: new[] { "ApiResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResources_Name",
                table: "ApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScopes_ApiResourceId_Scope",
                table: "ApiResourceScopes",
                columns: new[] { "ApiResourceId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceSecrets_ApiResourceId",
                table: "ApiResourceSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeClaims_ScopeId_Type",
                table: "ApiScopeClaims",
                columns: new[] { "ScopeId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperties_ScopeId_Key",
                table: "ApiScopeProperties",
                columns: new[] { "ScopeId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopes_Name",
                table: "ApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaims_ClientId_Type_Value",
                table: "ClientClaims",
                columns: new[] { "ClientId", "Type", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigins_ClientId_Origin",
                table: "ClientCorsOrigins",
                columns: new[] { "ClientId", "Origin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantTypes_ClientId_GrantType",
                table: "ClientGrantTypes",
                columns: new[] { "ClientId", "GrantType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestrictions_ClientId_Provider",
                table: "ClientIdPRestrictions",
                columns: new[] { "ClientId", "Provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUris_ClientId_PostLogoutRedirectUri",
                table: "ClientPostLogoutRedirectUris",
                columns: new[] { "ClientId", "PostLogoutRedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperties_ClientId_Key",
                table: "ClientProperties",
                columns: new[] { "ClientId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUris_ClientId_RedirectUri",
                table: "ClientRedirectUris",
                columns: new[] { "ClientId", "RedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_ClientId_Scope",
                table: "ClientScopes",
                columns: new[] { "ClientId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecrets_ClientId",
                table: "ClientSecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityProviders_Scheme",
                table: "IdentityProviders",
                column: "Scheme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaims_IdentityResourceId_Type",
                table: "IdentityResourceClaims",
                columns: new[] { "IdentityResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperties_IdentityResourceId_Key",
                table: "IdentityResourceProperties",
                columns: new[] { "IdentityResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResources_Name",
                table: "IdentityResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IzvrseniServis_KomponentaID",
                table: "IzvrseniServis",
                column: "KomponentaID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvrseniServis_ServisID",
                table: "IzvrseniServis",
                column: "ServisID");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisniciId",
                table: "KorisniciUloge",
                column: "KorisniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Magacin_KomponentaID",
                table: "Magacin",
                column: "KomponentaID");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Key",
                table: "PersistedGrants",
                column: "Key",
                unique: true,
                filter: "([Key] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

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
                name: "IX_ServerSideSessions_DisplayName",
                table: "ServerSideSessions",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_Expires",
                table: "ServerSideSessions",
                column: "Expires");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_Key",
                table: "ServerSideSessions",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_SessionId",
                table: "ServerSideSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_SubjectId",
                table: "ServerSideSessions",
                column: "SubjectId");

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
                name: "ApiResourceClaims");

            migrationBuilder.DropTable(
                name: "ApiResourceProperties");

            migrationBuilder.DropTable(
                name: "ApiResourceScopes");

            migrationBuilder.DropTable(
                name: "ApiResourceSecrets");

            migrationBuilder.DropTable(
                name: "ApiScopeClaims");

            migrationBuilder.DropTable(
                name: "ApiScopeProperties");

            migrationBuilder.DropTable(
                name: "ClientClaims");

            migrationBuilder.DropTable(
                name: "ClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "ClientGrantTypes");

            migrationBuilder.DropTable(
                name: "ClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "ClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "ClientProperties");

            migrationBuilder.DropTable(
                name: "ClientRedirectUris");

            migrationBuilder.DropTable(
                name: "ClientScopes");

            migrationBuilder.DropTable(
                name: "ClientSecrets");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "IdentityProviders");

            migrationBuilder.DropTable(
                name: "IdentityResourceClaims");

            migrationBuilder.DropTable(
                name: "IdentityResourceProperties");

            migrationBuilder.DropTable(
                name: "IzvrseniServis");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "KorisniciClaim");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Magacin");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "RadniZadatakUredjaj");

            migrationBuilder.DropTable(
                name: "ServerSideSessions");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "UlogeClaim");

            migrationBuilder.DropTable(
                name: "ApiResources");

            migrationBuilder.DropTable(
                name: "ApiScopes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "IdentityResources");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "Komponente");

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
