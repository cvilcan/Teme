#region Not_Used_Since_Login_Not_Implemented

//using NetworkModule.Interfaces;
//using NetworkModule.PresentationModels;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NetworkModule.Services.SocketServices
//{
//    public class UserService: IUserService
//    {
//        private IAsynchronousClient _client;

//        public UserService(IAsynchronousClient dependency)
//        {
//            _client = dependency;
//        }

//        public Guid Login(string username, string hashedPassword)
//        {
//            string query = "&User&Login&" + JsonConvert.SerializeObject(username) + "&" + JsonConvert.SerializeObject(hashedPassword);
//            string response = _client.Send(query);
//            response = response.Remove(response.Length - 5, 5);
//            if (response.IndexOf("Failure!") != -1)
//                throw new Exception(response);
//            else
//                try
//                {
//                    Guid loginGuid = Guid.Empty;
//                    Guid.TryParse(JsonConvert.DeserializeObject<string>(response), out loginGuid);
//                    return (loginGuid);
//                }
//                catch (Exception e)
//                {
//                    return Guid.Empty;
//                }
//        }

//        public Guid Register(string username, string hashedPassword)
//        {
//            string query = "&User&Register&" + JsonConvert.SerializeObject(username) + "&" + JsonConvert.SerializeObject(hashedPassword);
//            string response = _client.Send(query);
//            response = response.Remove(response.Length - 5, 5);
//            if (response.IndexOf("Failure!") != -1)
//                throw new Exception(response);
//            else
//                try
//                {
//                    Guid loginGuid = Guid.Empty;
//                    Guid.TryParse(response, out loginGuid);
//                    return (loginGuid);
//                }
//                catch (Exception e)
//                {
//                    return Guid.Empty;
//                }
//        }

//        public void Logout(Guid guid)
//        {
//            string query = "&User&Logout&" + JsonConvert.SerializeObject(guid);
//            string response = _client.Send(query);
//            response = response.Remove(response.Length - 5, 5);
//            if (response.IndexOf("Failure!") != -1)
//                throw new Exception(response);
//        }
//    }
//}

#endregion