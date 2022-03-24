using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WorkersWages.Web.API.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorizationController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="request">Данные для входа в систему.</param>
        [HttpPost("Login")]
        public async Task Login([Required][FromBody] Services.AccountLoginRequest request)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("api_client");
            var workersWagesApiClient = new Services.WorkersWagesApiClient(_configuration.GetValue<string>("API"), httpClient);
            var response = await workersWagesApiClient.LoginAsync(request);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(response.Token);
            var identity = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, CookieAuthenticationDefaults.AuthenticationScheme));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identity, new AuthenticationProperties { AllowRefresh = true });
            await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.SetString("access_token", response.Token);
            return;
        }

        /// <summary>
        /// Получение информации об авторизованном пользователе.
        /// </summary>
        [HttpGet]
        public AuthorizationUserInfoResponse UserInfo()
        {
            return new AuthorizationUserInfoResponse
            {
                DisplayName = User.Identity.Name,
                Email = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value
            };
        }

        /// <summary>
        /// Выход из системы.
        /// </summary>
        [HttpPost("Logout")]
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
            return;
        }
    }
}
