using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Model
{
    public class PurchaseHistory
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
        /// Дата покупки
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
