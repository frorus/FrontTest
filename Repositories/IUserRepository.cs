using FrontTest.Data.Models;

namespace FrontTest.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserById(Guid id);
        Task<AppUser> GetUserByPhone(string login);
        Task Create(AppUser user);
        Task<bool> UserExists(string phone);
    }
}
