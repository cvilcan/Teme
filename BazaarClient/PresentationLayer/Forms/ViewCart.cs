using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
	public partial class ViewCart : Form
	{
		private IProductController _productController;
		private Guid _loginToken;

		public ViewCart(IProductController dep)
		{
			InitializeComponent();
			_productController = dep;
		}

		private void ViewCart_Shown(object sender, EventArgs e)
		{
			Object o;
			WinformsSession.dictionary.TryGetValue("LoginToken", out o);
			if (o is Guid)
			{
				_loginToken = (Guid)o;
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
            try
            {
                var productList = _productController.GetAllProductsFromCart(_loginToken);
                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = productList;
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
		}
	}
}
