using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kapcsolo> Kapcsolos { get; set; }

    public virtual DbSet<Rendele> Rendeles { get; set; }

    public virtual DbSet<Termekek> Termekeks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kapcsolo>(entity =>
        {
            entity.HasKey(e => e.KapcsoloId).HasName("PRIMARY");

            entity.ToTable("kapcsolo");

            entity.HasIndex(e => e.RendelesId, "RendelesId");

            entity.HasIndex(e => e.TermekekId, "termekekId");

            entity.Property(e => e.KapcsoloId).HasColumnType("int(11)");
            entity.Property(e => e.RendelesId).HasColumnType("int(11)");
            entity.Property(e => e.TermekekId)
                .HasColumnType("int(11)")
                .HasColumnName("termekekId");

            entity.HasOne(d => d.Rendeles).WithMany(p => p.Kapcsolos)
                .HasForeignKey(d => d.RendelesId)
                .HasConstraintName("kapcsolo_ibfk_1");

            entity.HasOne(d => d.Termekek).WithMany(p => p.Kapcsolos)
                .HasForeignKey(d => d.TermekekId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("kapcsolo_ibfk_2");
        });

        modelBuilder.Entity<Rendele>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rendeles");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AsztalSzam)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.FizetesMod)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Termekek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("termekek");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Ar)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Etel)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
