using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.Security;
using WebApplication1.Security.Extensions;
using WebApplication1.Services;
using WebApplication1.ViewModels.Product;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Контроллер для работы со страницами продуктов
    /// </summary>
    public class ProductController : Controller
    {
        private readonly MarketDbContext _marketDbContext;
        private ProductServices _productServices;

        public ProductController(MarketDbContext marketDbContext, ProductServices productServices)
        {
            _marketDbContext = _marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
            _productServices = new ProductServices(marketDbContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _marketDbContext.Products
                .Select(x => new ProductDetailsViewModel
                {
                    Id = x.Id,
                    Client = x.Client,
                    FileId = x.FileId,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).OrderByDescending(x => x.Created);

            return View(products);
        }

        [HttpGet]
        public async Task<ActionResult<Product>> Details(long id)
        {
            var product = await _productServices.GetProductsById(id);

            var model = new ProductDetailsViewModel
            {
                Client = product.Client,
                Created = product.Created,
                Name = product.Name,
                FileId = product.FileId,
                Description = product.Description,
                Price = product.Price
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = this.GetAuthorizedUser();

            var product = new Product
            {
                Created = DateTime.Now,
                Name = model.Name,
                FileId = model.FileId,
                Description = model.Description,
                Price = model.Price,
                Client = client.Client
            };

            _marketDbContext.Products.Add(product);

            _marketDbContext.SaveChanges();

            return View();
        }

        [HttpPatch]
        public async Task<ActionResult<Product>> UpdateProduct(long id, ProductDetailsViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var product = await _productServices.UpdateProductMVC(id, model);

            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.FileId = model.FileId;
            product.Description = model.Description;

            _marketDbContext.Products.Update(product);

            _marketDbContext.SaveChanges();

            return View();
        }

        [HttpDelete]
        [Authorize(Roles = SecurityConstants.AdminRole)]
        public IActionResult DeleteProduct(long id)
        {
            var product = _productServices.GetProductsById(id);

            if (product == null)
                return NotFound();

            _marketDbContext.Remove(product);

            _marketDbContext.SaveChanges();

            return View();
        }
    }
}
