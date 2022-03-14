using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WorkersWages.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using WorkersWages.API.Storage.Models;
using System.Threading.Tasks;
using System.Text;
using WorkersWages.API.Exceptions;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Работа с аккаунтами пользователей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptionsSnapshot<AuthOptions> _authOptions;

        public AccountController(UserManager<User> userManager, IOptionsSnapshot<AuthOptions> authOptions)
        {
            _userManager = userManager;
            _authOptions = authOptions;
        }

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="request">Запрос на авторизацию пользователей.</param>
        /// <returns>Токен.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AccountLoginResponse>> Login([FromBody] AccountLoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != default && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.Value.SecretKey));

                var token = new JwtSecurityToken(
                    issuer: _authOptions.Value.Issuer,
                    audience: _authOptions.Value.Audience,
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new AccountLoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        /// <param name="request">Запрос на регистрацнию нового пользователя.</param>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.UserName);
            if (userExists != null)
                throw new ApiException("Пользователь с таким логином уже существует", "UserName");

            var user = new User
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new ApiException("Произошла ошибка при создании нового пользователя.");

            return Ok();
        }
    }
}
