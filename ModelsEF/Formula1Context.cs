using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMVC.ModelsEF;

public partial class Formula1Context : DbContext
{
    public Formula1Context()
    {
    }

    public Formula1Context(DbContextOptions<Formula1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Chefe> Chefes { get; set; }

    public virtual DbSet<Conquista> Conquistas { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<Equipes2> Equipes2s { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<ViewEquipe> ViewEquipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Formula1;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => e.IdCarro).HasName("PK__Carros__6C9FE07B96D3F6D6");

            entity.Property(e => e.FabricanteMotor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModeloCarro)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Carros)
                .HasForeignKey(d => d.IdEquipe)
                .HasConstraintName("FK__Carros__IdEquipe__4D5F7D71");
        });

        modelBuilder.Entity<Chefe>(entity =>
        {
            entity.HasKey(e => e.IdChefe).HasName("PK__Chefes__F59E6E08D430AE32");

            entity.Property(e => e.NomeChefe)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Cheves)
                .HasForeignKey(d => d.IdEquipe)
                .HasConstraintName("FK__Chefes__IdEquipe__503BEA1C");
        });

        modelBuilder.Entity<Conquista>(entity =>
        {
            entity.HasKey(e => e.IdConquista).HasName("PK__Conquist__84DCA51C08A6628E");

            entity.Property(e => e.QtdGrandesPremios)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdPodios)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdPolePosition)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdTitulosConstrutores)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdTitulosPilotos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdVitorias)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdVoltasRapidas)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Conquista)
                .HasForeignKey(d => d.IdEquipe)
                .HasConstraintName("FK__Conquista__IdEqu__531856C7");
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.IdEquipe).HasName("PK__Equipes__D8052412321364EF");

            entity.HasIndex(e => e.SlugEquipe, "UQ__Equipes__CE5716260A058829").IsUnique();

            entity.Property(e => e.CorScuderia)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NomeEquipe)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SlugEquipe)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UrlFotoPilotos)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UrlFotoScuderia)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Equipes2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Equipes2");

            entity.Property(e => e.Construtor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EquipeId).HasColumnName("EquipeID");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Motor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NacionalidadePiloto1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NacionalidadePiloto2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomeChefe)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeEquipe)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomePiloto1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomePiloto2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdGrandesPremios)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdPodios)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdPolePosition)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdTitulosConstrutores)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdTitulosPilotos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdVitorias)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QtdVoltasRapidas)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("PK__Pilotos__DB35379FD5CEF028");

            entity.Property(e => e.NacionalidadePiloto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomePiloto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UrlFotoPiloto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Pilotos)
                .HasForeignKey(d => d.IdEquipe)
                .HasConstraintName("FK__Pilotos__IdEquip__4A8310C6");
        });

        modelBuilder.Entity<ViewEquipe>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewEquipes");

            entity.Property(e => e.FabricanteMotor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModeloCarro)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
