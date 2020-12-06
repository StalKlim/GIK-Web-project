using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Model;

namespace WebApplication1.ViewModels.Post
{
    public class AddPostViewModel
    {
        /// <summary>
        /// Заголовок поста
        /// </summary>
        [Required]
        [MaxLength(100, ErrorMessage = "Введите название новости")]
        public string Title { get; set; }

        /// <summary>
        /// Описание поста
        /// </summary>
        [Required]
        [MaxLength(200, ErrorMessage = "Введите описание новости")]
        public string Description { get; set; }

        /// <summary>
        /// Изображение к посту
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        [Required]
        [MaxLength(500, ErrorMessage = "Введите текст новости")]
        public string Data { get; set; }
    }
}