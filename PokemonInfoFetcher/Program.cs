using PokeAPI;
using System.Threading.Tasks;

namespace PokemonInfoFetcher
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            // add option to receive user input

            // check if it is number or name

            // handle exceptions
            PokemonInfoFetcherService pokemonInforFetcherService = new PokemonInfoFetcherService();

            var result1 = await pokemonInforFetcherService.GetPokemonInformationAsync("clefable");
            var result2 = await pokemonInforFetcherService.GetPokemonInformationAsync(748);
        }
    }
}
