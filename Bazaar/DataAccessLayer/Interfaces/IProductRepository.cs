using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
	public interface IProductRepository
	{
		List<Product> GetAllProducts();
		List<Stock> GetAllStock();
		List<Type> GetAllTypes();

		void RemoveFromStock(int productID, int quantity);
	}
}
