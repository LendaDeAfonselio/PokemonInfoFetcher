using PokeAPI;
using System.Collections.Generic;

namespace PokemonInfoFetcher.Domain
{
    public class PokemonInformation
    {
        public string Name { get; set; }
        public IEnumerable<PokemonAbility> AllAbilities { get; set; }
        public int BaseExperience { get; set; }
        public PokemonStats BaseStats { get; set; }
        public PokemonType PrimaryType { get; set; }
        public PokemonType SecondaryType { get; set; }
        public EvolutionChain EvolutionChain { get; set; }
        public Generation Generation { get; set; }
        public int HatchCounter { get; set; }
        public float? FemaleToMaleRate { get; set; }
        public IEnumerable<EggGroup> EggGroup { get; set; }
        public PokemonColour PokemonColours { get; set; }
        public IEnumerable<SmogonAnalyse> SmogonAnalysisList { get; set; }
    }
}
