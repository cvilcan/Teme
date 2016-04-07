using CommunicationLayer.Interfaces;
using CommunicationLayer.PresentationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer.Services
{
	public class UserService: IUserService
	{
		private IAsynchronousClient _client;

		public UserService(IAsynchronousClient dependency)
		{
			_client = dependency;
		}

		public int Login(string username, string hashedPassword)
		{
			string query = "/Account/Login/" + username + "/" + hashedPassword;
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				try
				{
					return Convert.ToInt32(response);
				}
				catch (Exception e)
				{
					return -1;
				}
		}

		public int Register(string username, string hashedPassword)
		{
			string query = "/Account/Register/" + username + "/" + hashedPassword;
			string response = _client.Send(query);
			response = response.Remove(response.Length - 5, 5);
			if (response.IndexOf("Failure!") != -1)
				throw new Exception(response);
			else
				try
				{
					return Convert.ToInt32(response);
				}
				catch (Exception e)
				{
					return -1;
				}
		}
	}
}
