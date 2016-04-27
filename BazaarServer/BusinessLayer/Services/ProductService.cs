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
        private IUserRepository _userRepository;

		public ProductService(IProductRepository dependency, IUserRepository depe2)
		{
			_productRepository = dependency;
            _userRepository = depe2;
		}

        public List<AccountantProduct> GetAllAccountantProducts()
        {
            var productList = _productRepository.GetAllProducts();
            var stockList = _productRepository.GetAllStock();
            List<PresentationModels.AccountantProduct> resultList = new List<PresentationModels.AccountantProduct>();

            foreach (var item in productList)
            {
                List<BusinessLayer.PresentationModels.Type> typeList = new List<PresentationModels.Type>();
                foreach (var type in item.Types)
                    typeList.Add(new PresentationModels.Type()
                    {
                        TypeID = type.TypeID,
                        TypeName = type.TypeName
                    });
                resultList.Add(new PresentationModels.AccountantProduct()
                {
                    Details = item.Details,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    InitialStock = stockList.Where(x => x.ProductID == item.ProductID).First().InitialQuantity,
                    Sold = stockList.Where(x => x.ProductID == item.ProductID).First().SoldQuantity,
                    Types = typeList
                });
            }
            return resultList;
        }

		public List<Product> GetAllProducts()
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
						Quantity = stockList.Where(x => x.ProductID == item.ProductID).Select(x => x.InitialQuantity - x.SoldQuantity).First(),
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

            List<PresentationModels.Type> filteredTypesList = GetAllTypes();
            for (int i = 0; i < filteredTypesList.Count; i++)
                if (selectedCategoryIDs.Contains(filteredTypesList[i].TypeID))
                    filteredTypesList.Remove(filteredTypesList[i]);

            for (int i = 0; i < resultList.Count; i++)
                foreach (var type in resultList[i].Types)
                    if (filteredTypesList.Contains(type))
                        resultList.Remove(resultList[i]);

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

        public void BuyProduct(Guid loginToken, int productID, int quantity)
		{
            var user = _userRepository.GetUserDetails(loginToken);
			_productRepository.SubstractFromStock(productID, quantity);
            _productRepository.AddToCart(user.Item1, productID, quantity);
		}

        public List<Product> GetAllProductsFromCart(Guid loginToken)
		{
			var carts = _productRepository.GetAllCarts();
			var products = _productRepository.GetAllProducts();
            var user = _userRepository.GetUserDetails(loginToken);
			products = 	
					(
					from p in products
					join c in carts
					on p.ProductID equals c.ProductID
                    where c.UserID == user.Item1
					select p
					).ToList();
			List<Product> resultList = new List<Product>();
			foreach (var item in products)
			{
				List<BusinessLayer.PresentationModels.Type> typeList = new List<PresentationModels.Type>();
				foreach (var type in item.Types)
					typeList.Add(new PresentationModels.Type()
						{
							TypeID = type.TypeID,
							TypeName = type.TypeName
						});
				int quantity = carts.Where(c => (c.UserID == user.Item1) && (c.ProductID == item.ProductID)).FirstOrDefault().Quantity;
				resultList.Add(new Product()
					{
						Details = item.Details,
						Price = item.Price,
						ProductID = item.ProductID,
						ProductName = item.ProductName,
						Quantity = quantity,
						Types = typeList
					});
			}
			
			return resultList;
		}
	}
}
