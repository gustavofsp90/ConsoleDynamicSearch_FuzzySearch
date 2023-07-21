using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDynamicSearch_FuzzySearch
{
    public interface IProductRepository
    {
         Task<string> GetJsonFromUrl(string url);

         Task<List<Product>> GetProducts();


    }
}
