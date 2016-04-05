﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkModule.PresentationModels;
using PresentationLayer.Interfaces;

namespace PresentationLayer.Forms
{
	public partial class Bazaar : Form
	{
		private ViewCart _viewCart;
		private IProductController _productController;
		private int _userID;

		public Bazaar(IProductController ctrl, ViewCart cart)
		{
			InitializeComponent();
			_productController = ctrl;
			_viewCart = cart;
		}

		private void Bazaar_Shown(object sender, EventArgs e)
		{
			InitializeSelectedCategoriesList();
			RefreshProductDisplay();
			Object o;
			if (WinformsSession.dictionary.TryGetValue("UserID", out o))
			{
				if (o is Int32)
				{
					_userID = (int)o;
				}
			}
			else
			{
				MessageBox.Show("Invalid login!");
				this.Close();
			}
		}

		private void InitializeSelectedCategoriesList()
		{
			List<NetworkModule.PresentationModels.Type> typeList = _productController.GetAllTypes();

			listBoxSelectedCategories.Items.Clear();
			listBoxFilteredCategories.Items.Clear();
			foreach (var item in typeList)
			{
				listBoxSelectedCategories.Items.Add(new ListBoxTypeItem()
					{
						TypeID = item.TypeID,
						TypeName = item.TypeName
					});
			}
		}

		private void RefreshGridView(List<Product> productList)
		{
			productList.Sort((p1, p2) => p1.Price - p2.Price);
			dataGridViewProducts.DataSource = null;
			dataGridViewProducts.DataSource = productList;
			int width = 70;

			foreach (DataGridViewColumn column in dataGridViewProducts.Columns)
				width += column.Width;
			if (this.Width < width)
				this.Width = width;
			if (tableLayoutPanelProducts.Width < width)
				tableLayoutPanelProducts.Width = width;
			dataGridViewProducts.Width = width;
		}

		private void RefreshBuyInput(List<Product> productList)
		{
			comboBoxProducts.Items.Clear();
			comboBoxProducts.Text = "";
			textBoxQuantity.Text = "";
			foreach (var item in productList)
				comboBoxProducts.Items.Add(new ComboBoxProductItem()
					{
						ProductName = item.ProductName,
						ProductID = item.ProductID,
						StockQuantity = item.Quantity
					});
		}

		private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxQuantity.Text = Convert.ToString(((ComboBoxProductItem)comboBoxProducts.Items[comboBoxProducts.SelectedIndex]).StockQuantity);
		}

		private void buttonBuy_Click(object sender, EventArgs e)
		{
			string errorMessage = "";
			int quantity = 0;
			int? productID = null;
			string returnMessage = "";
			
			if (comboBoxProducts.SelectedIndex != -1)
				productID = ((ComboBoxProductItem)comboBoxProducts.SelectedItem).ProductID;
			else errorMessage += "No items selected!";

			if ((!Int32.TryParse(textBoxQuantity.Text, out quantity)) || (quantity <= 0))
				errorMessage += "\nInvalid quantity!";

			if (errorMessage != "")
				MessageBox.Show(errorMessage);
			else
			{
				returnMessage = _productController.BuyProduct(_userID, (int)productID, quantity);
				if (returnMessage == "Success!")
				{
					RefreshProductDisplay();
					MessageBox.Show(returnMessage);
				}
				else if (returnMessage != "")
					MessageBox.Show(returnMessage);
			}
		}

		private List<int> GetSelectedCategories()
		{
			List<int> selectedCategoryIDs = new List<int>();
			foreach (var item in listBoxSelectedCategories.Items)
			{
				if (item != null)
					selectedCategoryIDs.Add(((ListBoxTypeItem)item).TypeID);
				else
				{
					MessageBox.Show("Fatal error ocurred!");
					break;
				}
			}

			return selectedCategoryIDs;
		}

		private void RefreshProductDisplay()
		{
			List<Product> productList = _productController.GetAllProducts(GetSelectedCategories());

			dataGridViewProducts.DataSource = productList;
			RefreshGridView(productList);
			RefreshBuyInput(productList);
		}

		private void buttonFilterCategory_Click(object sender, EventArgs e)
		{
			if (listBoxSelectedCategories.SelectedIndex == -1)
				MessageBox.Show("No categories selected for filter!");
			else
			{
				List<int> selectedCategoryIDs = GetSelectedCategories();
				int selectedTypeID = ((ListBoxTypeItem)listBoxSelectedCategories.SelectedItem).TypeID;
				selectedCategoryIDs.Remove(selectedTypeID);

				listBoxFilteredCategories.Items.Add(listBoxSelectedCategories.SelectedItem);
				listBoxSelectedCategories.Items.Remove(listBoxSelectedCategories.SelectedItem);
				RefreshProductDisplay();
			}
		}
		private void buttonSelectCategory_Click(object sender, EventArgs e)
		{
			if (listBoxFilteredCategories.SelectedIndex == -1)
				MessageBox.Show("No categories selected for filter!");
			else
			{
				List<int> selectedCategoryIDs = GetSelectedCategories();
				int selectedTypeID = ((ListBoxTypeItem)listBoxFilteredCategories.SelectedItem).TypeID;
				selectedCategoryIDs.Add(selectedTypeID);

				listBoxSelectedCategories.Items.Add(listBoxFilteredCategories.SelectedItem);
				listBoxFilteredCategories.Items.Remove(listBoxFilteredCategories.SelectedItem);
				RefreshProductDisplay();
			}
		}

		private class ComboBoxProductItem
		{
			public string ProductName { get; set; }
			public int ProductID { get; set; }
			public int StockQuantity { get; set; }

			public override string ToString()
			{
				return ProductName;
			}
		}

		private class ListBoxTypeItem
		{
			public int TypeID { get; set; }
			public string TypeName { get; set; }

			public override string ToString()
			{
				return TypeName;
			}
		}

		private void buttonViewCart_Click(object sender, EventArgs e)
		{
			this._viewCart.ShowDialog();
			_viewCart.FormClosed += new FormClosedEventHandler(f_FormClosed);
		}

		private void f_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Show();
		}
	}
}