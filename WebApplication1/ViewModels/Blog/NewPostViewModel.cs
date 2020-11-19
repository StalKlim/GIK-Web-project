using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.Blog
{
    /// <summary>
    /// Добавление нового поста
    /// </summary>
    public class NewPostViewModel
    {
        /// <summary>
        /// Заголовок поста
        /// </summary>
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        /// <summary>
        /// Содержание поста
        /// </summary>
        [Required]
        [Display(Name = "Данные")]
        public string Data { get; set; }
    }
}