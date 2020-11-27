using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Post
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
        /// Изображение к посту
        /// </summary>
        [Display(Name = "Изображение")]
        public string FileId { get; set; }

        /// <summary>
        /// Описание к посту
        /// </summary>
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Основная новость
        /// </summary>
        [Required]
        [Display(Name = "Новость")]
        public string Data { get; set; }
    }
}
