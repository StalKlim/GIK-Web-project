using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Domain.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Контроллер для работы с Home
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MarketDbContext _marketDbContext;

        /// <summary>
        /// Конструктор класса <see cref="HomeController">
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger, MarketDbContext marketDbContext) 
        {
            _logger = logger;
            _marketDbContext = marketDbContext;
        }

        /// <summary>
        /// Возвращение представления Home возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var user = await _marketDbContext.Clients
               .Include(x => x.User)
               .FirstOrDefaultAsync(x => x.Id == 1);

            if (user == null)
                return NotFound();

            return View();
        }

        /// <summary>
        /// Возвращение представления Home возвратом Privacy.cshtml
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Возвращение корректного отображения на случай ошибки
        /// </summary>
        /// <returns>View</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
