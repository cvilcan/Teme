using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class UserRepository: IUserRepository
	{
		public int Login(string username, string hashedPassword)
		{
			using (var context = new BazaarEntities())
			{
				UserProfile userProfile = context.UserProfiles.Where(u => u.Username == username).FirstOrDefault();
				if (userProfile == null)
					return -1;

				string passPlusSalt = hashedPassword + userProfile.Salt;
				byte[] byteArray = Encoding.UTF8.GetBytes(passPlusSalt);
				MemoryStream stream = new MemoryStream(byteArray);

				SHA384 hasher = new SHA384Managed();
				byte[] hashByteArray = hasher.ComputeHash(stream);

				string hashedPassPlusSalt = Convert.ToBase64String(hashByteArray);

				if (hashedPassPlusSalt != userProfile.Password)
					return -1;
				else return userProfile.UserID;
			}
		}

		public int Register(string username, string hashedPassword)
		{
			using (var context = new BazaarEntities())
			{
				RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
				byte[] byteSalt = new byte[4];
				rng.GetBytes(byteSalt);
				int salt = BitConverter.ToInt32(byteSalt, 0);
				
				string passPlusSalt = hashedPassword + salt;
				byte[] byteArray = Encoding.UTF8.GetBytes(passPlusSalt);
				MemoryStream stream = new MemoryStream(byteArray);

				SHA384 hasher = new SHA384Managed();
				byte[] hashByteArray = hasher.ComputeHash(stream);

				string hashedPassPlusSalt = Convert.ToBase64String(hashByteArray);

				UserProfile userProfile = context.UserProfiles.Where(u => u.Username == username).FirstOrDefault();
				if (userProfile != null)
					return -1;
				userProfile = context.UserProfiles.Create();
				userProfile.Username = username;
				userProfile.Salt = salt;
				userProfile.Password = hashedPassPlusSalt;

				context.UserProfiles.Add(userProfile);

				context.SaveChanges();
				return context.UserProfiles.Where(u => u.Username == username).First().UserID;
			}
		}
	}
}
