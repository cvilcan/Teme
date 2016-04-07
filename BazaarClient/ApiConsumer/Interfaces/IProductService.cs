using ApiConsumer.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Interfaces
{
	public interface IProductService
	{
		List<Product> GetAllProducts();
		List<Product> GetAllProducts(List<int> selectedCategoryIDs);
		List<ApiConsumer.PresentationModels.Type> GetAllTypes();
		string BuyProduct(int userID, int productID, int quantity);
		List<Product> GetAllProductsFromCart(int userID);
	}
}
