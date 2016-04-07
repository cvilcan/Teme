using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using CommunicationLayer.PresentationModels;
using CommunicationLayer.Interfaces;

namespace ApiConsumer
{
    public class HttpApiConsumer: IUserService, IProductService
    {
        public async Task<int> LoginAsync(string username, string hashedPassword)
        {
            using (var client = new HttpClient())
            {
                int userID = -1;

                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("hashedPassword", hashedPassword)
                });

                var res = await client.PostAsync("http://localhost:54256/api/Account/Login", content).ConfigureAwait(false);

                string contents = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (Int32.TryParse(JsonConvert.DeserializeObject<string>(contents), out userID))
                    return userID;
                else return -1;
            }
        }

        public int Login(string username, string hashedPassword)
        {
            var task = LoginAsync(username, hashedPassword);
            return task.Result;
        }

        public int Register(string username, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(List<int> selectedCategoryIDs)
        {
            throw new NotImplementedException();
        }

        public List<Type> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public string BuyProduct(int userID, int productID, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProductsFromCart(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
