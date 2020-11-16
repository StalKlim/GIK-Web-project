using System.Collections.Generic;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Client : Entity
    {
        /// <summary>
        /// Учётная запись
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Пост пользователя
        /// </summary>
        public ICollection<Post> Post { get; set; }
        /// <summary>
        /// Возвращает полное имя пользователя
        /// </summary>
        
        public ICollection<Product> Products { get; set; }
        
        public Cart Cart { get; set; }
        public string FullName
        {
            get => FirstName + " " + Surname;
        }
    }
}
