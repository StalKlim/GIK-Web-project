using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Контроллер для работы с блогом
    /// </summary>
    public class BlogController : Controller
    {
        /// <summary>
        /// Возвращение представления Blog возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
