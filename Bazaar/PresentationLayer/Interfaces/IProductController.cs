using BusinessLayer.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bazaar.Forms
{
	public interface IProductController
	{
		List<Product> GetAllProducts();

		string BuyProduct(int productID, int quantity);

		List<BusinessLayer.PresentationModels.Type> GetAllTypes();

		List<Product> GetAllProducts(List<int> selectedCategoryIDs);
	}
}
