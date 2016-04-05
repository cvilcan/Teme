using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public List<Product> GetAllProducts()
		{
			using (var context = new BazaarEntities())
			{
				List<Product> productList = context.Products.ToList();
				foreach (var item in productList)
					item.Types = item.Types.ToList();
				return productList;
			}
		}

		public List<Stock> GetAllStock()
		{
			using (var context = new BazaarEntities())
			{
				List<Stock> stockList = context.Stocks.ToList();
				return stockList;
			}
		}

		public List<Type> GetAllTypes()
		{
			using (var context = new BazaarEntities())
			{
				List<Type> typeList = context.Types.ToList();
				return typeList;
			}
		}

		public void SubstractFromStock(int productID, int quantity)
		{
			using (var context = new BazaarEntities())
			{
				Stock stock = context.Stocks.Where(s => s.ProductID == productID).FirstOrDefault();
				if (stock == null)
					throw new Exception("No stock with productID " + Convert.ToString(productID) + " found!");

				if (quantity > stock.Quantity)
					throw new Exception("Requested quantity exceeds stock!");
				
				context.Stocks.Attach(stock);
				stock.Quantity -= quantity;
				context.SaveChanges();
			}
		}

		public void AddToCart(int userID, int productID, int quantity)
		{
			using (var context = new BazaarEntities())
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
					cart.Quantity += quantity;
					context.Carts.Attach(cart);
				}

				context.SaveChanges();
			}
		}

		public List<Cart> GetAllCarts()
		{
			using (var context = new BazaarEntities())
			{
				return context.Carts.ToList();
			}
		}
	}
}
