using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Model;

namespace WebApplication1.ViewModels.Cart
{
    public class AddProductViewModel
    {

        /// <summary>
        /// Категория товара
        /// </summary>
        public Category Category { get; set; }

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
        public Client Client { get; set; }

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
