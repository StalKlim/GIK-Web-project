using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication1.Domain.DB;
using WebApplication1.ViewModels.Cart;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly MarketDbContext _marketDbContext;

        public CartController(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }
        public IActionResult Index(long ClientId)
        {
            var cart = _marketDbContext.Carts
                 .Include(x => x.ProductCarts).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                 .FirstOrDefault(x => x.Client.Id == ClientId);

            var products = cart.ProductCarts.Select(x => x.Product);

            var result = products.Select(x => new ProductCartViewModel
            {
                Name = x.Name,
                Description = x.Description,
                CategoryName = x.Category.CategoryName,
                OwnerFullName = x.Client.FullName,
                Created = x.Created,
                FileId = x.FileId,
                Price = x.Price
            });

            return View(result);
        }

        /*        public Task<ActionResult> AddProduct(AddProductViewModel model)
                {

                }*/

    }
}
