using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public class PostServices
    {
        private readonly MarketDbContext _marketDbContext;

        /// <summary>
        /// 
        /// </summary>
        public PostServices(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }

        public async Task<Post> GetPostsByIdAsync(long id)
        {
            return await _marketDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdatePost(Post post, PostDTO data)
        {
            
        }

    }
}
