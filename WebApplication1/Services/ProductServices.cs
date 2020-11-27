using System;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using Microsoft.EntityFrameworkCore;
using WebApplication1.ViewModels.Product;

namespace WebApplication1.Services
{
    /// <summary>
    /// Сервис для взаимодействия с продуктами
    /// </summary>
    public class ProductServices
    {
        private readonly MarketDbContext _marketDbContext;

        public ProductServices(MarketDbContext marketDbContext)
        {
            _marketDbContext = _marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }

        /// <summary>
        /// Получение продукта по его Id
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns>Продукт по его Id или первый продукт, если нужынй не найден</returns>
        public async Task<Product> GetProductsById(long id)
        {
            return await _marketDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateProductMVC(long id, ProductViewModel model)
        {
            return await _marketDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
