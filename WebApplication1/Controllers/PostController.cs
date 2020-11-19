using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication1.Domain.DB;
using WebApplication1.ViewModels.Post;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        private readonly MarketDbContext _marketDbContext;

        public PostController(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }

        public IActionResult Index()
        {
            var posts = _marketDbContext.Posts
                .Select(x => new PostCardViewModel
                {
                    Created = x.Created,
                    FileId = x.FileId,
                    Title = x.Title,
                    Description = x.Description
                }).OrderByDescending(x => x.Created);


            return View(posts);
        }
    }
}