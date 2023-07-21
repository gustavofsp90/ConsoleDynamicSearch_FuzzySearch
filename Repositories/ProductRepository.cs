using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleDynamicSearch_FuzzySearch
{
    public class ProductRepository : IProductRepository
    {
        public async Task<string> GetJsonFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);


                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            var url = "https://atual.network/8a907b91d1c49b281718f851f83a2066/products.json";
            string jsonContent = await GetJsonFromUrl(url);
            var dbProducts = JsonSerializer.Deserialize<List<Product>>(jsonContent);

            return dbProducts;
        }
    }
}
