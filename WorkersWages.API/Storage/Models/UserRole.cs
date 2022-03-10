using Microsoft.AspNetCore.Identity;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// Описание роли пользователя.
    /// </summary>
    public class UserRole : IdentityRole<int>
    {
        public UserRole()
        {
        }

        public UserRole(string roleName) : base(roleName)
        {
        }
    }
}
