using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace WorkersWages.API.Extensions
{
    /// <summary>
    /// Методы расширения для IdentityResult.
    /// </summary>
    public static class IdentityResultExtensions
    {
        /// <summary>
        /// Проверяет успех действия над каталогом пользователей.
        /// </summary>
        /// <param name="result">Результат работы с ASP.NET Identity.</param>
        /// <param name="action">Действие. Например, "Удаление пользователя".</param>
        /// <exception cref="Exception">В случае, если была ошибка выполнения действия.</exception>
        public static IdentityResult EnsureSucceeded<T>(this IdentityResult result, string action) where T : Exception
        {
            if (!result.Succeeded)
            {
                var deleteErrors = string.Join(", ", result.Errors.Select(e => e.Code + ": " + e.Description));
                var exception = (T)Activator.CreateInstance(typeof(T), args: action + ": " + deleteErrors);
                throw exception;
            }
            return result;
        }
    }
}
