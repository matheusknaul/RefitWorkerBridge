using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetAllAsync();
        //Task<Post> GetByUserAsync(int id);
        Task CreateAsync(Post post);
        Task DeleteAsync(int id);


    }
}
