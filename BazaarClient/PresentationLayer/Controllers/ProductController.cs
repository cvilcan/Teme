using NetworkModule.Interfaces;
using NetworkModule.PresentationModels;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkUtilities.ExtensionMethods;

namespace PresentationLayer.Controllers
{
	public class ProductController: IProductController
	{
        const int OPERATION_TIMEOUT = 7000;
		private  IProductService _productService;

		public ProductController(IProductService dependency)
		{
			_productService = dependency;
		}

		public List<Product> GetAllProducts()
		{
            Func<List<Product>> getAll = () => _productService.GetAllProducts();
            return getAll.WithTimeout(OPERATION_TIMEOUT);
		}

		public string BuyProduct(Guid userID, int productID, int quantity)
		{
            Func<string> getAll = () => _productService.BuyProduct(userID, productID, quantity);
            return getAll.WithTimeout(7000);
		}

		public List<NetworkModule.PresentationModels.Type> GetAllTypes()
		{
            Func<List<NetworkModule.PresentationModels.Type>> getAll = () => _productService.GetAllTypes();
            return getAll.WithTimeout(OPERATION_TIMEOUT);
		}

		public List<Product> GetAllProducts(List<int> filteredCategoryIDs)
		{
            Func<List<Product>> getAll = () => _productService.GetAllProducts(filteredCategoryIDs);
            return getAll.WithTimeout(OPERATION_TIMEOUT);
		}

		public List<Product> GetAllProductsFromCart(Guid loginToken)
		{
            Func<Guid, List<Product>> getAll = (token) => _productService.GetAllProductsFromCart(token);
            return getAll.Curry<Guid, List<Product>>(loginToken).WithTimeout(OPERATION_TIMEOUT);
		}
	}
}
