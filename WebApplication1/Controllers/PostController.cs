using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.Services;
using WebApplication1.ViewModels.Post;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Контроллер для работы со страницами новостей
    /// </summary>
    public class PostController : Controller
    {
        private readonly MarketDbContext _marketDbContext;
        private PostServices _postServices;

        public PostController(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
            _postServices = new PostServices(_marketDbContext);
        }

        /// <summary>
        /// Получить список новостей
        /// </summary>
        /// <returns>Возвращает страницу со списком новостей</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var posts = _marketDbContext.Posts
                .Select(x => new PostCardViewModel
                {
                    Id = x.Id,
                    Created = x.Created,
                    FileId = x.FileId,
                    Title = x.Title,
                    Description = x.Description
                }).OrderByDescending(x => x.Created);


            return View(posts);
        }

        /// <summary>
        /// Перейти на страницу конкретной новости
        /// </summary>
        /// <param name="id">Идентификатор новости</param>
        /// <returns>Возвращает страницу конкретной новости</returns>
        [HttpGet]
        public async Task<ActionResult<Post>> Details(long id)
        {
            var post = await _postServices.GetPostsByIdAsync(id);

            var model = new PostDetailViewModel
            {
                Created = post.Created,
                Title = post.Title,
                Description = post.Description,
                FileId = post.FileId,
                Data = post.Data
                
            };
            
            
            return View(model);
        }

    }
}
