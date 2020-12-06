using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Product
{
    public class AddProductViewModel
    {
        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Display(Name = "Описание продукта")]
        public string Description { get; set; }

        [Display(Name = "Изображение продукта")]
        public string FileId { get; set; }

        [Display(Name = "Стоимость продукта")]
        public double Price { get; set; }
    }
}
