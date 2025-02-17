using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAb120217.Models;

public partial class PokemonsContext : DbContext
{
    public PokemonsContext()
    {
    }

    public PokemonsContext(DbContextOptions<PokemonsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonSkill> PokemonSkills { get; set; }

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

        modelBuilder.Entity<PokemonSkill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__PokemonS__DFA091E7356FCB48");

            entity.ToTable("PokemonSkill");

            entity.Property(e => e.SkillId).HasColumnName("SkillID");
            entity.Property(e => e.PokeId).HasColumnName("PokeID");
            entity.Property(e => e.PokeSkill)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Poke).WithMany(p => p.PokemonSkills)
                .HasForeignKey(d => d.PokeId)
                .HasConstraintName("FK__PokemonSk__PokeI__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
