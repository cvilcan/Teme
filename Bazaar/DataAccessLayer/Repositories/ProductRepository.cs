using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
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

		public void RemoveFromStock(int productID, int quantity)
		{
			using (var context = new BazaarEntities())
			{
				if (context.Products.Where(p => p.ProductID == productID).Count() == 0)
					throw new Exception("No product with ID " + Convert.ToString(productID) + " found!");
				else if (context.Products.Where(p => p.ProductID == productID).First().Stock.Quantity < quantity)
					throw new Exception("Not enough products in stock for product with ID " + Convert.ToString(productID));
				else if (quantity <= 0)
					throw new Exception("Invalid quantity!");

				Stock stock = context.Stocks.Where(s => s.ProductID == productID).FirstOrDefault();
				if (stock == null)
					throw new Exception("No stock for product ID " + Convert.ToString(productID) + " found!");

				stock.Quantity -= quantity;
				context.SaveChanges();
			}
		}
	}
}
