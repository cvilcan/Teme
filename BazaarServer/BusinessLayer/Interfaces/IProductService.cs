﻿using BusinessLayer.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IProductService
	{
		List<Product> GetAllProducts();
		List<Product> GetAllProducts(List<int> selectedCategoryIDs);
		List<BusinessLayer.PresentationModels.Type> GetAllTypes();
		void BuyProduct(int userID, int productID, int quantity);
		List<Product> GetAllProductsFromCart(int userID);
	}
}