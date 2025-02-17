using System;
using System.Collections.Generic;

namespace NewTest20217.Models;

public partial class PokemonSkill
{
    public int SkillId { get; set; }

    public int? PokeId { get; set; }

    public string? PokeSkill { get; set; }

    public virtual Pokemon? Poke { get; set; }
}
