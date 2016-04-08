using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Interfaces;
using System.Data.Entity;
using DataAccessLayer;
using Effort;
using System.Data.Entity.Core.EntityClient;
using StructureMap;
using BusinessLayer.Interfaces;
using DataAccessLayer.Repositories;
using BazaarServer.Interfaces;
using BazaarServer.SocketServer;
using BusinessLayer.Services;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Linq;

namespace ProductTester
{
    [TestClass]
    public class ProductRepositoryUnitTest
    {
        ProductRepository _productRepository;
        EntityConnection _connection;

        private Container GetIoCContainer()
        {
            _connection = Effort.EntityConnectionFactory.CreateTransient("name=BazaarEntities");
            var container = new Container(x =>
            {
                x.For<IProductService>().Use<ProductService>();
                x.For<IProductRepository>().Use<ProductRepository>().SelectConstructor(() => new ProductRepository());
                x.For<IRequestHandler>().Use<RequestHandler>();
                x.For<IUserRepository>().Use<UserRepository>();
                x.For<IUserService>().Use<UserService>();
                x.For<AsynchronousSocketListener>().Use<AsynchronousSocketListener>();
                x.For<ProductRepository>().Use<ProductRepository>().Ctor<EntityConnection>().Is(_connection);
                x.For<BazaarEntities>().Use<BazaarEntities>().Ctor<EntityConnection>().Is(_connection);
            });

            return container;
        }

        private void PopulateRepository(int numberOfProducts)
        {
            var productList = Builder<Product>.CreateListOfSize(numberOfProducts)
                .All()
                    .With(c => c.ProductName = Faker.Name.First())
                    .With(c => c.Details = Faker.Lorem.GetFirstWord())
                    .With(c => c.Price = Faker.RandomNumber.Next(1000))
                .Build();
            foreach (var item in productList)
                _productRepository.AddProduct(item.ProductName, item.Details, item.Price, Faker.RandomNumber.Next(50), new List<int>());
        }

        [TestMethod]
        public void TestAddProduct()
        {
            Container container = GetIoCContainer();
            _productRepository = container.GetInstance<ProductRepository>();
            PopulateRepository(10);
            var allProducts = _productRepository.GetAllProducts();
            Assert.AreEqual<int>(10, allProducts.Count, "Not equal");

            Product pisica = new Product();
            pisica.ProductID = _productRepository.AddProduct("Pisica", "blanoasa", 3, 7, new List<int>());
            allProducts = _productRepository.GetAllProducts();
            pisica = allProducts.Where(p => p.ProductID == pisica.ProductID).FirstOrDefault();
            StringAssert.Equals(pisica.ProductName, "Pisica");
            Assert.AreEqual(pisica.Stock.Quantity, 7);
            StringAssert.Equals(pisica.Details, "blanoasa");
            Assert.AreEqual(pisica.Price, 3);

            List<string> nameInvalidClasses = new List<string>() 
            {
                null,
                string.Empty
            };
            List<string> detailsInvalidClasses = nameInvalidClasses;
            List<int> priceInvalidClasses = new List<int>()
            {
                -1
            };
            List<int> quantityInvalidClasses = priceInvalidClasses;

            using (var context = new BazaarEntities(_connection))
            {
                context.Types.Add(new DataAccessLayer.Type()
                    {
                        TypeID = 1,
                        TypeName = "Unu"
                    });
            }
            List<List<int>> typeIDInvalidClasses = new List<List<int>>();
            typeIDInvalidClasses.Add(new List<int>() { -1 });
            typeIDInvalidClasses.Add(_productRepository.GetAllTypes().Select(t => t.TypeID).ToList());

            string failedTests = "";
            foreach (var name in nameInvalidClasses)
                foreach (var details in detailsInvalidClasses)
                    foreach (var price in priceInvalidClasses)
                        foreach (var quantity in quantityInvalidClasses)
                            foreach (var typeID in typeIDInvalidClasses)
                            {
                                try
                                {
                                    _productRepository.AddProduct(name, details, price, quantity, typeID);
                                    Assert.Fail("Add invalid product succeded with: " + Convert.ToString(name) + ", " + Convert.ToString(details) + "," + Convert.ToString(price) + ", " + Convert.ToString(quantity) + ", " + typeID.ToString());
                                }
                                catch (AssertFailedException e)
                                {
                                    failedTests += e.Message;
                                    Assert.Fail(failedTests);
                                }
                                catch (Exception e)
                                {

                                }
                            }
        }
    }
}
