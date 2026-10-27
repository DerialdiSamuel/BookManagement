using System;
using System.Collections.Generic;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buku> Bukus { get; set; }

    public virtual DbSet<HistoriBuku> HistoriBukus { get; set; }

    public virtual DbSet<MasterJenisBuku> MasterJenisBukus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buku>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Buku__3214EC0733353C69");

            entity.ToTable("Buku");

            entity.Property(e => e.Judul)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Penulis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TanggalRilis).HasColumnType("datetime");

            entity.HasOne(d => d.JenisBukuNavigation).WithMany(p => p.Bukus)
                .HasForeignKey(d => d.JenisBuku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buku_MasterJenisBuku");
        });

        modelBuilder.Entity<HistoriBuku>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HistoriB__3214EC07D5864C9E");

            entity.ToTable("HistoriBuku");

            entity.Property(e => e.Aksi)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TanggalPerubahan).HasColumnType("datetime");
        });

        modelBuilder.Entity<MasterJenisBuku>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterJe__3214EC07559E4625");

            entity.ToTable("MasterJenisBuku");

            entity.Property(e => e.JenisBuku)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
