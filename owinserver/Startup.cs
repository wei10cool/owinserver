using Owin;

namespace owinserver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);//startup.auth.cs
        }
    }
}