using System;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    public class PurchaseHistory : Entity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
