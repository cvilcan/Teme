using NetworkModule.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModule.Interfaces
{
	public interface IProductService
	{
		List<Product> GetAllProducts();
		List<Product> GetAllProducts(List<int> selectedCategoryIDs);
		List<NetworkModule.PresentationModels.Type> GetAllTypes();
		string BuyProduct(int userID, int productID, int quantity);
		List<Product> GetAllProductsFromCart(int userID);
	}
}
