using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PokemonInfoFetcher.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonInfoFetcher
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            // Startup.cs finally :)
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                                        .CreateLogger<Program>();

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
                    logger.LogError("Poke API does not have for that pokemon, currently only information up to gen 7 is available");
                }
                catch (NoSmogonDataException e)
                {
                    logger.LogError(e.Message);
                }
            }
        }
    }
}
