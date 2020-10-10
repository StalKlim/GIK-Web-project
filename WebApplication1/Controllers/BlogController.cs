using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.Security.Extensions;
using WebApplication1.ViewModels.Blog;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Контроллер для работы с блогом
    /// </summary>
    public class BlogController : Controller
    {
        private readonly BlogDbContext _blogDbContext;
        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }
        /// <summary>
        /// Возвращение представления Blog возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            var posts = _blogDbContext.BlogPosts
                .Select(x => new ShowAllPostViewModel
                {
                    Author = x.Owner.FullName,
                    Date = x.Created,
                    Data = x.Data,
                    Title = x.Title
                }).OrderByDescending(x => x.Date);

            return View(posts);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <returns>Переход на страницу постов пользователей</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(NewPostViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            var post = new BlogPost
            {
                Created = DateTime.Now,
                Data = model.Data,
                Title = model.Title,
                Owner = user.Employee
            };

            _blogDbContext.BlogPosts.Add(post);

            _blogDbContext.SaveChanges();

            return View();
        }
    }
}
