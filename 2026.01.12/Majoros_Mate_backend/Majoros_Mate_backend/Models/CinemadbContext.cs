using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Majoros_Mate_backend.Models;

public partial class CinemadbContext : DbContext
{
    public CinemadbContext()
    {
    }

    public CinemadbContext(DbContextOptions<CinemadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<FilmType> FilmTypes { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=cinemadb;user=root;password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PRIMARY");

            entity.ToTable("actors");

            entity.Property(e => e.ActorId)
                .HasColumnType("int(11)")
                .HasColumnName("actor_id");
            entity.Property(e => e.ActorName)
                .HasMaxLength(100)
                .HasColumnName("actor_name");
        });

        modelBuilder.Entity<FilmType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("film_type");

            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PRIMARY");

            entity.ToTable("movies");

            entity.HasIndex(e => e.ActorId, "actor_id");

            entity.HasIndex(e => e.FilmTypeId, "film_type_id");

            entity.Property(e => e.MovieId)
                .HasColumnType("int(11)")
                .HasColumnName("movie_id");
            entity.Property(e => e.ActorId)
                .HasColumnType("int(11)")
                .HasColumnName("actor_id");
            entity.Property(e => e.FilmTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("film_type_id");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Actor).WithMany(p => p.Movies)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("movies_ibfk_1");

            entity.HasOne(d => d.FilmType).WithMany(p => p.Movies)
                .HasForeignKey(d => d.FilmTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("movies_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
