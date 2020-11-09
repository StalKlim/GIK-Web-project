﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Domain.DB;
using WebApplication1.Domain.Model;
using WebApplication1.DTO;
using WebApplication1.Exceptions.Http;

namespace WebApplication1.Controllers.Api
{
    /// <summary>
    /// Котнроллер для работы с постами
    /// </summary>
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly MarketDbContext _marketDbContext;

        /// <summary>
        /// Конструктор класса <see cref="PostController"/>
        /// </summary>
        /// <param name="marketDbContext"> Котекст базы данных</param>
        public PostController(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext ?? throw new ArgumentNullException(nameof(marketDbContext));
        }

        /// <summary>
        /// Получить список всех постов
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<PostDetailsDTO>> GetPosts()
        {
            var response = _marketDbContext.Posts.Select(x => new PostDetailsDTO
            {
                Id = x.Id,
                Created = x.Created,
                Title = x.Title,
                FileId = x.FileId,
                Description = x.Description,
                Data = x.Data
            });

            return Ok(response);
        }

        /// <summary>
        /// Получить конкретный пост
        /// </summary>
        /// <param name="id"> Id поста</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var response = await _marketDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Добавить пост
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Статус</returns>
        [HttpPost]
        public async Task<ActionResult> AddPost(PostDTO data)
        {
            var Post = PostDTO2Post(data);

            await _marketDbContext.AddAsync(Post);

            await _marketDbContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Изменить данные поста
        /// </summary>
        /// <param name="id">Id поста</param>
        /// <param name="data">Данные поста</param>
        /// <returns>Статус</returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdatePost(long id, [FromBody] PostDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var post = _marketDbContext.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
                return NotFound();

            post.Title = data.Title;
            post.Description = data.Description;
            post.FileId = data.FileId;
            post.Data = data.Data;

            _marketDbContext.Posts.Update(post);

            _marketDbContext.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]


        private Post PostDTO2Post(PostDTO data)
        {
            return new Post
            {
                Created = DateTime.Now,
                Title = data.Title,
                Description = data.Description,
                FileId = data.FileId,
                Data = data.Data
            };


        }
    }
}