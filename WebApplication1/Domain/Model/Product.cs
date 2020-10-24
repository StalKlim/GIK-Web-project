﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    public class Product : Entity
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
        /// Состояние модерации
        /// </summary>
        public bool IsAproved { get; set; }

        /// <summary>
        /// Владелец товара
        /// </summary>
        public Client Owner { get; set; }

        /// <summary>
        /// Изображение товара
        /// </summary>
        public string FileId { get; set; }


    }
}