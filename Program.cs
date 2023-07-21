using FuzzySharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleDynamicSearch_FuzzySearch.Services;


namespace ConsoleDynamicSearch_FuzzySearch
{
    internal class Program
    {


        static async Task Main(string[] args)
        {

             var products = await new ProductRepository().GetProducts();

            Console.WriteLine("Type a name or abrand of a product: ");
            var userEntry = "";

            while (true)
            {
                var keyTyped = Console.ReadKey(intercept: true);


                if (keyTyped.Key == ConsoleKey.Backspace)
                {
                    if (userEntry.Length > 0)
                    {
                        userEntry = userEntry.Substring(0, userEntry.Length - 1);

                    }
                }
                else
                {
                    userEntry += keyTyped.KeyChar;
                    Console.Write(keyTyped.KeyChar);
                }
                Console.Clear();

                var fuzzyScores = await new FuzzySearchService().FuzzySearchScores(products, userEntry);


               
                var rankingCutLine = 60;
                var amountToDisplay = 5;
                var searchResults = fuzzyScores.Where(x => x.score >= rankingCutLine).Select(x => x.product)
                                               .OrderByDescending(x => fuzzyScores.FirstOrDefault(y => y.product == x).score)
                                               .Take(amountToDisplay).ToList();


                Console.WriteLine($"There are {searchResults.Count()} results for '{userEntry}': \n");

                foreach (var product in searchResults)
                {
                    Console.WriteLine($"Name: {product.name}");
                    Console.WriteLine($"Brand: {product.brand}\n");
                }

                Console.Write("Type a name or abrand of a product: " + userEntry);

            }

        }
    }
}