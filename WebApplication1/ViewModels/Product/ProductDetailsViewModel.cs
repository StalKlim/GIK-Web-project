using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Domain.Model;

namespace WebApplication1.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Продавец")]
        public Client Client { get; set; }

        [Display(Name = "Изображение продукта")]
        public string FileId { get; set; }

        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Display(Name = "Описание продукта")]
        public string Description { get; set; }

        [Display(Name = "Стоимость продукта")]
        public double Price { get; set; }

        [Display(Name = "Дата публикации продукта")]
        public DateTime Created { get; set; }
    }
}
