using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using owinserver.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace owinserver.Controllers
{
    public class UserController : ApiController
    {
        // api/User [Get]
        //public string Get()
        //{
        //    //var token = ActionContext.Request.Headers.Authorization.Parameter;
        //    //var dataFile = "C:\\temp\\accesstoken.txt";
        //    //var data = File.ReadAllText(dataFile);
        //    //var response = JsonConvert.DeserializeObject<TokenStore>(data);
        //    //if (response.token==token)
        //    //{
        //    //    return response.UserId;
        //    //}
        //    //return null;
        //}

        [CustomAuthorize]
        public TokenStoreUD Get()
        {
            var token = ActionContext.Request.Headers.Authorization.Parameter;
            string data = Authenticate.AuthUser(token);
            if (data != "")
            {
                //data = data.Replace("\\","");
                string data2 = data.Replace("\"{\\\"", "{\"").Replace("\\\"}\"", "\"}").Replace("\\", "");
               // JObject job = JObject.Parse(data);
                 var response = JsonConvert.DeserializeObject<TokenStoreUD>(data2);
                return response;
            }
            return new TokenStoreUD();
        }
    }
}
