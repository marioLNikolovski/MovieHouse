using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Repositories;

namespace MovieHouse.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IApplicationDbRepository repo;

        public AccountService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public  async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException("No user found.");
            }
            else
            {
                return user;
            }

        }

        public async Task<ApplicationUser> FindUserByIdAsync(string userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Include(p=> p.Country)
                .Include(p=> p.City)
                .Where(p => p.Id == userId)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentNullException("No user found.");
            }
            else
            {
                return user;
            }

        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>()
                .Select(x => new UserListViewModel
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = $"{x.FirstName} {x.LastName}"
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.CountryId = model.Country;
                    user.CityId = model.City;
                   
                  
                    await repo.SaveChangesAsync();
                    result = true;
                }
            return result;
        }
    }
}
