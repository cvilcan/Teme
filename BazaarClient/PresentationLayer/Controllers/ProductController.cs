using NetworkModule.Interfaces;
using NetworkModule.PresentationModels;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
	public class ProductController: IProductController
	{
		private  IProductService _productService;

		public ProductController(IProductService dependency)
		{
			_productService = dependency;
		}

		public List<Product> GetAllProducts()
		{
			var a = _productService.GetAllProducts();
			return a;
		}

		public string BuyProduct(int userID, int productID, int quantity)
		{
			try
			{
				return _productService.BuyProduct(userID, productID, quantity);

				return ("Success!");
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		public List<NetworkModule.PresentationModels.Type> GetAllTypes()
		{
			return _productService.GetAllTypes();
		}

		public List<Product> GetAllProducts(List<int> filteredCategoryIDs)
		{
			return _productService.GetAllProducts(filteredCategoryIDs);
		}

		public List<Product> GetAllProductsFromCart(int userID)
		{
			return _productService.GetAllProductsFromCart(userID);
		}
	}
}
