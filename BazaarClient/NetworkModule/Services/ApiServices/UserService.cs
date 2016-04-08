using NetworkModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;

namespace NetworkModule.Services.ApiServices
{
    public class UserService: IUserService
    {
        public Guid Login(string username, string hashedPassword)
        {
            try
            {
                Task<Guid> task = LoginAsync(username, hashedPassword);
                return task.Result;
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }

        private async Task<Guid> LoginAsync(string username, string hashedPassword)
        {
            using (var client = new HttpClient())
            {
                Guid loginToken = Guid.Empty;

                client.BaseAddress = new Uri("http://localhost:53658/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("hashedPassword", hashedPassword)
                });

                HttpResponseMessage response = await client.PostAsync("/api/Account/Login", content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    responseString = JsonConvert.DeserializeObject<string>(responseString);
                    Guid.TryParse(responseString, out loginToken);
                }
                return loginToken;
            }
        }

        public Guid Register(string username, string hashedPassword)
        {
            try
            {
                Task<Guid> task = RegisterAsync(username, hashedPassword);
                return task.Result;
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }

        public async Task<Guid> RegisterAsync(string username, string hashedPassword)
        {
            using (var client = new HttpClient())
            {
                Guid loginToken = Guid.Empty;

                client.BaseAddress = new Uri("http://localhost:53658/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("hashedPassword", hashedPassword)
                });

                HttpResponseMessage response = await client.PostAsync("/api/Account/Register", content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    responseString = JsonConvert.DeserializeObject<string>(responseString);
                    Guid.TryParse(responseString, out loginToken);
                }
                return loginToken;
            }
        }


        public void Logout(Guid guid)
        {
            try
            {
                Task task = LogoutAsync(guid);
            }
            catch (Exception e)
            {
                //
            }
        }

        private async Task LogoutAsync(Guid guid)
        {
            using (var client = new HttpClient())
            {
                Guid loginToken = Guid.Empty;

                client.BaseAddress = new Uri("http://localhost:53658/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("username", JsonConvert.ToString(guid))
                });

                HttpResponseMessage response = await client.PostAsync("/api/Account/Logout", content).ConfigureAwait(false);
            }
        }
    }
}
