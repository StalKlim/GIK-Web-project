using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTO
{
    public class PostDetailsDTO
    {
        public long Id { get; set; }

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

