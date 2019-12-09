using PokemonInfoFetcher.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonInfoFetcher
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to PokemonInfoFetcher!");

            // add option to receive user input
            while (true)
            {
                Console.WriteLine("Please insert the pokedex number or name of the pokemon you wish to get information for.");

                // check if it is number or name
                string input = Console.ReadLine();
                bool isNumeric = int.TryParse(input, out int pokedexNumber);

                // handle exceptions
                PokemonInfoFetcherService pokemonInforFetcherService = new PokemonInfoFetcherService();
                PokemonInformation result;
                try
                {
                    if (!isNumeric)
                    {
                        result = await pokemonInforFetcherService.GetPokemonInformationAsync(input);
                    }
                    else
                    {
                        result = await pokemonInforFetcherService.GetPokemonInformationAsync(pokedexNumber);
                    }
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("Poke API does not have for that pokemon, currently only information up to gen 7 is available");
                }
                catch (NoSmogonDataException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
