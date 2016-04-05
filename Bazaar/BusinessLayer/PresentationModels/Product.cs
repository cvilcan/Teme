using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.PresentationModels
{
	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Details { get; set; }
		public int Price { get; set; }
		public List<Type> Types { get; set; }
		public int Quantity { get; set; }

		public Product()
		{
			Types = new List<Type>();
		}
	}
}
