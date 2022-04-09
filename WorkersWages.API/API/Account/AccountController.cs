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
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using WorkersWages.API.Extensions;
using WorkersWages.API.Storage;
using System.Linq;
using System.Transactions;

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
        private readonly DataContext _dataContext;

        public AccountController(UserManager<User> userManager, IOptionsSnapshot<AuthOptions> authOptions, DataContext dataContext)
        {
            _userManager = userManager;
            _authOptions = authOptions;
            _dataContext = dataContext;
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
                var fullName = $"{user.LastName} {user.FirstName} {user.MiddleName}";
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, fullName),
                    new Claim(ClaimTypes.Email, user.Email),
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

        /// <summary>
        /// Получение информации о текущем пользователе.
        /// </summary>
        /// <returns>Информация о текущем пользователе.</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AccountUserInfoResponse>> UserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound("Пользователь не найден.");

            return new AccountUserInfoResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        /// <summary>
        /// Изменение основных данных пользователя.
        /// </summary>
        /// <param name="request">Данные запроса.</param>
        [HttpPost("edit-main-info")]
        [Authorize]
        public async Task<IActionResult> EditMainInfo([Required][FromBody] AccountEditMainInfoRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == default)
                return NotFound("Пользователь не найден.");

            if (!string.IsNullOrEmpty(request.Email) && _dataContext.Users.Any(i => i.NormalizedEmail == _userManager.NormalizeEmail(request.Email) && i.Id != user.Id))
                ModelState.AddModelError("email", "Пользователь с таким email-адресом уже существует");
            if (!ModelState.IsValid)
            {
                throw new ApiException();
            }

            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            var result = await _userManager.UpdateAsync(user);
            result.EnsureSucceeded<ApiException>("Обновление основных данных пользователя.");

            return Ok();
        }

        /// <summary>
        /// Изменение учетных данных пользователя.
        /// </summary>
        /// <param name="request">Данные запроса.</param>
        [HttpPost("edit-account-info")]
        [Authorize]
        public async Task<IActionResult> EditCredentialsInfo([Required][FromBody] AccountEditCredentialsInfoRequest request)
        {
            IdentityResult result;

            var user = await _userManager.GetUserAsync(User);
            if (user == default)
                return NotFound("Пользователь не найден.");

            if (_dataContext.Users.Any(i => i.NormalizedUserName == _userManager.NormalizeName(request.UserName) && i.Id != user.Id))
                ModelState.AddModelError("userName", "Пользователь с таким логином уже существует");
            if (!ModelState.IsValid)
            {
                throw new ApiException();
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _userManager.RemovePasswordAsync(user);
                    result.EnsureSucceeded<ApiException>("Удаление пароля пользователя.");

                    result = await _userManager.AddPasswordAsync(user, request.Password);
                    result.EnsureSucceeded<ApiException>("Добавление пароля пользователя.");

                    tr.Complete();
                }
            }

            if (!string.IsNullOrEmpty(request.UserName))
            {
                user.UserName = request.UserName;
                result = await _userManager.UpdateAsync(user);
                result.EnsureSucceeded<ApiException>("Обновление информации о пользователе.");
            }
            
            return Ok();
        }
    }
}
