using System;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Результат авторизации пользователя.
    /// </summary>
    public class AccountLoginResponse
    {
        /// <summary>
        /// Токен.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Срок действия токена.
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
