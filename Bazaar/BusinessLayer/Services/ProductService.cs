using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.PresentationModels;

namespace BusinessLayer.Services
{
	public class ProductService: IProductService
	{
		private IProductRepository _productRepository;

		public ProductService(IProductRepository dependency)
		{
			_productRepository = dependency;
		}

		public List<PresentationModels.Product> GetAllProducts()
		{
			var productList = _productRepository.GetAllProducts();
			var stockList = _productRepository.GetAllStock();
			List<PresentationModels.Product> resultList = new List<PresentationModels.Product>();

			foreach (var item in productList)
			{
				List<BusinessLayer.PresentationModels.Type> typeList = new List<PresentationModels.Type>();
				foreach (var type in item.Types)
					typeList.Add(new PresentationModels.Type()
						{
							TypeID = type.TypeID,
							TypeName = type.TypeName
						});
				resultList.Add(new PresentationModels.Product()
					{
						Details = item.Details,
						ProductID = item.ProductID,
						ProductName = item.ProductName,
						Price = item.Price,
						Quantity = stockList.Where(x => x.ProductID == item.ProductID).First().Quantity,
						Types = typeList
					});
			}
			return resultList;
		}

		public List<Product> GetAllProducts(List<int> selectedCategoryIDs)
		{
			List<Product> productList = this.GetAllProducts();
			List<Product> resultList = new List<Product>();
			foreach (var item in productList)
			{
				bool found = false;
				foreach (var typeID in selectedCategoryIDs)
					if (item.Types.FindIndex(x => x.TypeID == typeID) != -1)
						found = true;
				if (found)
					resultList.Add(item);
			}

			return resultList;
		}

		public List<PresentationModels.Type> GetAllTypes()
		{
			List<BusinessLayer.PresentationModels.Type> typeList = new List<PresentationModels.Type>();
			foreach (var item in _productRepository.GetAllTypes())
				typeList.Add(new PresentationModels.Type()
					{
						TypeID = item.TypeID,
						TypeName = item.TypeName
					});

			return typeList;
		}

		public void RemoveFromStock(int productID, int quantity)
		{
			_productRepository.RemoveFromStock(productID, quantity);
		}
	}
}
