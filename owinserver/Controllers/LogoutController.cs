using System.Web.Http;

namespace owinserver.Controllers
{
    public class LogoutController : ApiController
    {
        [HttpPost]
        public bool Post()
        {
            var token = ActionContext.Request.Headers.Authorization.Parameter;
            return Authenticate.AuthDelete(token);
        }
    }
}
