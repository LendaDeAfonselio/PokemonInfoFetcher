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

            Pokemon p = await DataFetcher.GetNamedApiObject<Pokemon>("clefable");
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
            var result = strategiesContent.Select(p => JsonConvert.DeserializeObject<SmogonAnalysis>(p.ToString())).ToList();

            // final output
            result.ForEach(output => Console.WriteLine(JsonConvert.SerializeObject(output)));
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
