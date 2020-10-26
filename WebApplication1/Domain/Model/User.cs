using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public Client Client { get; set; }
    }
}
