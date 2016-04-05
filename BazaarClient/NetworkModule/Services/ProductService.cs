using NetworkModule.Interfaces;
using NetworkModule.PresentationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModule.Services
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
			string response = _client.Send("/Product/GetAllProducts");
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<Product>>(response);
		}

		public List<PresentationModels.Product> GetAllProducts(List<int> selectedCategoryIDs)
		{
			string query = "/Product/GetAllProducts/" + JsonConvert.SerializeObject(selectedCategoryIDs);
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<Product>>(response);
		}

		public List<PresentationModels.Type> GetAllTypes()
		{
			string response = _client.Send("/Product/GetAllTypes");
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<NetworkModule.PresentationModels.Type>>(response);
		}

		public string BuyProduct(int userID, int productID, int quantity)
		{
			string query = "/Product/BuyProduct/" + Convert.ToString(userID) + "/" + Convert.ToString(productID)
				+ "/" + Convert.ToString(quantity);
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return response;
		}

		public List<Product> GetAllProductsFromCart(int userID)
		{
			string query = "/Product/GetAllProductsFromCart/" + Convert.ToString(userID);
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				return JsonConvert.DeserializeObject<List<Product>>(response);

		}
	}
}
