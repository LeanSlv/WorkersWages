using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WorkersWages.API.Models
{
    /// <summary>
    /// Опции для авторизации пользователей.
    /// </summary>
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
