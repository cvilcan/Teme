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

		string BuyProduct(Guid loginToken, int productID, int quantity);

		List<NetworkModule.PresentationModels.Type> GetAllTypes();

		List<Product> GetAllProducts(List<int> selectedCategoryIDs);

		List<Product> GetAllProductsFromCart(Guid loginToken);
	}
}
