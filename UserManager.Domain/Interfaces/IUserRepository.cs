using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
