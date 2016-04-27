using NetworkModule.PresentationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModule.Services.ApiServices
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            try
            {
                Task<List<Product>> task = GetAllProductsAsync();
                return task.Result.Where(p => p.Quantity > 0).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }

        private async Task<List<Product>> GetAllProductsAsync()
        {
            List<Product> productList = new List<Product>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53658/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/api/Product").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    productList = JsonConvert.DeserializeObject<List<Product>>(responseString);
                }
                return productList;
            }
        }
    }
}
