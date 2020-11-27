using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.Security.Extensions;
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

            _marketDbContext.Posts.Add(post);

            _marketDbContext.SaveChanges();

            return View();
        }

        /// <summary>
        /// Изменить пост
        /// </summary>
        /// <param name="id">Id поста</param>
        /// <param name="model">Данные поста</param>
        /// <returns>Изменяет новость</returns>
        [HttpPatch]
        public async Task<ActionResult<Post>> UpdatePost(long id, PostDetailViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var post = await _postServices.UpdatePostMVC(id, model);

            if (post == null)
                return NotFound();

            post.Title = model.Title;
            post.FileId = model.FileId;
            post.Description = model.Description;
            post.Data = model.Data;

            _marketDbContext.Posts.Update(post);

            _marketDbContext.SaveChanges();

            return View();
        }

        /// <summary>
        /// Переход на страницу добавления новости
        /// </summary>
        /// <returns>Возвращает страницу добавления новости</returns>
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        /// <summary>
        /// Добавление новости
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddPost(AddPostViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var client = this.GetAuthorizedUser();

            var post = new Post
            {
                Created = DateTime.Now,
                Title = model.Title,
                Description = model.Description,
                FileId = model.FileId,
                Data = model.Data,
                Client = client.Client
            };

            await _marketDbContext.AddAsync(post);

            await _marketDbContext.SaveChangesAsync();

            return View();
        }


        /// <summary>
        /// Удаляет пост
        /// </summary>
        /// <param name="id">Id поста</param>
        /// <returns>Удаляет новость</returns>
        [HttpDelete]
        public IActionResult DeletePost(long id)
        {
            var post = _postServices.GetPostsByIdAsync(id);

            if (post == null)
                return NotFound();

            _marketDbContext.Remove(post);

            _marketDbContext.SaveChanges();

            return View();
        }
    }
}