using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace owinserver.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserData
    {
        public string email { get; set; }
        public string name { get; set; }
    }
}