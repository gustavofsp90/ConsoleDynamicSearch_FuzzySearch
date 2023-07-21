using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDynamicSearch_FuzzySearch.Services
{
    public class FuzzySearchService : IFuzzySearchService
    {
        public  async Task<List<(Product product, int score)>> FuzzySearchScores(List<Product> products,
                                                                          string userEntry)
        {
            var fuzzyList = new List<(Product product, int score)>();

            foreach (var product in products)
            {
                var brandScore = Fuzz.PartialRatio(userEntry, product.brand);
                var nameScore = Fuzz.PartialRatio(userEntry, product.name);
                var score = Math.Max(brandScore, nameScore);
                fuzzyList.Add((product, score));
            }

            return await Task.FromResult(fuzzyList); 
        }


    }
}
