using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.DB;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Контроллер для работы с блогом
    /// </summary>
    public class BlogController : Controller
    {
        private readonly MarketDbContext _markerDbContext;
        public BlogController(MarketDbContext markerDbContext)
        {
            _markerDbContext = markerDbContext ?? throw new ArgumentNullException(nameof(markerDbContext));
        }

        /// <summary>
        /// Возвращение представления Blog возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var user = await _markerDbContext.Clients
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == 1);

            if (user == null)
                return NotFound();

            return View();
        }
    }
}
