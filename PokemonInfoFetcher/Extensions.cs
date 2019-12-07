namespace PokemonInfoFetcher
{
    public static class Extensions
    {
        public static PokemonStats ConvertToBaseStats(this PokeAPI.PokemonStats[] pokeAPIpokemonStats)
        {
            PokemonStats stats = new PokemonStats();
            foreach (var stat in pokeAPIpokemonStats)
            {
                switch (stat.Stat.Name)
                {
                    case ("hp"):
                        stats.HP = stat.BaseValue;
                        break;
                    case ("attack"):
                        stats.Atk = stat.BaseValue;
                        break;
                    case ("defense"):
                        stats.Def = stat.BaseValue;
                        break;
                    case ("special-attack"):
                        stats.SpA = stat.BaseValue;
                        break;
                    case ("special-defense"):
                        stats.SpD = stat.BaseValue;
                        break;
                    case ("speed"):
                        stats.Spe = stat.BaseValue;
                        break;
                    default:
                        break;
                }
            }
            return stats;
        }
    }
}
