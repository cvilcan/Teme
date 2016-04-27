using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.PresentationModels
{
    public class AccountantProduct
    {
        public int ProductID { get; set; }
		public string ProductName { get; set; }
        public List<Type> Types { get; set; }
        public int InitialStock { get; set; }
        public int Sold { get; set; }
		public int Price { get; set; }
        public string Details { get; set; }

        public AccountantProduct()
		{
			Types = new List<Type>();
		}
    }
}
