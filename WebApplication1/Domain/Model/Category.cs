using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Категории товаров
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// Название категории товара
        /// </summary>
        public string CategoryName { get; set; }
    }
}
