using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// Товар
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
