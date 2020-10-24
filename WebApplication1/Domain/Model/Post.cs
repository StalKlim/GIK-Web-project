﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Посты сайта
    /// </summary>
    public class Post : Entity
    {
        /// <summary>
        /// Дата и время создания поста
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Заголовок поста
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание поста
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Изображение к посту
        /// </summary>
        public Blob Image { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        public string Text { get; set; }
    }
}