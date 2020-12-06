using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.Product
{
    public class ProductCardViewModel
    {
        public DateTime Created { get; set; }

        public string Name { get; set; }


        public string FileId { get; set; }


        public double Price { get; set; }
    }
}
