using System.Collections.Generic;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Client : Entity
    {

        public Client()
        {
            this.Cart = new Cart();
            this.PurchaseHistory = new PurchaseHistory();
            this.SalesHistory = new SalesHistory();
        }
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
        /// Возвращает полное имя пользователя
        /// </summary>
        
        public Cart Cart { get; set; }

        public PurchaseHistory PurchaseHistory { get; set; }

        public SalesHistory SalesHistory { get; set; }

        public string FullName
        {
            get => FirstName + " " + Surname;
        }
    }
}
