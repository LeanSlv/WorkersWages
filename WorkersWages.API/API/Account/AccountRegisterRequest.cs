using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Запрос на регистрацию нового пользователя.
    /// </summary>
    public class AccountRegisterRequest
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; }

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
