using Bazaar.Forms;
using BusinessLayer.Interfaces;
using BusinessLayer.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.Controllers
{
	public class ProductController: IProductController
	{
		private IProductService _productService;

		public ProductController(IProductService dependency)
		{
			_productService = dependency;
		}

		public List<Product> GetAllProducts()
		{
			var a = _productService.GetAllProducts();
			return a;
		}

		public string BuyProduct(int productID, int quantity)
		{
			try
			{
				_productService.RemoveFromStock(productID, quantity);

				return ("Success!");
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}


		public List<BusinessLayer.PresentationModels.Type> GetAllTypes()
		{
			return _productService.GetAllTypes();
		}

		public List<Product> GetAllProducts(List<int> filteredCategoryIDs)
		{
			return _productService.GetAllProducts(filteredCategoryIDs);
		}
	}
}
