using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.DB;
using WebApplication1.ViewModels.Product;

namespace WebApplication1.Controllers
{
    public class MarketController : Controller
    {
        private readonly MarketDbContext _marketDbContext;

        public MarketController(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _marketDbContext.Products
                .Select(x => new ProductCardViewModel
                {
                    Name = x.Name,
                    FileId = x.FileId,
                    Price = x.Price,
                    Created = x.Created
                }).OrderByDescending(x => x.Created);

            return View(products); 

        }

    }
}
