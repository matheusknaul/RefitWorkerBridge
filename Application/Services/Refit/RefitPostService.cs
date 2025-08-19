using Domain.Entities;
using Infrastructure.Requests.Refit;
using Refit;

namespace Application.Services.Refit
{
    public static class RefitPostService
    {

        public static IJsonPlaceholderApi API_CONNECTION { get; } =
            RestService.For<IJsonPlaceholderApi>("https://jsonplaceholder.typicode.com");

        public static async Task<List<Post>> GetAllPosts()
        {
            List<Post> postList = new List<Post>();
            postList = await API_CONNECTION.GetPostsAsync();
            return postList;
        }

        public static async Task<Post> GetPostById(int id)
        {
            return await API_CONNECTION.GetPostByIdAsync(id);
        }
    }
}
