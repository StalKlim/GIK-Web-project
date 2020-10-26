﻿using System;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Посты сайта
    /// </summary>
    public class Post : Entity
    {
        /// <summary>
        /// Пользователь, который создал сущность
        /// </summary>
        public Client Owner { get; set; }

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
        public string FileId { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        public string Data { get; set; }
    }
}
