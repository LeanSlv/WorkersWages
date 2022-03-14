using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Запрос на авторизацию пользователя.
    /// </summary>
    public class AccountLoginRequest
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
