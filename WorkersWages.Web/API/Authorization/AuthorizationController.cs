using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
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
            var response = await workersWagesApiClient.AccountLoginAsync(request);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(response.Token);
            var identity = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, CookieAuthenticationDefaults.AuthenticationScheme));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identity, new AuthenticationProperties { IsPersistent = true });

            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(4)
            };
            Response.Cookies.Append("access_token", response.Token, cookieOptions);
            return;
        }

        /// <summary>
        /// Регистрация в системе.
        /// </summary>
        /// <param name="request">Данные для регистрации пользователя в системе.</param>
        [HttpPost("Register")]
        public async Task Register([Required][FromBody] Services.AccountRegisterRequest request)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("api_client");
            var workersWagesApiClient = new Services.WorkersWagesApiClient(_configuration.GetValue<string>("API"), httpClient);
            await workersWagesApiClient.AccountRegisterAsync(request);

            var loginRequest = new Services.AccountLoginRequest
            {
                UserName = request.UserName,
                Password = request.Password
            };
            var response = await workersWagesApiClient.AccountLoginAsync(loginRequest);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(response.Token);
            var identity = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, CookieAuthenticationDefaults.AuthenticationScheme));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identity, new AuthenticationProperties { IsPersistent = true });

            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(4)
            };
            Response.Cookies.Append("access_token", response.Token, cookieOptions);
            return;
        }

        /// <summary>
        /// Выход из системы.
        /// </summary>
        [HttpPost("Logout")]
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("access_token");
            return;
        }
    }
}
