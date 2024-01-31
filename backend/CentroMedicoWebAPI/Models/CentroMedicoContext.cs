using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CentroMedicoWebAPI.Models;

public partial class CentroMedicoContext : DbContext
{
    public CentroMedicoContext()
    {
    }

    public CentroMedicoContext(DbContextOptions<CentroMedicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("PK__Ciudad__E826E790E37366BF");

            entity.ToTable("Ciudad");

            entity.Property(e => e.CiudadId).HasColumnName("CiudadID");
            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Ciudad__Departam__3C69FB99");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E1EC52C68EA");

            entity.ToTable("Departamento");

            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__Paciente__9353C07F1E2FB9EE");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__Paciente__A4202588FAE3BA9E").IsUnique();

            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CiudadResidencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
