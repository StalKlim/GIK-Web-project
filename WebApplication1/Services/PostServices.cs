using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.DTO;
using WebApplication1.ViewModels.Post;

namespace WebApplication1.Services
{
    /// <summary>
    /// Сервис для взаимодействия с постами
    /// </summary>
    public class PostServices
    {
        private readonly MarketDbContext _marketDbContext;

        public PostServices(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }

        /// <summary>
        /// Получение поста по id
        /// </summary>
        /// <param name="id">Id поста</param>
        /// <returns>Пост по его Id или первый пост, если не найден нужный</returns>
        public async Task<Post> GetPostsByIdAsync(long id)
        {
            return await _marketDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdatePost(Post post, PostDTO data)
        {

        }

        /// <summary>
        /// Обновление поста
        /// </summary>
        /// <param name="id">Id поста</param>
        /// <param name="model">Данные</param>
        /// <returns>Пост по его Id или первый пост, если не найден нужный</returns>
        public async Task<Post> UpdatePostMVC(long id, PostDetailViewModel model)
        {
            return await _marketDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
