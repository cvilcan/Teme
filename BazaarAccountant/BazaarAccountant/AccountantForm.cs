using NetworkModule.Interfaces;
using NetworkModule.PresentationModels;
using NetworkModule.Services.SocketServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazaarAccountant
{
    public partial class AccountantForm : Form
    {
        private IProductService _productService;
        private ListSortDirection _dataGridViewProductsSortdirection = ListSortDirection.Descending;

        public AccountantForm(IProductService dep)
        {
            _productService = dep;
            InitializeComponent();
            List<AccountantProduct> productList = _productService.GetAllAccountantProducts();
            AssignDataSourceToGridView(productList);
        }

        private void dataGridViewProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (String.Compare(dataGridViewProducts.Columns[e.ColumnIndex].HeaderText, "Sales percentage", true) == 0)
            {
                List<AccountantProduct> productList = dataGridViewProducts.DataSource as List<AccountantProduct>;
                if (_dataGridViewProductsSortdirection == ListSortDirection.Descending)
                {
                    dataGridViewProducts.DataSource = productList.OrderBy(x => x.Sold / x.InitialStock).ToList();
                    _dataGridViewProductsSortdirection = ListSortDirection.Ascending;
                }
                else
                {
                    dataGridViewProducts.DataSource = productList.OrderByDescending(x => x.Sold / x.InitialStock).ToList();
                    _dataGridViewProductsSortdirection = ListSortDirection.Descending;
                }
            }
        }

        private void buttonPoorSales_Click(object sender, EventArgs e)
        {
            List<AccountantProduct> productList = _productService.GetAllAccountantProducts().Where(p => p.ComparableSalesPercentage <= 0.3).ToList();
            AssignDataSourceToGridView(productList);
        }

        private void buttonAverageSales_Click(object sender, EventArgs e)
        {
            List<AccountantProduct> productList = _productService.GetAllAccountantProducts().
                Where(p => (p.ComparableSalesPercentage > 0.3) && (p.ComparableSalesPercentage < 0.7)).ToList();
            AssignDataSourceToGridView(productList);
        }


        private void buttonBestSales_Click(object sender, EventArgs e)
        {
            List<AccountantProduct> productList = _productService.GetAllAccountantProducts().Where(p => p.ComparableSalesPercentage >= 0.7).ToList();
            AssignDataSourceToGridView(productList);
        }

        private void buttonAllSales_Click(object sender, EventArgs e)
        {
            List<AccountantProduct> productList = _productService.GetAllAccountantProducts();
            AssignDataSourceToGridView(productList);
        }

        private void AssignDataSourceToGridView(List<AccountantProduct> productList)
        {
            dataGridViewProducts.DataSource = productList;
        }
    }
}
