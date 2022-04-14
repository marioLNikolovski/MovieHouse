using MovieHouse.Infrastructure.Data.Identity;

namespace MovieHouse.Core.Contracts
{
    public interface IAccountService
    {
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        Task<ApplicationUser> FindUserByIdAsync(string userId);
    }
}
