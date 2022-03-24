namespace WorkersWages.Web.API.Authorization
{
    /// <summary>
    /// Результат запроса получения информации о пользователе.
    /// </summary>
    public class AuthorizationUserInfoResponse
    {
        /// <summary>
        /// Отображаемое имя.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; }
    }
}
