using PokemonInfoFetcher.Domain;
using System.Threading.Tasks;

namespace PokemonInfoFetcher
{
    /// <summary>
    /// Class that implements methods and logic to get usefull information about a pokemon
    /// </summary>
    public interface IPokemonInfoFetcherService
    {
        /// <summary>
        /// Gets information about a pokemon based on <paramref name="pokemonName"/>
        /// </summary>
        /// <param name="pokemonName">The name of the pokemon</param>
        /// <returns></returns>
        public Task<PokemonInformation> GetPokemonInformationAsync(string pokemonName);

        /// <summary>
        /// Gets information about a pokemon based on <paramref name="pokedexNumber"/>
        /// </summary>
        /// <param name="pokedexNumber">The pokedex number</param>
        /// <returns></returns>
        public Task<PokemonInformation> GetPokemonInformationAsync(int pokedexNumber);
    }
}
