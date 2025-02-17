using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAb120217.Models;

public partial class PokemonContext : DbContext
{
    public PokemonContext()
    {
    }

    public PokemonContext(DbContextOptions<PokemonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Pokemon;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.PokeId).HasName("PK__Pokemon__8B129129EA1B928B");

            entity.ToTable("Pokemon");

            entity.Property(e => e.PokeId).HasColumnName("PokeID");
            entity.Property(e => e.Memo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PokeDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.PokeImage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PokeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
