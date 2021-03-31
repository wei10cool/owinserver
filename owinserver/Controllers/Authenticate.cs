using Newtonsoft.Json;
using owinserver.Models;
using System.IO;

namespace owinserver.Controllers
{
    public class Authenticate
    {
        public static bool Auth(string Token)
        {
            var dataFile = "C:\\temp\\accesstoken.txt";
            var data = File.ReadAllText(dataFile);
            var response = JsonConvert.DeserializeObject<TokenStore>(data);
            if (response.token == Token)
            {
                return true;
            }
            return false;
        }
        public static bool AuthDelete(string Token)
        {
            var dataFile = "C:\\temp\\accesstoken.txt";
            var data = File.ReadAllText(dataFile);
            TokenStore response = JsonConvert.DeserializeObject<TokenStore>(data);
            if (response.token == Token)
            {
                response.token = "";
                File.WriteAllText(dataFile, JsonConvert.SerializeObject(response));
                return true;
            }
            return false;
        }
        public static string AuthUser(string Token)
        {
            var dataFile = "C:\\temp\\accesstoken.txt";
            var data = File.ReadAllText(dataFile);
            TokenStore response = JsonConvert.DeserializeObject<TokenStore>(data);
            if (response.token == Token)
            {
                return data;
            }
            return "";
        }
    }
}