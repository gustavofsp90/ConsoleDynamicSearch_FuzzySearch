using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDynamicSearch_FuzzySearch.Services
{
    public interface IFuzzySearchService
    {
         Task<List<(Product product, int score)>> FuzzySearchScores(List<Product> products, string userEntry);

    }
}
 