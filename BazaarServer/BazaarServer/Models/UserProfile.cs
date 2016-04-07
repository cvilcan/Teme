using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaarServer.Models
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}