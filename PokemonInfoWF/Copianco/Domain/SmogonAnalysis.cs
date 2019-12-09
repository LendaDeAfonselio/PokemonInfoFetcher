using System.Collections.Generic;

namespace PokemonInfoFetcher.Domain
{
    public class SmogonAnalyse
    {
        public string Format { get; set; }
        public string Overview { get; set; }
        public IEnumerable<SmogonMovesets> Movesets { get; set; }

    }
}
