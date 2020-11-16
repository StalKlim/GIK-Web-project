using System;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    public class SalesHistory : Entity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Статус продажи
        /// </summary>
        public bool IsSold { get; set; }

        /// <summary>
        /// Дата продажи
        /// </summary>
        public DateTime SaleDate { get; set; }
    }
}
