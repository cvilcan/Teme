using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
	public partial class ViewCart : Form
	{
		private IProductController _productController;
		private int _userID;

		public ViewCart(IProductController dep)
		{
			InitializeComponent();
			_productController = dep;
		}

		private void ViewCart_Shown(object sender, EventArgs e)
		{
			Object o;
			WinformsSession.dictionary.TryGetValue("UserID", out o);
			if (o is int)
			{
				_userID = (int)o;
			}
			else
			{
				MessageBox.Show("Invalid login!");
				this.Close();
			}
			RefreshGridView();
		}

		private void RefreshGridView()
		{
			var productList = _productController.GetAllProductsFromCart(_userID);
			dataGridViewProducts.DataSource = null;
			dataGridViewProducts.DataSource = productList;
		}
	}
}
