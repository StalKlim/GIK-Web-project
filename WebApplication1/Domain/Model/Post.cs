using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    /// <summary>
    /// Посты сайта
    /// </summary>
    public class Post : Entity
    {
        /// <summary>
        /// Создатель поста
        /// </summary>
        //[Required]
        public Client Owner { get; set; }

        /// <summary>
        /// Дата и время создания поста
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Заголовок поста
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Описание поста
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Изображение к посту
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        [Required]
        public string Data { get; set; }

    }
}
