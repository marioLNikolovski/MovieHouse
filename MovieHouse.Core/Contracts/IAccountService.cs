using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Core.Models;


namespace MovieHouse.Core.Contracts
{
    public interface IAccountService
    {
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        Task<ApplicationUser> FindUserByIdAsync(string userId);
        Task<bool> UpdateUser(UserEditViewModel model);

    }
}
