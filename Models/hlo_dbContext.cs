using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HLO_API.Models;

public partial class hlo_dbContext : DbContext
{
    public hlo_dbContext(DbContextOptions<hlo_dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<character> character { get; set; }

    public virtual DbSet<job> job { get; set; }

    public virtual DbSet<memberdata> memberdata { get; set; }

    public virtual DbSet<race> race { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<character>(entity =>
        {
            entity.HasKey(e => e.PlayerID).HasName("PRIMARY");

            entity.HasIndex(e => e.JobId, "JobId");

            entity.HasIndex(e => e.RaceId, "RaceId");

            entity.HasIndex(e => e.memberID, "fk_memberID");

            entity.Property(e => e.PlayerID).HasColumnType("int(11)");
            entity.Property(e => e.BagCount).HasColumnType("int(11)");
            entity.Property(e => e.CharacterCreateDate).HasColumnType("date");
            entity.Property(e => e.Coin).HasColumnType("int(11)");
            entity.Property(e => e.JobId).HasColumnType("int(11)");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.Level).HasColumnType("int(11)");
            entity.Property(e => e.PlayerName).HasMaxLength(20);
            entity.Property(e => e.RaceId).HasColumnType("int(11)");
            entity.Property(e => e.memberID).HasColumnType("int(11)");

            entity.HasOne(d => d.Job).WithMany(p => p.character)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("JobId");

            entity.HasOne(d => d.Race).WithMany(p => p.character)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("RaceId");

            entity.HasOne(d => d.member).WithMany(p => p.character)
                .HasForeignKey(d => d.memberID)
                .HasConstraintName("fk_memberID");
        });

        modelBuilder.Entity<job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity.Property(e => e.JobId).HasColumnType("int(11)");
            entity.Property(e => e.JobName).HasMaxLength(45);
        });

        modelBuilder.Entity<memberdata>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.Property(e => e.ID).HasColumnType("int(11)");
            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.GUID).HasMaxLength(20);
            entity.Property(e => e.createtime).HasColumnType("datetime");
            entity.Property(e => e.password).HasMaxLength(50);
            entity.Property(e => e.username).HasMaxLength(20);
        });

        modelBuilder.Entity<race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("PRIMARY");

            entity.Property(e => e.RaceId).HasColumnType("int(11)");
            entity.Property(e => e.RaceName).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
