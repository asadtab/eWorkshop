using eWorkshop.Services.Database.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eWorkshop.Services.Database;

public partial class _190128Context : DbContext
{
    public _190128Context(DbContextOptions<_190128Context> options)
        : base(options)
    {
    }

    public virtual DbSet<IzvrseniServi> IzvrseniServis { get; set; }

    public virtual DbSet<Servi> Servi { get; set; }
    public virtual DbSet<Prijem> Prijem { get; set; }
    public virtual DbSet<Komponente> Komponentes { get; set; }
    public virtual DbSet<Korisnici> Korisnicis { get; set; }
    public virtual DbSet<Lokacija> Lokacijas { get; set; }
    public virtual DbSet<RadniZadatak> RadniZadataks { get; set; }
    public virtual DbSet<RadniZadatakUredjaj> RadniZadatakUredjajs { get; set; }
    public virtual DbSet<TipUredjaja> TipUredjajas { get; set; }
    public virtual DbSet<Uloge> Uloge { get; set; }
    public virtual DbSet<IdentityUserRole<int>> KorisniciUloge { get; set; }
    public virtual DbSet<IdentityUserClaim<int>> KorisniciClaim { get; set; }
    public virtual DbSet<IdentityRoleClaim<int>> UlogeClaim { get; set; }
    public virtual DbSet<Uredjaj> Uredjajs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IzvrseniServi>(entity =>
        {
            entity.HasKey(e => e.IzvrseniServisId);

            entity.Property(e => e.IzvrseniServisId).HasColumnName("IzvrseniServisID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KomponentaId).HasColumnName("KomponentaID");
            entity.Property(e => e.KomponentaNaziv).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.KomponentaTip).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.KomponentaVrijednost).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.ServisId).HasColumnName("ServisID");

            entity.HasOne(d => d.Komponenta).WithMany(p => p.IzvrseniServis)
                .HasForeignKey(d => d.KomponentaId)
                .HasConstraintName("FK_KomponentaServis");

            entity.HasOne(d => d.Servis).WithMany(p => p.IzvrseniServis)
                .HasForeignKey(d => d.ServisId)
                .HasConstraintName("FK_Servis");
        });

        modelBuilder.Entity<Komponente>(entity =>
        {
            entity.HasKey(e => e.KomponentaId).HasName("PK_Komponenta");
            entity.ToTable("Komponente");

            entity.Property(e => e.KomponentaId).HasColumnName("KomponentaID");
            entity.Property(e => e.Naziv).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Opis).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Tip).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Vrijednost).HasMaxLength(255).IsRequired(false);
        });

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.ToTable("Korisnici");

            entity.Property(e => e.Email).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .IsUnicode(false).IsRequired(false);
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .IsUnicode(false).IsRequired(false);
        });

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.ToTable("Uloge");

            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.NormalizedName).IsRequired(false)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConcurrencyStamp).IsRequired(false)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.ToTable("Lokacija");

            entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");
            entity.Property(e => e.Naziv).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Opis).HasMaxLength(255).IsRequired(false);
        });

        modelBuilder.Entity<RadniZadatak>(entity =>
        {
            entity.ToTable("RadniZadatak");

            entity.Property(e => e.RadniZadatakId).HasColumnName("RadniZadatakID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.Naziv).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.StateMachine).HasMaxLength(255).IsRequired(false);
        });

        modelBuilder.Entity<RadniZadatakUredjaj>(entity =>
        {
            entity.ToTable("RadniZadatakUredjaj");

            entity.Property(e => e.Napomena)
                .HasMaxLength(255)
                .IsUnicode(false).IsRequired(false);

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

        modelBuilder.Entity<Servi>(entity =>
        {
            entity.HasKey(e => e.ServisId).HasName("PK_ServisID");

            entity.Property(e => e.ServisId).HasColumnName("ServisID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
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

        modelBuilder.Entity<TipUredjaja>(entity =>
        {
            entity.ToTable("TipUredjaja");

            entity.Property(e => e.TipUredjajaId).HasColumnName("TipUredjajaID");
            entity.Property(e => e.Naziv).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Opis).HasMaxLength(255).IsRequired(false);
        });

        modelBuilder.Entity<Uredjaj>(entity =>
        {
            entity.ToTable("Uredjaj");

            entity.Property(e => e.UredjajId).HasColumnName("UredjajID");
            entity.Property(e => e.GodinaIzvedbe).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Koda).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");
            entity.Property(e => e.SerijskiBroj).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Status).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.TipId).HasColumnName("TipID");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Uredjajs)
                .HasForeignKey(d => d.LokacijaId)
                .HasConstraintName("FK__Uredjaj__Lokacij__45F365D3");

            entity.HasOne(u => u.Prijem)
    .WithOne(p => p.Uredjaj)
    .HasForeignKey<Prijem>(p => p.UredjajId)
    .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Tip).WithMany(p => p.Uredjajs)
                .HasForeignKey(d => d.TipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UredjajTip");
        });

        modelBuilder.Entity<Prijem>()
    .HasIndex(p => p.UredjajId)
    .IsUnique();

        modelBuilder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.HasKey(p => new { p.UserId, p.RoleId });
            entity.ToTable("KorisniciUloge");
        });

        modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
        {
            entity.HasKey(p => p.Id);
        });

        modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
        {
            entity.HasKey(p => p.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}