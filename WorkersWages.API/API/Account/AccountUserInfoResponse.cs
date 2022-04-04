using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Account
{
    /// <summary>
    /// Результат запроса получения информации о текущем пользователе.
    /// </summary>
    public class AccountUserInfoResponse
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        public int Id { get; set; }

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
        /// Логин.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
