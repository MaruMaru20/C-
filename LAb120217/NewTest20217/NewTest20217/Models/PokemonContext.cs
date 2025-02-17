using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewTest20217.Models;

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

    public virtual DbSet<PokemonSkill> PokemonSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=PokemonBookConnstring");

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
