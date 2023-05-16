using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class SanbornsContext : DbContext
{
    public SanbornsContext()
    {
    }

    public SanbornsContext(DbContextOptions<SanbornsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= Sanborns; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision).HasName("PK__Division__542428D0616E2995");

            entity.ToTable("Division");

            entity.Property(e => e.IdDivision).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Sku).HasName("PK__Producto__CA1FD3C47CCE18C5");

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Descuento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Impuesto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precioventa).HasColumnType("money");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK__Producto__IdDivi__1920BF5C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
