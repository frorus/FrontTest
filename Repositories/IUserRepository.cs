using FrontTest.Data.Models;

namespace FrontTest.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserById(Guid id);
        Task<AppUser> GetUserByLogin(string login);
        Task Create(AppUser user);
        Task<bool> UserExists(string login);
    }
}
