using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Запрос на изменение основных данных пользователя.
    /// </summary>
    public class AccountEditMainInfoRequest
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
        [Required]
        public string Email { get; set; }
    }
}
