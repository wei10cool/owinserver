using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using owinserver.Models;
using owinserver.Service;
using System.Collections.Generic;
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
                if (user != null)
                {
                    var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserID", user.Id)
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
    }
}
