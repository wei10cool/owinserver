using Newtonsoft.Json;
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
        public TokenStore Get()
        {
            var token = ActionContext.Request.Headers.Authorization.Parameter;
            string data = Authenticate.AuthUser(token);
            if (data != "")
            {
                var response = JsonConvert.DeserializeObject<TokenStore>(data);
                return response;
            }
            return new TokenStore();
        }
    }
}
