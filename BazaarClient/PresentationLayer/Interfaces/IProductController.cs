using NetworkModule.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Interfaces
{
	public interface IProductController
	{
		List<Product> GetAllProducts();

		string BuyProduct(int usderID, int productID, int quantity);

		List<NetworkModule.PresentationModels.Type> GetAllTypes();

		List<Product> GetAllProducts(List<int> selectedCategoryIDs);

		List<Product> GetAllProductsFromCart(int userID);
	}
}
