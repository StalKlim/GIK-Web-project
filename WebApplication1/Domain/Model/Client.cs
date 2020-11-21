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
        /// Конструктор для создания каждому новому клиенту корзины, истории покупок и истории продаж
        /// </summary>
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
        public string FullName
        {
            get => FirstName + " " + Surname;
        }

        /// <summary>
        /// Корзина пользователя
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// История покупок пользователя
        /// </summary>
        public PurchaseHistory PurchaseHistory { get; set; }

        /// <summary>
        /// История продаж пользователя
        /// </summary>
        public SalesHistory SalesHistory { get; set; }
    }
}
