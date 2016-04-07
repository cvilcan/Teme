using BazaarServer.Interfaces;
using BazaarServer.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.PresentationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaarServer.SocketServer
{
    public class RequestHandler : IRequestHandler
    {
        private IProductService _productService;
        private IUserService _userService;

        public RequestHandler(IProductService dependency, IUserService dependency1)
        {
            _productService = dependency;
            _userService = dependency1;
        }

        public string Handle(string message)
        {
            if ((message == null) || (message == ""))
                return "Failed! Empty message!";
            else
            {
                message = message.Remove(message.Length - 5, 5);
                string[] splitMessage = message.Split('/');
                string controller = splitMessage[1].ToString().ToLower();
                string method = "";
                if (splitMessage.Count() > 1)
                    method = splitMessage[2].ToString().ToLower();
                List<string> methodParameters = new List<string>();
                if (splitMessage.Count() > 3)
                    for (int i = 3; i < splitMessage.Count(); i++)
                        methodParameters.Add(splitMessage[i]);
                switch (controller)
                {
                    case "product":
                        switch (method)
                        {
                            case "getallproducts":
                                if (methodParameters.Count == 0)
                                    return JsonConvert.SerializeObject(_productService.GetAllProducts());
                                else
                                    return GetAllProducts(methodParameters[0]);
                            case "getalltypes":
                                return JsonConvert.SerializeObject(_productService.GetAllTypes());
                            case "buyproduct":
                                if (methodParameters.Count == 3)
                                    return BuyProduct(methodParameters[0], methodParameters[1], methodParameters[2]);
                                else return "Failed! Invalid query!";
                            case "getallproductsfromcart":
                                if (methodParameters.Count == 1)
                                    return GetAllProductsFromCart(methodParameters[0]);
                                else return "Failed! Invalid query!";
                            default:
                                return "Failed! Invalid query!";
                        }
                    case "account":
                        switch (method)
                        {
                            case "login":
                                if (methodParameters.Count == 2)
                                    return Convert.ToString(_userService.Login(methodParameters[0], methodParameters[1]));
                                else return "Failed! Invalid Credentials!";
                            case "register":
                                if (methodParameters.Count == 2)
                                    try
                                    {
                                        return Convert.ToString(_userService.Register(methodParameters[0], methodParameters[1]));
                                    }
                                    catch (Exception e)
                                    {
                                        return "Failed! " + e.Message;
                                    }
                                else return "Failed! Invalid query!";
                            case "logout":
                                if (methodParameters.Count == 1)
                                    try
                                    {
                                        Guid guid = Guid.Empty;
                                        if (Guid.TryParse(methodParameters[0], out guid))
                                            Logout(guid);
                                        return "Success!";
                                    }
                                    catch (Exception e)
                                    {
                                        return "Failed! " + e.Message;
                                    }
                                else return "Failed!";
                            default:
                                return "Failed! Invalid query!";
                        }
                    default:
                        return "Failed! Invalid query!";
                }
            }
        }

        private void Logout(Guid guid)
        {
            _userService.Logout(guid);
        }

        private string GetAllProductsFromCart(string loginToken)
        {
            Guid loginGuid;
            if (!Guid.TryParse(loginToken, out loginGuid))
                throw new Exception("Failed! Invalid login!");
            UserDetails userDetails = _userService.GetUserDetails(loginGuid);
            return JsonConvert.SerializeObject(_productService.GetAllProductsFromCart(userDetails.UserID));
        }

        private string GetAllProducts(string serializedSelectedTypeIDs)
        {
            try
            {
                List<int> selectedTypeIDs = JsonConvert.DeserializeObject<List<int>>(serializedSelectedTypeIDs);
                return JsonConvert.SerializeObject(_productService.GetAllProducts(selectedTypeIDs));
            }
            catch (Exception e)
            {
                return ("Failure! " + e.Message);
            }
        }
        private string BuyProduct(string loginToken, string productID, string quantity)
        {
            Guid loginGuid;
            int intProductID;
            int intQuantity;
            string errors = "";
            if (!Guid.TryParse(loginToken, out loginGuid))
                errors += "Failed! Invalid login!";
            if (!Int32.TryParse(productID, out intProductID))
                errors += "\nInvalid product ID!";
            if (!Int32.TryParse(quantity, out intQuantity))
                errors += "\nInvalid quantity!";
            if (errors != "")
                return errors;
            try
            {
                UserDetails userProfile = _userService.GetUserDetails(loginGuid);
                _productService.BuyProduct(userProfile.UserID, intProductID, intQuantity);
                return "Success!";
            }
            catch (Exception e)
            {
                return "Failed! " + e.Message;
            }
        }
    }
}