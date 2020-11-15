using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Model
{
    public class SalesHistory
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public Product Product { get; set; }

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
