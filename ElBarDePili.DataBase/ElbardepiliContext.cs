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

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<RecetasIngrediente> RecetasIngredientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:fd-frias.database.windows.net,1433;Initial Catalog=elbardepili;Persist Security Info=False;User ID=fd.frias;Password=P0rtale5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<RecetasIngrediente>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idingrediente).HasColumnName("IDIngrediente");
            entity.Property(e => e.Idreceta).HasColumnName("IDReceta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
