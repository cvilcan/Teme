using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTester
{
    [TestClass]
    public class ProductServiceUnitTest
    {
        ProductService _productService;
        Mock<IProductRepository> _mockProductRepository;
        Mock<IUserRepository> _mockUserRepository;

        [TestMethod]
        public void asd()
        {
            _mockProductRepository = new Mock<IProductRepository>(MockBehavior.Strict);
            _mockUserRepository = new Mock<IUserRepository>(MockBehavior.Loose);

            _productService = new ProductService(_mockProductRepository.Object, _mockUserRepository.Object);
            _mockProductRepository.Setup<List<Product>>(foo => foo.GetAllProducts()).Returns(new List<Product>());
            _mockProductRepository.Setup<List<Stock>>(foo => foo.GetAllStock()).Returns(new List<Stock>());
            _mockProductRepository.Setup<List<DataAccessLayer.Type>>(foo => foo.GetAllTypes()).Returns(new List<DataAccessLayer.Type>());

            var q = _productService.GetAllTypes();
            var w = _productService.GetAllProducts();

            _mockProductRepository.Verify(foo => foo.GetAllProducts(), Times.Once, "UAAAAaaa!");
            _mockProductRepository.Verify(foo => foo.GetAllStock(), Times.Once, "UAAAAsss!");
            _mockProductRepository.Verify(foo => foo.GetAllTypes(), Times.Once, "UAAAAddd!");
            //_mockProductRepository.Verify(foo => foo.GetAllCarts(), Times.Never, "SADSAD");
        }
    }
}
