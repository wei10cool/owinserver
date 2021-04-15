using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using owinserver.Models;
using owinserver.Service;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace owinserver.provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var userService = new UserService();
                User user = userService.GetUserByCredentials(username, password);
                UserData userdata = new UserData() { name = user.Id, email = user.Email };
                var userdataStr =JsonConvert.SerializeObject(userdata);
                if (user != null)
                {
                    var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserID", user.Id),
                        new Claim("user", userdataStr),
                };
                   

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
            // return base.GrantResourceOwnerCredentials(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
            //return base.ValidateClientAuthentication(context);
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            //記錄token
            var datafile = "c:\\temp\\accesstoken.txt";
            List<claimitem> citem = new List<claimitem>();
            foreach (var item in context.Identity.Claims)
            {
                var c = new claimitem()
                {
                    issuer = item.Issuer,
                    value = item.Value,
                    oris = item.OriginalIssuer,
                    claimtype = item.Type,
                };
                citem.Add(c);
            }
            var uid = citem.Find(x => x.claimtype == "UserID").value;
            var userdata = citem.Find(x => x.claimtype == "user").value;
            TokenStore data = new TokenStore() { token = context.AccessToken, UserId = uid,user= userdata };
            Directory.CreateDirectory("c:\\temp\\");
            File.WriteAllText(datafile, JsonConvert.SerializeObject(data));
            return base.TokenEndpointResponse(context);
        }
        public class claimitem
        {
            public string issuer { get; set; }
            public string oris { get; set; }
            public string claimtype { get; set; }
            public string value { get; set; }

        }
    }
}
