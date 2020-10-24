using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Корзина пользователя
    /// </summary>
    public class Cart : Entity
    {
        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }
    }
}
