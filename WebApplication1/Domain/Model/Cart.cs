using System.Collections.Generic;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Корзина пользователя
    /// </summary>
    public class Cart : Entity
    {
        public Client Owner { get; set; }

        public Product Product { get; set; }
    }
}
