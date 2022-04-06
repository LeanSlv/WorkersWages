using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Запрос на изменение учетных данных.
    /// </summary>
    public class AccountEditCredentialsInfoRequest
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}
