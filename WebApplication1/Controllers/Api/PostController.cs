using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;

namespace WebApplication1.Controllers.Api
{
    /// <summary>
    /// Котнроллер для работы с постами
    /// </summary>
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly MarketDbContext _MarketDbContext;

        /// <summary>
        /// Конструктор класса <see cref="PostController"/>
        /// </summary>
        /// <param name="MarketDbContext"> Котекст базы данных</param>
        public PostController(MarketDbContext MarketDbContext)
        {
            _MarketDbContext = MarketDbContext ?? throw new ArgumentNullException(nameof(MarketDbContext));
        }


        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _MarketDbContext.Posts;
        }


        [HttpGet]
        public async Task<IActionResult> GetPost(long id)
        {
            /// TODO: выбор поста по id
        }
    }
}
