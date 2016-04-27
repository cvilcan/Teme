using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;
using BusinessLayer.Interfaces;
using BusinessLayer.PresentationModels;

namespace BazaarServer.Areas.Product.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService dep)
        {
            _productService = dep;
        }

        [Route("")]
        public IHttpActionResult GetAllProducts()
        {
            IHttpActionResult result;
            List<BusinessLayer.PresentationModels.Product> productList = _productService.GetAllProducts();

            if (productList == null)
                productList = new List<BusinessLayer.PresentationModels.Product>();

            result = Ok(productList);
            return result;
        }

        [Route("")]
        public IHttpActionResult PostGetAllProducts(List<int> selectedTypesID)
        {
            IHttpActionResult result;
            List<BusinessLayer.PresentationModels.Product> productList = _productService.GetAllProducts(selectedTypesID);

            if (productList == null)
                productList = new List<BusinessLayer.PresentationModels.Product>();

            result = Ok(productList);
            return result;
        }

        [Route("Types")]
        public IHttpActionResult GetAllTypes()
        {
            IHttpActionResult result;
            List<BusinessLayer.PresentationModels.Type> typeList = _productService.GetAllTypes();

            if (typeList == null)
                typeList = new List<BusinessLayer.PresentationModels.Type>();

            result = Ok(typeList);
            return result;
        }

        [Route("{userID}/{productID}/{quantity:min(10)}")]
        public IHttpActionResult PostBuyProduct(Guid loginToken, int productID, int quantity)
        {
            IHttpActionResult result;

            try
            {
                _productService.BuyProduct(loginToken, productID, quantity);
                result = Ok("Purchase succesful!");
            }
            catch (Exception e)
            {
                result = InternalServerError(e);
            }

            return result;
        }

        [Route("{loginToken}")]
        public IHttpActionResult GetAllProductsFromCart(Guid loginToken)
        {
            IHttpActionResult result;
            List<BusinessLayer.PresentationModels.Product> productList = _productService.GetAllProductsFromCart(loginToken);

            if (productList == null)
                productList = new List<BusinessLayer.PresentationModels.Product>();

            result = Ok(productList);
            return result;
        }
    }
}
