using System;
using System.Collections.Generic;

namespace NewTest20217.Models;

public partial class Pokemon
{
    public int PokeId { get; set; }

    public string? PokeName { get; set; }

    public string? PokeImage { get; set; }

    public string? Memo { get; set; }

    public DateTime? PokeDate { get; set; }

    public byte[]? PokeImageInTable { get; set; }

    public virtual ICollection<PokemonSkill> PokemonSkills { get; set; } = new List<PokemonSkill>();
}
