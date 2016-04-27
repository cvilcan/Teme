using NetworkModule.Interfaces;
using NetworkModule.PresentationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModule.Services.SocketServices
{
	public class ProductService: IProductService
	{
		private IAsynchronousClient _client;

		public ProductService(IAsynchronousClient dependency)
		{
			_client = dependency;
		}

		public List<PresentationModels.Product> GetAllProducts()
		{
			string response = _client.Send("&Product&GetAllProducts");
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
            {
                List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(response).Where(p => p.Quantity > 0).ToList();
                return productList;
            }
		}

		public List<PresentationModels.Product> GetAllProducts(List<int> selectedCategoryIDs)
		{
			string query = "&Product&GetAllProducts&" + JsonConvert.SerializeObject(selectedCategoryIDs);
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<Product>>(response).Where(p => p.Quantity > 0).ToList();
		}

		public List<PresentationModels.Type> GetAllTypes()
		{
			string response = _client.Send("&Product&GetAllTypes");
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<NetworkModule.PresentationModels.Type>>(response);
		}

		public string BuyProduct(Guid loginToken, int productID, int quantity)
		{
            string query = "&Product&BuyProduct&" + JsonConvert.SerializeObject(loginToken) + "&" + JsonConvert.SerializeObject(productID)
                + "&" + JsonConvert.SerializeObject(quantity);
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return response;
		}

		public List<Product> GetAllProductsFromCart(Guid loginToken)
		{
            string query = "&Product&GetAllProductsFromCart&" + JsonConvert.SerializeObject(loginToken);
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<Product>>(response);

		}
	}
}
