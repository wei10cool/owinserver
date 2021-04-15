using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace owinserver.Models
{
    public class TokenStore
    {
        public string token { get; set; }
        public string UserId { get; set; }
        public string user { get; set; }
    }
    public class TokenStoreUD
    {
        public string token { get; set; }
        public string UserId { get; set; }
        public UserData user { get; set; }
    }
}