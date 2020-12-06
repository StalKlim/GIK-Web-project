using System.Collections.Generic;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Корзина пользователя
    /// </summary>
    public class Cart : Entity
    {
        /// <summary>
        /// Пользователь корзины
        /// </summary>
        public Client Client { get; set; }

        public IList<ProductCart> ProductCarts { get; set; }
    }
}
