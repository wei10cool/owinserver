using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace owinserver.Controllers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (AuthorizeRequest(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
            //base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            //base.HandleUnauthorizedRequest(actionContext);
            return;
        }
        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                var token = actionContext.Request.Headers.Authorization.Parameter;
                return Authenticate.Auth(token);
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
    }
}