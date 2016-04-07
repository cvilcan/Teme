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
		public Guid Login(string username, string hashedPassword)
		{
			using (var context = new BazaarEntities())
			{
				UserProfile userProfile = context.UserProfiles.Where(u => u.Username == username).FirstOrDefault();
                Guid returnGuid = Guid.Empty;

                if (userProfile != null)
                {
                    string passPlusSalt = hashedPassword + userProfile.Salt;
                    byte[] byteArray = Encoding.UTF8.GetBytes(passPlusSalt);
                    MemoryStream stream = new MemoryStream(byteArray);

                    SHA384 hasher = new SHA384Managed();
                    byte[] hashByteArray = hasher.ComputeHash(stream);

                    string hashedPassPlusSalt = Convert.ToBase64String(hashByteArray);

                    if (hashedPassPlusSalt == userProfile.Password)
                    {
                        returnGuid = Guid.NewGuid();
                        context.UserProfiles.Attach(userProfile);
                        userProfile.LoginToken = returnGuid;

                        context.SaveChanges();
                    }
                }

                return returnGuid;
			}
		}

		public Guid Register(string username, string hashedPassword)
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
					return Guid.Empty;
				userProfile = context.UserProfiles.Create();
				userProfile.Username = username;
				userProfile.Salt = salt;
				userProfile.Password = hashedPassPlusSalt;

				context.UserProfiles.Add(userProfile);

				context.SaveChanges();
				return this.Login(username, hashedPassword);
			}
		}

        public Tuple<int, string> GetUserDetails(Guid loginGuid)
        {
            using (var context = new BazaarEntities())
            {
                UserProfile userProfile = context.UserProfiles.Where(profile => profile.LoginToken == loginGuid).FirstOrDefault();
                Tuple<int, string> userDetails = new Tuple<int,string>(-1, "");

                if (userProfile != null)
                {
                    userDetails = new Tuple<int, string>(userProfile.UserID, userProfile.Username);
                }
                return userDetails;
            }
        }
    }
}
