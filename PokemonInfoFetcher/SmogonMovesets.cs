using System.Collections.Generic;

namespace PokemonInfoFetcher
{
    public class SmogonMovesets
    {
        public string Name { get; set; } // TODO - Might not be necessary
        public string Pokemon { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Abilities { get; set; }
        public IEnumerable<IEnumerable<string>> Moveslots { get; set; } // TODO - review later
        public IEnumerable<PokemonStats> EVConfigs { get; set; }
        public IEnumerable<PokemonStats> IVConfigs { get; set; }
        public IEnumerable<string> Nature { get; set; }

    }
}
