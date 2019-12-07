using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonInfoFetcher
{
    class Program
    {
        static async Task Main(string[] args)
        {

            PokemonSpecies pokemonSpecies = await DataFetcher.GetNamedApiObject<PokemonSpecies>("clefable");
            Pokemon pokemon = await DataFetcher.GetNamedApiObject<Pokemon>("clefable");

            string url = "https://www.smogon.com/dex/ss/pokemon/clefable/";

            // get the essencial of HTML
            string headlineText = await ExtractAndParseSmogonData(url);

            // transform the string containing the JSON into a JObject
            JObject jsonFromHtml = JObject.Parse(headlineText);

            // get the strategies part of the json recursively
            List<JToken> resultList = new List<JToken>();
            FindPropertyInJToken(jsonFromHtml, "strategies", resultList);

            // get contents and transform them into custom c# objects
            var strategiesContent = resultList[0].Children<JObject>();
            List<SmogonAnalyse> result = strategiesContent.Select(p => JsonConvert.DeserializeObject<SmogonAnalyse>(p.ToString())).ToList();

            // merge the information
            var pokemonInformation = await PokemonInformationMapperAsync(pokemon, pokemonSpecies, result);
        }

        private static async Task<object> PokemonInformationMapperAsync(Pokemon pokemon, PokemonSpecies pokemonSpecies, List<SmogonAnalyse> analysis)
        {
            return new PokemonInformation
            {
                Name = pokemon.Name,
                AllAbilities = pokemon.Abilities,
                BaseExperience = pokemon.BaseExperience,
                BaseStats = pokemon.Stats.ConvertToBaseStats(),
                PrimaryType = await pokemon.Types.First().Type.GetObject(),
                SecondaryType = await pokemon.Types.LastOrDefault().Type.GetObject(),
                EvolutionChain = await pokemonSpecies.EvolutionChain.GetObject(),
                Generation = await pokemonSpecies.Generation.GetObject(),
                HatchCounter = pokemonSpecies.HatchCounter,
                FemaleToMaleRate = pokemonSpecies.FemaleToMaleRate,
                EggGroup = await Task.WhenAll(pokemonSpecies.EggGroups.Select(group => group.GetObject())),
                PokemonColours = await pokemonSpecies.Colours.GetObject(),
                SmogonAnalysisList = analysis
            };
        }

        // get the json that the HTML in smogon for some reason contains
            private static async Task<string> ExtractAndParseSmogonData(string url)
            {
                // get html from url
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                var pageContents = await response.Content.ReadAsStringAsync();

                // select the node we want
                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(pageContents);
                var headlineText = pageDocument.DocumentNode.SelectSingleNode("//script").InnerText;

                // parsing the strim to be JSON readable
                Regex reg = new Regex("\n");
                headlineText = reg.Replace(headlineText, string.Empty, 1).Trim();
                headlineText = headlineText.Substring("dexSettings = ".Length);
                return headlineText;
            }

            // Finds a certain property in a JToken object
            private static void FindPropertyInJToken(JToken json, string strategies, List<JToken> fetchedToken)
            {
                foreach (var field in json)
                {
                    foreach (var array in field.Children<JArray>())
                    {
                        foreach (var parsedObject in array.Children<JObject>())
                        {
                            foreach (var property in parsedObject.Children<JProperty>())
                            {
                                if (property.Name == "strategies")
                                {
                                    fetchedToken.Add(property.Value);
                                }
                            }
                        }
                    }
                    if (fetchedToken.Count == 0)
                    {
                        FindPropertyInJToken(field, strategies, fetchedToken);
                    }
                }
            }
        }
    }
