using Refit;
using Domain.Entities;

namespace Infrastructure.Requests.Refit
{
    public interface IJsonPlaceholderApi
    {

        //Trocar para este
        //[Get("/posts/{id}")]
        //Task<ApiResponse<Post>> GetPostByIdAsync(int id);

        [Get("/posts")]
        Task<List<Post>> GetPostsAsync();
        [Get("/posts/{id}")]
        Task<Post> GetPostByIdAsync(int id);
        [Post("/posts/")]
        Task<Post> CreatePostAsync(Post post);
        [Put("/posts/{id}")]
        Task<Post> UpdatePostAsync(int id, Post post);
        [Delete("/posts/{id}")]
        Task DeletePostAsync(int id);
        [Patch ("/posts/{id}")]
        Task<Post> ParcialUpdateAsync(int id, object update);

        //Task<List<Post>> GetPostsByTitleAsync(string title);

    }
}
