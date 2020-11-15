using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Post
{
    public class PostCardViewModel
    {
        [Display(Name = "Изображение поста")]
        public string FileId { get; set; }

        [Display(Name = "Заголовок поста")]
        public string Title { get; set; }

        [Display(Name = "Описание поста")]
        public string Description { get; set; }

        [Display(Name = "Дата создания поста")]
        public DateTime Created { get; set; }

    }
}
