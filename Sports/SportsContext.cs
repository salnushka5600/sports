using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Sports;

public partial class SportsContext : DbContext
{
    public SportsContext()
    {
    }

    public SportsContext(DbContextOptions<SportsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Athlet> Athlets { get; set; }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;database=sports;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Athlet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Athlet");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.Level).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Participation");

            entity.HasIndex(e => e.IdAthlet, "FK_Participation_idAthlet");

            entity.HasIndex(e => e.IdWorkout, "FK_Participation_idWorkout");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdAthlet)
                .HasColumnType("int(11)")
                .HasColumnName("idAthlet");
            entity.Property(e => e.IdWorkout)
                .HasColumnType("int(11)")
                .HasColumnName("idWorkout");

            entity.HasOne(d => d.IdAthletNavigation).WithMany(p => p.Participations)
                .HasForeignKey(d => d.IdAthlet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participation_idAthlet");

            entity.HasOne(d => d.IdWorkoutNavigation).WithMany(p => p.Participations)
                .HasForeignKey(d => d.IdWorkout)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participation_idWorkout");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Progress");

            entity.HasIndex(e => e.IdAthlet, "FK_Progress_idAthlet");

            entity.HasIndex(e => e.IdWorkout, "FK_Progress_idWorkout");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Grade).HasColumnType("int(11)");
            entity.Property(e => e.IdAthlet)
                .HasColumnType("int(11)")
                .HasColumnName("idAthlet");
            entity.Property(e => e.IdWorkout)
                .HasColumnType("int(11)")
                .HasColumnName("idWorkout");

            entity.HasOne(d => d.IdAthletNavigation).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.IdAthlet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Progress_idAthlet");

            entity.HasOne(d => d.IdWorkoutNavigation).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.IdWorkout)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Progress_idWorkout");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Workout");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.Duration).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
