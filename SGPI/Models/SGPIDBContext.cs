﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGPI.Models
{
    public partial class SGPIDBContext : DbContext
    {
        public SGPIDBContext()
        {
        }

        public SGPIDBContext(DbContextOptions<SGPIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;
        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Entrevistum> Entrevista { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Homologacion> Homologacions { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Programa> Programas { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoHomologacion> TipoHomologacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0R9U54R\\SQLEXPRESS;Database=SGPIDB;Trusted_Connection=True;");
            }
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura)
                    .HasName("PK__Asignatu__94F174B81DE0E94D");

                entity.ToTable("Asignatura");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Asignatura_Programa");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__Document__0E65F8DBD59CEFAF");

                entity.ToTable("Documento");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.IdEntrevista)
                    .HasName("PK__Entrevis__EE6CE9C789DFCCEB");

                entity.Property(e => e.IdEntrevista).ValueGeneratedOnAdd();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdEntrevistaNavigation)
                    .WithOne(p => p.Entrevistum)
                    .HasForeignKey<Entrevistum>(d => d.IdEntrevista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrevista_Estudiante");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrevista_Usuario");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__B5007C2471FB1250");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPagoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_Pagos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_Usuario");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F834988F1D7ADC4");

                entity.ToTable("Genero");

                entity.Property(e => e.Genero1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Genero");
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.IdHomologacion)
                    .HasName("PK__Homologa__C774631939202769");

                entity.ToTable("Homologacion");

                entity.Property(e => e.CodigoHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NomAsigHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Asignatura");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Estudiante");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Programa");

                entity.HasOne(d => d.IdTipoHomoloNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdTipoHomolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_TipoHomologacion");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__FC851A3AEF116DF5");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.IdPrograma)
                    .HasName("PK__Programa__AF94ECA524DCE5EE");

                entity.ToTable("Programa");

                entity.Property(e => e.Programa1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Programa");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion)
                    .HasName("PK__Programa__74E652C038C5C257");

                entity.ToTable("Programacion");

                entity.Property(e => e.FechaProgramacion).HasColumnType("datetime");

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Asignatura");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Programa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584C4C1899A0");

                entity.ToTable("Rol");

                entity.Property(e => e.Rol1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Rol");
            });

            modelBuilder.Entity<TipoHomologacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoHomologacion);

                entity.ToTable("TipoHomologacion");

                entity.Property(e => e.IdTipoHomologacion).ValueGeneratedNever();

                entity.Property(e => e.TipoHomologacion1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TipoHomologacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF976E0C7CBD");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Documento");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Genero");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Programa");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
