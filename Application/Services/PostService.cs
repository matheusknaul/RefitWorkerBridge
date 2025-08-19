using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task CreatePostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post), "Post cannot be null");
            }
            await _postRepository.CreateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid post ID", nameof(id));
            }
            await _postRepository.DeleteAsync(id);
        }
    }
}
