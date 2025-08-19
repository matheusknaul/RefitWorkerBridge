using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

//https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-9.0

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        { 
            var post = await _postService.GetPostByIdAsync(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post cannot be null");
            }
            await _postService.CreatePostAsync(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid post ID");
            }
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
