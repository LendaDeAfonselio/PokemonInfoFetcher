using System.Collections.Generic;

namespace PokemonInfoFetcher.Domain
{
    public class SmogonMovesets
    {
        public string Name { get; set; } // TODO - Might not be necessary
        public string Pokemon { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Items { get; set; }
        public IEnumerable<string> Abilities { get; set; }
        public IEnumerable<IEnumerable<string>> Moveslots { get; set; } // TODO - review later
        public IEnumerable<PokemonStats> EVConfigs { get; set; }
        public IEnumerable<PokemonStats> IVConfigs { get; set; }
        public IEnumerable<string> Natures { get; set; }

    }
}
