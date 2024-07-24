using eWorkshop.Services.Database.Seed;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eWorkshop.Services.Database;

public partial class _190128Context : DbContext
{
    public _190128Context()
    {
    }

    public _190128Context(DbContextOptions<_190128Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiResource> ApiResources { get; set; }

   public virtual DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }

    public virtual DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }

    public virtual DbSet<ApiResourceScope> ApiResourceScopes { get; set; }

    public virtual DbSet<ApiResourceSecret> ApiResourceSecrets { get; set; }

    public virtual DbSet<ApiScope> ApiScopes { get; set; }

    public virtual DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

    public virtual DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetRole> AspNetUserRoles { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientClaim> ClientClaims { get; set; }

    public virtual DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

    public virtual DbSet<ClientGrantType> ClientGrantTypes { get; set; }

    public virtual DbSet<ClientIdPrestriction> ClientIdPrestrictions { get; set; }

    public virtual DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }

    public virtual DbSet<ClientProperty> ClientProperties { get; set; }

    public virtual DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

    public virtual DbSet<ClientScope> ClientScopes { get; set; }

    public virtual DbSet<ClientSecret> ClientSecrets { get; set; }

    public virtual DbSet<DeviceCode> DeviceCodes { get; set; }

    public virtual DbSet<IdentityProvider> IdentityProviders { get; set; }

    public virtual DbSet<IdentityResource> IdentityResources { get; set; }

    public virtual DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; }

    public virtual DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

    public virtual DbSet<IzvrseniServi> IzvrseniServis { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<Komponente> Komponentes { get; set; }

    public virtual DbSet<Korisnici> Korisnicis { get; set; }

    public virtual DbSet<Lokacija> Lokacijas { get; set; }

    public virtual DbSet<Magacin> Magacins { get; set; }

    public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

    public virtual DbSet<RadniZadatak> RadniZadataks { get; set; }

    public virtual DbSet<RadniZadatakUredjaj> RadniZadatakUredjajs { get; set; }

    public virtual DbSet<ServerSideSession> ServerSideSessions { get; set; }
    public virtual DbSet<Servi> Servis { get; set; }
    public virtual DbSet<Stanice> Stanices { get; set; }
    public virtual DbSet<StaniceUredjaj> StaniceUredjajs { get; set; }
    public virtual DbSet<TipUredjaja> TipUredjajas { get; set; }
    public virtual DbSet<Uloge> Uloge { get; set; }
    public virtual DbSet<Microsoft.AspNetCore.Identity.IdentityUserRole<int>> KorisniciUloge { get; set; }
    public virtual DbSet<Microsoft.AspNetCore.Identity.IdentityUserClaim<int>> KorisniciClaim { get; set; }
    public virtual DbSet<Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>> UlogeClaim { get; set; }


    public virtual DbSet<Uredjaj> Uredjajs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=eworkshop-sql,1433;Database=190128;User=sa;Password=QWElkj132!;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiResource>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_ApiResources_Name").IsUnique();

            entity.Property(e => e.AllowedAccessTokenSigningAlgorithms).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);

        }
        
        ) ;

        modelBuilder.Entity<ApiResource>().SeedData();

        modelBuilder.Entity<ApiResourceClaim>(entity =>
        {
            entity.HasIndex(e => new { e.ApiResourceId, e.Type }, "IX_ApiResourceClaims_ApiResourceId_Type").IsUnique();

            entity.Property(e => e.Type).HasMaxLength(200);

            entity.HasOne(d => d.ApiResource).WithMany(p => p.ApiResourceClaims).HasForeignKey(d => d.ApiResourceId);
        });

        

        modelBuilder.Entity<ApiResourceProperty>(entity =>
        {
            entity.HasIndex(e => new { e.ApiResourceId, e.Key }, "IX_ApiResourceProperties_ApiResourceId_Key").IsUnique();

            entity.Property(e => e.Key).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(2000);

            entity.HasOne(d => d.ApiResource).WithMany(p => p.ApiResourceProperties).HasForeignKey(d => d.ApiResourceId);
            
        });

        modelBuilder.Entity<ApiResourceScope>(entity =>
        {
            entity.HasIndex(e => new { e.ApiResourceId, e.Scope }, "IX_ApiResourceScopes_ApiResourceId_Scope").IsUnique();

            entity.Property(e => e.Scope).HasMaxLength(200);

            entity.HasOne(d => d.ApiResource).WithMany(p => p.ApiResourceScopes).HasForeignKey(d => d.ApiResourceId);
        });

        modelBuilder.Entity<ApiResourceSecret>(entity =>
        {
            entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceSecrets_ApiResourceId");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Type).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(4000);

            entity.HasOne(d => d.ApiResource).WithMany(p => p.ApiResourceSecrets).HasForeignKey(d => d.ApiResourceId);
        });

        modelBuilder.Entity<ApiScope>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_ApiScopes_Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
        });
        modelBuilder.Entity<ApiScope>().SeedData();

        modelBuilder.Entity<ApiScopeClaim>(entity =>
        {
            entity.HasIndex(e => new { e.ScopeId, e.Type }, "IX_ApiScopeClaims_ScopeId_Type").IsUnique();

            entity.Property(e => e.Type).HasMaxLength(200);

            entity.HasOne(d => d.Scope).WithMany(p => p.ApiScopeClaims).HasForeignKey(d => d.ScopeId);
        });

        modelBuilder.Entity<ApiScopeProperty>(entity =>
        {
            entity.HasIndex(e => new { e.ScopeId, e.Key }, "IX_ApiScopeProperties_ScopeId_Key").IsUnique();

            entity.Property(e => e.Key).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(2000);

            entity.HasOne(d => d.Scope).WithMany(p => p.ApiScopeProperties).HasForeignKey(d => d.ScopeId);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_Clients_ClientId").IsUnique();

            entity.Property(e => e.AllowedIdentityTokenSigningAlgorithms).HasMaxLength(100);
            entity.Property(e => e.BackChannelLogoutUri).HasMaxLength(2000);
            entity.Property(e => e.ClientClaimsPrefix).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.ClientName).HasMaxLength(200);
            entity.Property(e => e.ClientUri).HasMaxLength(2000);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.FrontChannelLogoutUri).HasMaxLength(2000);
            entity.Property(e => e.LogoUri).HasMaxLength(2000);
            entity.Property(e => e.PairWiseSubjectSalt).HasMaxLength(200);
            entity.Property(e => e.ProtocolType).HasMaxLength(200);
            entity.Property(e => e.UserCodeType).HasMaxLength(100);
        });

        modelBuilder.Entity<Client>().SeedData();

        modelBuilder.Entity<ClientClaim>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.Type, e.Value }, "IX_ClientClaims_ClientId_Type_Value").IsUnique();

            entity.Property(e => e.Type).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(250);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientClaims).HasForeignKey(d => d.ClientId);
        });
        modelBuilder.Entity<ClientClaim>().SeedData();

        modelBuilder.Entity<ClientCorsOrigin>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.Origin }, "IX_ClientCorsOrigins_ClientId_Origin").IsUnique();

            entity.Property(e => e.Origin).HasMaxLength(150);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientCorsOrigins).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientGrantType>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.GrantType }, "IX_ClientGrantTypes_ClientId_GrantType").IsUnique();

            entity.Property(e => e.GrantType).HasMaxLength(250);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientGrantTypes).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientGrantType>().SeedData();

        modelBuilder.Entity<ClientIdPrestriction>(entity =>
        {
            entity.ToTable("ClientIdPRestrictions");

            entity.HasIndex(e => new { e.ClientId, e.Provider }, "IX_ClientIdPRestrictions_ClientId_Provider").IsUnique();

            entity.Property(e => e.Provider).HasMaxLength(200);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientIdPrestrictions).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientPostLogoutRedirectUri>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.PostLogoutRedirectUri }, "IX_ClientPostLogoutRedirectUris_ClientId_PostLogoutRedirectUri").IsUnique();

            entity.Property(e => e.PostLogoutRedirectUri).HasMaxLength(400);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientPostLogoutRedirectUris).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientProperty>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.Key }, "IX_ClientProperties_ClientId_Key").IsUnique();

            entity.Property(e => e.Key).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(2000);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientProperties).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientRedirectUri>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.RedirectUri }, "IX_ClientRedirectUris_ClientId_RedirectUri").IsUnique();

            entity.Property(e => e.RedirectUri).HasMaxLength(400);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientRedirectUris).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientScope>(entity =>
        {
            entity.HasIndex(e => new { e.ClientId, e.Scope }, "IX_ClientScopes_ClientId_Scope").IsUnique();

            entity.Property(e => e.Scope).HasMaxLength(200);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientScopes).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<ClientScope>().SeedData();

        modelBuilder.Entity<ClientSecret>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_ClientSecrets_ClientId");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Type).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(4000);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientSecrets).HasForeignKey(d => d.ClientId);
        });
        modelBuilder.Entity<ClientSecret>().SeedData();

        modelBuilder.Entity<DeviceCode>(entity =>
        {
            entity.HasKey(e => e.UserCode);

            entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode").IsUnique();

            entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

            entity.Property(e => e.UserCode).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.DeviceCode1)
                .HasMaxLength(200)
                .HasColumnName("DeviceCode");
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
        });

        modelBuilder.Entity<IdentityProvider>(entity =>
        {
            entity.HasIndex(e => e.Scheme, "IX_IdentityProviders_Scheme").IsUnique();

            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Scheme).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<IdentityResource>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_IdentityResources_Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<IdentityResourceClaim>(entity =>
        {
            entity.HasIndex(e => new { e.IdentityResourceId, e.Type }, "IX_IdentityResourceClaims_IdentityResourceId_Type").IsUnique();

            entity.Property(e => e.Type).HasMaxLength(200);

            entity.HasOne(d => d.IdentityResource).WithMany(p => p.IdentityResourceClaims).HasForeignKey(d => d.IdentityResourceId);
        });

        modelBuilder.Entity<IdentityResourceProperty>(entity =>
        {
            entity.HasIndex(e => new { e.IdentityResourceId, e.Key }, "IX_IdentityResourceProperties_IdentityResourceId_Key").IsUnique();

            entity.Property(e => e.Key).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(2000);

            entity.HasOne(d => d.IdentityResource).WithMany(p => p.IdentityResourceProperties).HasForeignKey(d => d.IdentityResourceId);
        });

        modelBuilder.Entity<IzvrseniServi>(entity =>
        {
            entity.HasKey(e => e.IzvrseniServisId);

            entity.Property(e => e.IzvrseniServisId).HasColumnName("IzvrseniServisID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KomponentaId).HasColumnName("KomponentaID");
            entity.Property(e => e.KomponentaNaziv).HasMaxLength(50);
            entity.Property(e => e.KomponentaTip).HasMaxLength(50);
            entity.Property(e => e.KomponentaVrijednost).HasMaxLength(50);
            entity.Property(e => e.ServisId).HasColumnName("ServisID");

            entity.HasOne(d => d.Komponenta).WithMany(p => p.IzvrseniServis)
                .HasForeignKey(d => d.KomponentaId)
                .HasConstraintName("FK_KomponentaServis");

            entity.HasOne(d => d.Servis).WithMany(p => p.IzvrseniServis)
                .HasForeignKey(d => d.ServisId)
                .HasConstraintName("FK_Servis");
        });

        modelBuilder.Entity<IzvrseniServi>().SeedData();

        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasIndex(e => e.Use, "IX_Keys_Use");

            entity.Property(e => e.Algorithm).HasMaxLength(100);
            entity.Property(e => e.IsX509certificate).HasColumnName("IsX509Certificate");
        });

        modelBuilder.Entity<Komponente>(entity =>
        {
            entity.HasKey(e => e.KomponentaId).HasName("PK_Komponenta");

            entity.ToTable("Komponente");

            entity.Property(e => e.KomponentaId).HasColumnName("KomponentaID");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);
            entity.Property(e => e.Tip).HasMaxLength(255);
            entity.Property(e => e.Vrijednost).HasMaxLength(255);
        });
        modelBuilder.Entity<Komponente>().SeedData();

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.ToTable("Korisnici");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .IsUnicode(false);



        });
        modelBuilder.Entity<Korisnici>().SeedData();

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.ToTable("Uloge");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NormalizedName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConcurrencyStamp)
                .HasMaxLength(255)
                .IsUnicode(false);



        });
        modelBuilder.Entity<Uloge>().SeedData();


        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.ToTable("Lokacija");

            entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);
        });
        modelBuilder.Entity<Lokacija>().SeedData();

        modelBuilder.Entity<Magacin>(entity =>
        {
            entity.ToTable("Magacin");

            entity.Property(e => e.MagacinId).HasColumnName("MagacinID");
            entity.Property(e => e.KomponentaId).HasColumnName("KomponentaID");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);

            entity.HasOne(d => d.Komponenta).WithMany(p => p.Magacins)
                .HasForeignKey(d => d.KomponentaId)
                .HasConstraintName("FK_Komponenta");
        });

        modelBuilder.Entity<PersistedGrant>(entity =>
        {
            entity.HasIndex(e => e.ConsumedTime, "IX_PersistedGrants_ConsumedTime");

            entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

            entity.HasIndex(e => e.Key, "IX_PersistedGrants_Key")
                .IsUnique()
                .HasFilter("([Key] IS NOT NULL)");

            entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

            entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Key).HasMaxLength(200);
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<RadniZadatak>(entity =>
        {
            entity.ToTable("RadniZadatak");

            entity.Property(e => e.RadniZadatakId).HasColumnName("RadniZadatakID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.StateMachine).HasMaxLength(255);
        });

        modelBuilder.Entity<RadniZadatak>().SeedData();

        modelBuilder.Entity<RadniZadatakUredjaj>(entity =>
        {
            entity.ToTable("RadniZadatakUredjaj");

            entity.Property(e => e.Napomena)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Korisnik).WithMany(p => p.RadniZadatakUredjajs)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_Korisnik");

            entity.HasOne(d => d.RadniZadatak).WithMany(p => p.RadniZadatakUredjajs)
                .HasForeignKey(d => d.RadniZadatakId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RadniZadatak");

            entity.HasOne(d => d.Uredjaj).WithMany(p => p.RadniZadatakUredjajs)
                .HasForeignKey(d => d.UredjajId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Uredjaj");
        });

        modelBuilder.Entity<RadniZadatakUredjaj>().SeedData();

        modelBuilder.Entity<ServerSideSession>(entity =>
        {
            entity.HasIndex(e => e.DisplayName, "IX_ServerSideSessions_DisplayName");

            entity.HasIndex(e => e.Expires, "IX_ServerSideSessions_Expires");

            entity.HasIndex(e => e.Key, "IX_ServerSideSessions_Key").IsUnique();

            entity.HasIndex(e => e.SessionId, "IX_ServerSideSessions_SessionId");

            entity.HasIndex(e => e.SubjectId, "IX_ServerSideSessions_SubjectId");

            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Scheme).HasMaxLength(100);
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(100);
        });

        modelBuilder.Entity<Servi>(entity =>
        {
            entity.HasKey(e => e.ServisId).HasName("PK_ServisID");

            entity.Property(e => e.ServisId).HasColumnName("ServisID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.Napomena).HasColumnType("text");
            entity.Property(e => e.RadniZadatakId).HasColumnName("RadniZadatakID");
            entity.Property(e => e.UredjajId).HasColumnName("UredjajID");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Servis)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikID");

            entity.HasOne(d => d.RadniZadatak).WithMany(p => p.Servis)
                .HasForeignKey(d => d.RadniZadatakId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RadniZadatakID");

            entity.HasOne(d => d.Uredjaj).WithMany(p => p.Servis)
                .HasForeignKey(d => d.UredjajId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UredjajID");
        });

        modelBuilder.Entity<Servi>().SeedData();

        modelBuilder.Entity<Stanice>(entity =>
        {
            entity.ToTable("Stanice");
        });

        modelBuilder.Entity<StaniceUredjaj>(entity =>
        {
            entity.ToTable("StaniceUredjaj");

            entity.HasIndex(e => e.StanicaId, "IX_StaniceUredjaj_StanicaID");

            entity.HasIndex(e => e.UredjajId, "IX_StaniceUredjaj_UredjajID");

            entity.Property(e => e.StanicaId).HasColumnName("StanicaID");
            entity.Property(e => e.UredjajId).HasColumnName("UredjajID");

            entity.HasOne(d => d.Stanica).WithMany(p => p.StaniceUredjajs).HasForeignKey(d => d.StanicaId);

            entity.HasOne(d => d.Uredjaj).WithMany(p => p.StaniceUredjajs).HasForeignKey(d => d.UredjajId);
        });

        modelBuilder.Entity<TipUredjaja>(entity =>
        {
            entity.ToTable("TipUredjaja");

            entity.Property(e => e.TipUredjajaId).HasColumnName("TipUredjajaID");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);
        });

        modelBuilder.Entity<TipUredjaja>().SeedData();

        modelBuilder.Entity<Uredjaj>(entity =>
        {
            entity.ToTable("Uredjaj");

            entity.Property(e => e.UredjajId).HasColumnName("UredjajID");
            entity.Property(e => e.GodinaIzvedbe).HasMaxLength(255);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Koda).HasMaxLength(255);
            entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");
            entity.Property(e => e.SerijskiBroj).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TipId).HasColumnName("TipID");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Uredjajs)
                .HasForeignKey(d => d.LokacijaId)
                .HasConstraintName("FK__Uredjaj__Lokacij__45F365D3");

            entity.HasOne(d => d.Tip).WithMany(p => p.Uredjajs)
                .HasForeignKey(d => d.TipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UredjajTip");
            
        });

        modelBuilder.Entity<Uredjaj>().SeedData();

        modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<int>>(


            entity => {
                //entity.ToTable("KorisniciUloge");
                entity.HasKey(p => new { p.UserId, p.RoleId }); 
            }
            
            );
        modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<int>>().SeedData();

        modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<int>>().HasKey(p => new { p.Id });
        modelBuilder.Entity<IdentityRoleClaim<int>>().HasKey(p => new { p.Id });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
