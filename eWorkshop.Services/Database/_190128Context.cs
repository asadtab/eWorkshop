using System;
using System.Collections.Generic;
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

    public virtual DbSet<IzvrseniServi> IzvrseniServis { get; set; }

    public virtual DbSet<Klijenti> Klijentis { get; set; }

    public virtual DbSet<Komponente> Komponentes { get; set; }

    public virtual DbSet<Korisnici> Korisnicis { get; set; }

    public virtual DbSet<KorisniciUloge> KorisniciUloges { get; set; }

    public virtual DbSet<Lokacija> Lokacijas { get; set; }

    public virtual DbSet<Magacin> Magacins { get; set; }

    public virtual DbSet<RadniZadatak> RadniZadataks { get; set; }

    public virtual DbSet<RadniZadatakUredjaj> RadniZadatakUredjajs { get; set; }

    public virtual DbSet<Servi> Servis { get; set; }

    public virtual DbSet<TipUredjaja> TipUredjajas { get; set; }

    public virtual DbSet<Ugovor> Ugovors { get; set; }

    public virtual DbSet<Uloge> Uloges { get; set; }

    public virtual DbSet<Upit> Upits { get; set; }

    public virtual DbSet<Uredjaj> Uredjajs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1, 1434;Initial Catalog=190128; user=sa; Password=QWEasd123!; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IzvrseniServi>(entity =>
        {
            entity.HasKey(e => e.IzvrseniServisId);

            entity.Property(e => e.IzvrseniServisId).HasColumnName("IzvrseniServisID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KomponentaId).HasColumnName("KomponentaID");
            entity.Property(e => e.ServisId).HasColumnName("ServisID");

            entity.HasOne(d => d.Komponenta).WithMany(p => p.IzvrseniServis)
                .HasForeignKey(d => d.KomponentaId)
                .HasConstraintName("FK_KomponentaServis");

            entity.HasOne(d => d.Servis).WithMany(p => p.IzvrseniServis)
                .HasForeignKey(d => d.ServisId)
                .HasConstraintName("FK_Servis");
        });

        modelBuilder.Entity<Klijenti>(entity =>
        {
            entity.HasKey(e => e.KlijentId);

            entity.ToTable("Klijenti");

            entity.Property(e => e.KlijentId).HasColumnName("KlijentID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme).HasMaxLength(255);
            entity.Property(e => e.LozinkaHash).HasMaxLength(255);
            entity.Property(e => e.LozinkaSalt).HasMaxLength(255);
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .IsUnicode(false);
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

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.ToTable("Korisnici");

            entity.Property(e => e.KorisniciId).HasColumnName("KorisniciID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme).HasMaxLength(255);
            entity.Property(e => e.LozinkaHash).HasMaxLength(255);
            entity.Property(e => e.LozinkaSalt).HasMaxLength(255);
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefon).HasMaxLength(255);
        });

        modelBuilder.Entity<KorisniciUloge>(entity =>
        {
            entity.HasKey(e => e.KorisnikUlogaId).HasName("PK_KorisnikUloga");

            entity.ToTable("KorisniciUloge");

            entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikUloga");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UlogaKorisnik");
        });

        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.ToTable("Lokacija");

            entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);
        });

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

        modelBuilder.Entity<RadniZadatak>(entity =>
        {
            entity.ToTable("RadniZadatak");

            entity.Property(e => e.RadniZadatakId).HasColumnName("RadniZadatakID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.StateMachine).HasMaxLength(255);
        });

        modelBuilder.Entity<Servi>(entity =>
        {
            entity.HasKey(e => e.ServisId).HasName("PK_ServisID");

            entity.Property(e => e.ServisId).HasColumnName("ServisID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.Napomena).HasMaxLength(255);
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
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);
        });

        modelBuilder.Entity<Ugovor>(entity =>
        {
            entity.HasKey(e => e.UgovorId).HasName("PK_Uogovor");

            entity.ToTable("Ugovor");

            entity.Property(e => e.UgovorId).HasColumnName("UgovorID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.RadniZadatakId).HasColumnName("RadniZadatakID");

            entity.HasOne(d => d.RadniZadatak).WithMany(p => p.Ugovors)
                .HasForeignKey(d => d.RadniZadatakId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RadniZadatakUgovor");
        });

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK_Uloga");

            entity.ToTable("Uloge");

            entity.Property(e => e.UlogaId).HasColumnName("UlogaID");
            entity.Property(e => e.Naziv).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);
        });

        modelBuilder.Entity<Upit>(entity =>
        {
            entity.HasKey(e => e.UpitId).HasName("PK_Upis");

            entity.ToTable("Upit");

            entity.Property(e => e.UpitId).HasColumnName("UpitID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KlijentId).HasColumnName("KlijentID");
            entity.Property(e => e.Naslov).HasMaxLength(255);
            entity.Property(e => e.Opis).HasMaxLength(255);

            entity.HasOne(d => d.Klijent).WithMany(p => p.Upits)
                .HasForeignKey(d => d.KlijentId)
                .HasConstraintName("FK_KlijentUpis");
        });

        modelBuilder.Entity<Uredjaj>(entity =>
        {
            entity.ToTable("Uredjaj");

            entity.Property(e => e.UredjajId).HasColumnName("UredjajID");
            entity.Property(e => e.GodinaIzvedbe).HasMaxLength(1);
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
