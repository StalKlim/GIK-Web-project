
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.Cart
{
    public class ProductCartViewModel
    {
        /// <summary>
        /// Категория товара
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Краткое описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Владелец товара
        /// </summary>
        public string OwnerFullName { get; set; }

        /// <summary>
        /// Изображение товара
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Дата публикации товара
        /// </summary>
        public DateTime Created { get; set; }
    }
}
