using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ElBarDePili.DataBase;

public partial class ElbardepiliContext : DbContext
{
    public ElbardepiliContext()
    {
    }

    public ElbardepiliContext(DbContextOptions<ElbardepiliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredientes> Ingredientes { get; set; }

    public virtual DbSet<Recetas> Recetas { get; set; }

    public virtual DbSet<RecetasIngredientes> RecetasIngredientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredientes>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Recetas>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Imagen).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<RecetasIngredientes>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Idingrediente).HasColumnName("IDIngrediente");
            entity.Property(e => e.Idreceta).HasColumnName("IDReceta");

            entity.HasOne(d => d.IdingredienteNavigation).WithMany(p => p.RecetasIngredientes)
                .HasForeignKey(d => d.Idingrediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecetasIngredientes_Ingredientes");

            entity.HasOne(d => d.IdrecetaNavigation).WithMany(p => p.RecetasIngredientes)
                .HasForeignKey(d => d.Idreceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecetasIngredientes_Recetas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
