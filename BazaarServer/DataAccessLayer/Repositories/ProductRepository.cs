using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class ProductRepository : IProductRepository
	{
        private readonly EntityConnection _connection = null;

        public ProductRepository()
        {
            _connection = null;
        }

        public ProductRepository(EntityConnection con)
        {
            _connection = con;
        }

		public List<Product> GetAllProducts()
		{
            using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
			{
				List<Product> productList = context.Products.ToList();
				foreach (var item in productList)
                {
                    item.Types = item.Types.ToList();
                    item.Stock = item.Stock;
                }
				return productList;
			}
		}

		public List<Stock> GetAllStock()
		{
			using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
			{
				List<Stock> stockList = context.Stocks.ToList();
				return stockList;
			}
		}

		public List<Type> GetAllTypes()
		{
			using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
			{
				List<Type> typeList = context.Types.ToList();
				return typeList;
			}
		}

		public void SubstractFromStock(int productID, int quantity)
		{
			using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
			{
				Stock stock = context.Stocks.Where(s => s.ProductID == productID).FirstOrDefault();
				if (stock == null)
					throw new Exception("No stock with productID " + Convert.ToString(productID) + " found!");

				if (quantity > stock.InitialQuantity - stock.SoldQuantity)
					throw new Exception("Requested quantity exceeds stock!");
				
				context.Stocks.Attach(stock);
				stock.SoldQuantity += quantity;
				context.SaveChanges();
			}
		}

		public void AddToCart(int userID, int productID, int quantity)
		{
			using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
			{
				Cart cart = context.Carts.Where(c => (c.UserID == userID) && (c.ProductID == productID)).FirstOrDefault();

				if (cart == null)
				{
					cart = context.Carts.Create();
					cart.UserID = userID;
					cart.ProductID = productID;
					cart.Quantity = quantity;
					context.Carts.Add(cart);
				}
				else
				{
                    context.Carts.Attach(cart);
					cart.Quantity += quantity;
				}

				context.SaveChanges();
			}
		}

		public List<Cart> GetAllCarts()
		{
			using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
			{
				return context.Carts.ToList();
			}
		}

        public int AddProduct(string name, string details, int price, int quantity, List<int> typesIDs)
        {
            using (var context = (_connection != null ? new BazaarEntities(_connection) : new BazaarEntities()))
            {
                if (String.IsNullOrEmpty(name))
                    throw new Exception("Name must not be empty!");
                else if (String.IsNullOrEmpty(details))
                    throw new Exception("Details must not be empty!");
                else if (price <= 0)
                    throw new Exception("Price must be greater than 0!");
                else if (quantity < 0)
                    throw new Exception("Quantity must be at least 0!");
                List<Type> typeList = new List<Type>();
                foreach (var id in typesIDs)
                {
                    Type type = context.Types.Where(t => t.TypeID == id).FirstOrDefault();
                    if (type == null)
                        throw new Exception("Invalid type ID " + Convert.ToString(id));
                    else typeList.Add(type);
                }

                Product productToAdd = new Product()
                {
                    ProductName = name,
                    Details = details,
                    Price = price,
                    Types = typeList
                };

                context.Products.Add(productToAdd);
                context.SaveChanges();

                Stock stockToAddOrUpdate = context.Stocks.Where(s => s.ProductID == productToAdd.ProductID).FirstOrDefault();
                if (stockToAddOrUpdate == null)
                {
                    stockToAddOrUpdate = new Stock()
                    {
                        ProductID = productToAdd.ProductID,
                        InitialQuantity = quantity
                    };
                    context.Stocks.Add(stockToAddOrUpdate);
                }
                else
                {
                    stockToAddOrUpdate.InitialQuantity = quantity;
                    stockToAddOrUpdate.SoldQuantity = 0;
                    context.Stocks.Attach(stockToAddOrUpdate);
                }

                context.SaveChanges();

                return productToAdd.ProductID;
            }
        }
    }
}
