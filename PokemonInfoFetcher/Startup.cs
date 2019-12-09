using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PokemonInfoFetcher
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information)
                    .AddTransient<PokemonInfoFetcherService>();

            services.AddScoped<IPokemonInfoFetcherService, PokemonInfoFetcherService>();
        }
    }
}
